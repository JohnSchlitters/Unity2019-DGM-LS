using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class playerReloadBooster : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision2D col)
    {
        if (col.gameObject.name == "player_shipLaforey")
        {
            Destroy(col.gameObject);
        }
            
    }
}
