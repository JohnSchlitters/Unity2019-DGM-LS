using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ShipInfoSpeed : MonoBehaviour
{
    public Text uiShipText;


    public ShipMovement getShipGear;
    // Start is called before the first frame update
    void Start()

    {
        print("Initializing UI Text");
        uiShipText.text = "Ship Speed : Full Stop";
    }

    // Update is called once per frame
    private void Update()
    {
        if (getShipGear.shipgear == 0)
        {
            uiShipText.text = "Ship Speed - Full Rvrs";           
        }
        if (getShipGear.shipgear == 1)
        {
            uiShipText.text = "Ship Speed - Full Stop";           
        }
        if (getShipGear.shipgear == 2)
        {
            uiShipText.text = "Ship Speed - 1/4 Ahead";           
        }
        if (getShipGear.shipgear == 3)
        {
            uiShipText.text = "Ship Speed - 1/2 Ahead";           
        }
        if (getShipGear.shipgear == 4)
        {
            uiShipText.text = "Ship Speed - 3/4 Ahead";           
        }
        if (getShipGear.shipgear == 5)
        {
            uiShipText.text = "Ship Speed - Flnk Ahead";           
        }
    }
}
