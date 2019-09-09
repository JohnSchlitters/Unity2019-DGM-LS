using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TorpedoTubeTracking : MonoBehaviour
{
    // Start is called before the first frame update
    public int playerTorpedoCount = 4;
    public float playerTorpedoReload = 60;
    public AudioClip playerTorpedoLaunch;
    [SerializeField]
    private GameObject launchedTorp;
    [SerializeField]
    private Transform playerTorpedoSpoon;
    public Text uiShipTorpedoStatus;
    void Start()
    {
        print("Starting torpedo tracking");
    }

    // Update is called once per frame
    void Update()
    {

        //rotation of object
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 5.23f;

        if (Camera.main != null)
        {
            Vector3 objectPosition = Camera.main.WorldToScreenPoint(transform.position);
            mousePosition.x = mousePosition.x - objectPosition.x;
            mousePosition.y = mousePosition.y - objectPosition.y;
        }

        float angle = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (playerTorpedoCount > 0) //check if the ship can fire
            {
                print("torpedo battery reloading"); //cannot fire if reloading
                fireTorpedoBattery();
                
            }
            else
            {
                print("reloading torpedo tubes");
            }
        }
        
    }
    private void fireTorpedoBattery() //fire torpedo
    {
        GameObject launchedTorpedo = Instantiate(launchedTorp, playerTorpedoSpoon.position, playerTorpedoSpoon.rotation);
        print("LAUNCH TORPEDO!");
        launchedTorpedo.GetComponent<Rigidbody2D>().velocity = playerTorpedoSpoon.right * 20f;
        //copied and edited from old script
        //AudioSource.PlayClipAtPoint(playerTorpedoLaunch, transform.position);
        playerTorpedoCount -= 1;
        if (playerTorpedoCount == 0)
        {
            StartCoroutine(playerTorpedoReloadFunc());
            uiShipTorpedoStatus.text = ("Torpedo Tubes Reloading...");
        }
        else
        {
            uiShipTorpedoStatus.text = ("Torpedo Tubes " + playerTorpedoCount + " Ready");
            print("torpedos may fire again");
        }
    }

    public IEnumerator playerTorpedoReloadFunc()
    {
        yield return new WaitForSeconds(playerTorpedoReload);
        playerTorpedoCount = 4;
        uiShipTorpedoStatus.text = ("Torpedo Tubes " + playerTorpedoCount + " Ready");
    }
}
