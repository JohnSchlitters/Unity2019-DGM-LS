using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Animations;
using UnityEngine.Experimental.PlayerLoop;

public class shoreBatteryTrack : MonoBehaviour
{
    public Transform playerTarget;
    public Transform batteryLocation;
    public GameObject firedBatteryArtillery;
    public bool batteryReloadStatus = false;
    public float playerDistance;
    public float targetRange;
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
        playerDistance = Vector3.Distance(playerTarget.transform.position, batteryLocation.transform.position);
        if (playerDistance < targetRange)
        {
            Vector3 diff = playerTarget.position - batteryLocation.position;
            diff.Normalize();
            float rotationZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            batteryLocation.rotation = Quaternion.Euler(0f,0f,rotationZ - 180);
            print("player in range");
            if (batteryReloadStatus == false)
            {
                BatteryShootAtPlayer();
                batteryReloadStatus = true;
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
    }

    public IEnumerator BatteryReloadFunction() //reload battery gun to make survival possible
    {
        print("battery reloading");
        yield return new WaitForSeconds(batteryReloadTime);
        batteryReloadStatus = false;
    }
}
