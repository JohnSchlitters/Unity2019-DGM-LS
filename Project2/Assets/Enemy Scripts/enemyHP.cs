using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHP : MonoBehaviour
{
    public int enemyDDMaxHealth = 1200;

    public int enemyDDStartHealth = 1200;

    public int enemyTorpBoatStartHealth = 400;

    public int enemyAirplaneAStartHealth = 150;
    // Start is called before the first frame update
    void Start()
    {
        print("starting enemy HP");
    }
}
