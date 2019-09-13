using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class enemyDDController : MonoBehaviour
{
    public int enemyShipIntegrity = 0;

    public enemyHP getHPValue;
    public int powerUpDrop = 0;

    public GameObject playerPowerUpReload;

    public GameObject playerPowerUpTorpedo;
    public GameObject playerPowerUpHeal;

    // Start is called before the first frame update
    void Start()
    {
        // playerPowerupReload = GetComponent<GameObject>;
        enemyShipIntegrity = getHPValue.enemyDDStartHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyShipIntegrity <= 0)
        {
            powerUpDrop = Random.Range(1,10);
            Sunk();
        }


    }

    private void OnCollisionEnter2D(Collision2D playerAttackCollision2D)
    {
        if (playerAttackCollision2D.gameObject.name == "launchedPlayerTorp")
        {
            print("enemy hit with torpedo");
            Destroy(playerAttackCollision2D.gameObject);
            enemyShipIntegrity -= 400;
            print("enemy ship hp at " + enemyShipIntegrity);
        }

        if (playerAttackCollision2D.gameObject.name == "firedPlayerShell")
        {
            print("enemy hit with shell");
            Destroy(playerAttackCollision2D.gameObject);
            enemyShipIntegrity -= 50;
            print("enemy ship hp at " + enemyShipIntegrity);
        }
    }

    void Sunk()
    {
        switch (powerUpDrop)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                    Instantiate(playerPowerUpHeal, transform.position, Quaternion.identity);
                    print("dropped player heal");
                    break;
                case 8:
                case 9:
                    Instantiate(playerPowerUpReload, transform.position, Quaternion.identity);
                    print("dropped gun reload");
                    break;
                case 10:
                    Instantiate(playerPowerUpTorpedo, transform.position, Quaternion.identity);
                    print("dropped torpedo reload");
                    break;
            }
            Destroy(this.gameObject);
            print("removed enemy ship due to sinking");
        }
    }

