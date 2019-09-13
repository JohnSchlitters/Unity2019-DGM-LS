using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class ShipIntegrity : MonoBehaviour
{
    public int playerShipIntegrity = 1;

    public int playerMaxShipIntegrity = 1;
    public int playerArmor = 1;
    public int playerMaxArmor = 1;
    // Start is called before the first frame update
    void Start()
    {
        playerShipIntegrity = 1000;
        playerMaxShipIntegrity = 1000;
        playerArmor = 0;
        playerMaxArmor = 500;
        print("starting ship HP tracking");
    }

    // Update is called once per frame
    void Update()
    {
        if (playerShipIntegrity <= 0)
        {
            PlayerSunk();
            print("player has been sunk");
        }

        if (playerShipIntegrity > playerMaxShipIntegrity)
        {
            if (playerArmor < playerMaxArmor)
            {
                playerArmor = playerMaxArmor + (playerShipIntegrity - playerMaxShipIntegrity);
                print("player armor set to " + playerArmor);
            }
            else
            {
                playerArmor = playerMaxArmor;
                print("player armor set to " + playerArmor);
            }

            playerShipIntegrity = playerMaxShipIntegrity;
        }
        else if (playerShipIntegrity <= playerMaxShipIntegrity)
        {
            print("player integrity at " + playerShipIntegrity);
        }
    }

    void PlayerSunk()
    {
        Destroy(this.gameObject);
        
    }
}
