using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipInfoHPArmor : MonoBehaviour
{
    public Text uiPlayerArmor;

    public Text uiPlayerShipIntegrity;

    public ShipIntegrity getPlayerHP;

    public ShipIntegrity getPlayerArmor;
    // Start is called before the first frame update
    void Start()
    {
        print("starting player HP tracking");
    }

    // Update is called once per frame
    void Update()
    {
        uiPlayerArmor.text = getPlayerArmor.playerArmor + ": Ship Armor";
        uiPlayerShipIntegrity.text = getPlayerArmor.playerShipIntegrity + ": Ship Integrity";
    }
}
