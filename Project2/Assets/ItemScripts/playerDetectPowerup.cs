using System;
using System.Collections;
using UnityEngine;


public class playerDetectPowerup : MonoBehaviour

{
    public MainGunTracking getReloadTimeA;
    public MainGunTracking getReloadTimeB;
    public MainGunTracking getReloadTimeX;
    public TorpedoTubeTracking getTorpedoCount;
    public ShipIntegrity getPlayerHP;

    private void Start()
    {
        print("starting power up tracking");
    }
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D powerupCollision2D)
    {
        if (powerupCollision2D.gameObject.name == "playerPowerUpReload")
        {
            Debug.Log("touched a powerup");
            StartCoroutine(ReloadPowerUp());
            print("starting boosted reload");
            Destroy(powerupCollision2D.gameObject);
            print("destroyed powerup");
        }

        if (powerupCollision2D.gameObject.name == "playerPowerUpTorpedo")
        {
            Debug.Log("touched a powerup");
            TorpedoPowerUp();
            print("starting torpedo boost");
            Destroy(powerupCollision2D.gameObject);
            print("destroyed powerup");
        }

        if (powerupCollision2D.gameObject.name == "playerPowerUpHeal")
        {
            Debug.Log("touched a powerup");
            RepairPowerUp();
            print("starting repair function");
            Destroy(powerupCollision2D.gameObject);
            print("destroyed powerup");
        }
    }

    private IEnumerator ReloadPowerUp()
    {
        getReloadTimeA.playerArtilleryReload = false;
        getReloadTimeB.playerArtilleryReload = false;
        getReloadTimeX.playerArtilleryReload = false;
        print("cleared reload status");
        getReloadTimeA.playerReloadTime = 2;
        getReloadTimeB.playerReloadTime = 2;
        getReloadTimeX.playerReloadTime = 2;
        print("set reload to 2s");
        yield return new WaitForSeconds(15);
        getReloadTimeA.playerReloadTime = 4;
        getReloadTimeB.playerReloadTime = 4;
        getReloadTimeX.playerReloadTime = 4;
        print("player reload returned to normal");
    }

    public void TorpedoPowerUp()
    {
        StopCoroutine(getTorpedoCount.playerTorpedoReloadFunc());
        print("canceled current reload function");
        getTorpedoCount.playerTorpedoCount = 4;
        getTorpedoCount.uiShipTorpedoStatus.text = ("Torpedo Tubes " + getTorpedoCount.playerTorpedoCount + " Ready");
        print("fully reloaded torpedo tube");
    }

    public void RepairPowerUp()
    {
        for (int repairTick = 4; repairTick > 0; repairTick--)
        {
            getPlayerHP.playerShipIntegrity += 100;
            print("added 100 to player HP");
        }
    }
}
