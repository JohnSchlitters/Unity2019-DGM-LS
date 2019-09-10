using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipIntegrity : MonoBehaviour
{
    public int playerShipIntegrity = 1000;
    // Start is called before the first frame update
    void Start()
    {
        print("starting ship HP tracking");
    }

    // Update is called once per frame
    void Update()
    {
        if (playerShipIntegrity > 0)
        {
            
        }
        else
        {
  //          Destroy(gameObject.name == "player_ShipLaforey");
        }
    }
}
