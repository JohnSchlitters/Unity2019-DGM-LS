using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAAScript : MonoBehaviour
{
    private float playerAACycleTime = 1.5f;
    private float playerAAMaxDistance = 25f;
    public float enemyTargetDistance;
    public Transform enemyTarget;


    [SerializeField] public Transform aaGunBarrel;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //public transform enemyTarget = GameObject.FindWithTag("EnemyPlane");
       //  enemyTarget = gameObject();
        enemyTargetDistance = Vector3.Distance(enemyTarget.transform.position, aaGunBarrel.transform.position);

        if (enemyTargetDistance < playerAAMaxDistance)
        {
            TrackTarget();
        }
    }

    private void TrackTarget()
    {

    }
}
    
    
