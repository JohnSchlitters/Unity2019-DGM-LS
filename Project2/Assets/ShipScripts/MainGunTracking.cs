using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MainGunTracking : MonoBehaviour
{
    [SerializeField]
    private Transform playerGunBarrel;
    [SerializeField]
    private GameObject firedShell;
    
    public Text uiShipReloadStatus;

    public bool playerArtilleryReload;
    public AudioClip playerGunFire;
    public float playerReloadTime = 4.0f;
    void Start()
    {
        //  Cursor.visible = false; interferes with reticle
        print("starting gun tracking");
        playerArtilleryReload = false;
    }
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
        //https://answers.unity.com/questions/10615/rotate-objectweapon-towards-mouse-cursor-2d.html
        if (Input.GetMouseButtonDown(0))
        {
            if (playerArtilleryReload) //check if the ship can fire
            {
                print("gun battery reloading"); //cannot fire if reloading
            }
            else
            {
                StartCoroutine(ReloadFunction());
                playerArtilleryReload = true; //set on reload
            }

        }
    }
    private void FirePlayerArtillery() //fire ship gun
    {
        GameObject firedArtillery = Instantiate(firedShell, playerGunBarrel.position, playerGunBarrel.rotation);
        print("FIRE!");
        firedArtillery.GetComponent<Rigidbody2D>().velocity = playerGunBarrel.right * 50f;
        //god bless this man
        //https://www.youtube.com/watch?v=01HVr1fp7pU
        AudioSource.PlayClipAtPoint(playerGunFire, transform.position);

    }

    public IEnumerator ReloadFunction() //reload ship gun to prevent spamming
    {
        if (playerReloadTime == 0)
        {
            uiShipReloadStatus.text = "Main Battery Ready to Fire";
            print("ready to fire main battery");
        }
        {
            FirePlayerArtillery(); //start firing function
            uiShipReloadStatus.text = "Main Battery Reloading";
            yield return new WaitForSeconds(playerReloadTime);
            playerArtilleryReload = false;
            uiShipReloadStatus.text = "Main Battery Ready to Fire";
            print("ready to fire main battery");
        }

        /*       float firingdelay = Random.Range(0.05f, 0.2f);
               yield return new WaitForSeconds(firingdelay);
               FirePlayerArtillery(); //start firing function
               uiShipReloadStatus.text = "Main Battery : Reloading";
               yield return new WaitForSeconds(4);
               playerArtilleryReload = false;
               uiShipReloadStatus.text = "Main Battery : Ready to Fire!";
               print("ready to fire main battery");
               */
    }
}