using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerDetectPowerup : MonoBehaviour

{
    public MainGunTracking getReloadTime;

    public TorpedoTubeTracking getTorpedoCount;

    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D powerupCollision2D)
    {
        if (powerupCollision2D.gameObject.name == "playerPowerUpReload")
        {
            StartCoroutine(reloadPowerUp());
            print("starting boosted reload");
            Destroy(powerupCollision2D.gameObject);
            print("destroyed powerup");
        }

        if (powerupCollision2D.gameObject.name == "playerPowerUpTorpedo")
        {
            torpedoPowerUp();
            print("starting torpedo boost");
            Destroy(powerupCollision2D.gameObject);
            print("destroyed powerup");
        }
    }

    public IEnumerator reloadPowerUp()
    {
        getReloadTime.playerArtilleryReload = false;
        getReloadTime.playerReloadTime = 2;
        print("set reload to 2s");
        yield return new WaitForSeconds(15);
        getReloadTime.playerReloadTime = 4;
        print("player reload returned to normal");
    }

    public void torpedoPowerUp()
    {
        StopCoroutine(getTorpedoCount.playerTorpedoReloadFunc());
        getTorpedoCount.playerTorpedoCount = 4;
        getTorpedoCount.uiShipTorpedoStatus.text = ("Torpedo Tubes " + getTorpedoCount.playerTorpedoCount + " Ready");
        print("fully reloaded torpedo tube");
    }

}
