using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoreBatteryTrack : MonoBehaviour
{
    public Transform playerTarget;
    public Transform batteryLocation;
    public GameObject firedBatteryArtillery;
    public bool batteryReloadStatus = false;
    public float playerDistance;
    public float targetRange = 70f;
    public AudioClip enemyBatteryFire;
    public int batteryReloadTime;
    [SerializeField]
    private Transform enemyGunBarrel;

    // Start is called before the first frame update
    void Start()
    {
        print("starting enemy tracking for shore battery");
    }

    // Update is called once per frame
    void OnCollisionEnter()
    {
    }

    void Update()
    {
        playerDistance = Vector3.Distance(playerTarget.position, batteryLocation.position);
        var lookDir = playerTarget.position-transform.position;
        lookDir.y = 0; // keep only the horizontal direction
        lookDir.z = 0;
        
        if (playerDistance < targetRange)
        {
           
            transform.rotation = Quaternion.LookRotation(lookDir);
            print("player in range");
            if (batteryReloadStatus == true)
            {
                StartCoroutine(BatteryReloadFunction());
            }
        }
        
    }

    private void BatteryShootAtPlayer()
    {
        GameObject batteryArtillery = Instantiate(firedBatteryArtillery, enemyGunBarrel.position, enemyGunBarrel.rotation);
        batteryArtillery.name = "firedBatteryShell";
        print("firing enemy battery!");
        batteryArtillery.GetComponent<Rigidbody2D>().velocity = enemyGunBarrel.right * 50f;
        AudioSource.PlayClipAtPoint(enemyBatteryFire, transform.position);
        batteryReloadStatus = true;
    }

    public IEnumerator BatteryReloadFunction() //reload battery gun to make survival possible
    {
        if (batteryReloadTime == 0)
        {
            print("battery reloading");
        }
        else //for clarity
        {
            print("reloading enemy battery");
            BatteryShootAtPlayer();
            yield return new WaitForSeconds(6);
            batteryReloadStatus = false;
        }
    }
}
