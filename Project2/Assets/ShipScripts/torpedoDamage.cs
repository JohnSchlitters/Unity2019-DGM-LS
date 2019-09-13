using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class torpedoDamage : MonoBehaviour
{
    public enemyDDController enemyHP;
    private int playerTorpedoDamage = 400;
    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D enemyCollide2D)
    {
        if (enemyCollide2D.gameObject.CompareTag("EnemyShip"))
        {
            enemyHP.enemyShipIntegrity = enemyHP.enemyShipIntegrity -= 400;
            print("enemy took 400 damage");
            Destroy(this.gameObject);
            print("removed torpedo");
        }
    }
}
