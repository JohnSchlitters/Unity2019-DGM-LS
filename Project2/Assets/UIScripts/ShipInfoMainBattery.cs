using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipInfoMainBattery : MonoBehaviour
{
    public Text uiShipReloadStatus;

    public MainGunTracking getReloadStatus;
    // Start is called before the first frame update
    void Start()
    {
        print("starting to track player main battery");
    }

    // Update is called once per frame
    void Update()
    {
        if (getReloadStatus.playerArtilleryReload = true)
        {
            StartCoroutine(ReloadTimerText());
        }
    }

    public IEnumerator ReloadTimerText()
    {
        uiShipReloadStatus.text = "Main Battery : Reloading : 4.0s";
        yield return new WaitForSeconds(1);
        uiShipReloadStatus.text = "Main Battery : Reloading : 3.0s";
        yield return new WaitForSeconds(1);
        uiShipReloadStatus.text = "Main Battery : Reloading : 2.0s";
        yield return new WaitForSeconds(1);
        uiShipReloadStatus.text = "Main Battery : Reloading : 1.0s"; 
        yield return new WaitForSeconds(1);
        uiShipReloadStatus.text = "Main Battery : Ready to Fire!";
    }
}
