using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerDetectPowerup : MonoBehaviour

{
    public MainGunTracking getReloadTime;
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
    }

    private IEnumerator reloadPowerUp()
    { 
        gameObject.GetComponent<MainGunTracking>().playerReloadTime = 2.0f;
        print("set reload to 2s");
        yield return new WaitForSeconds(15);
        gameObject.GetComponent<MainGunTracking>().playerReloadTime = 4.0f;
        print("player reload returned to normal");
    }
}
