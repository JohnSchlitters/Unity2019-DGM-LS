using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detonateAfterTime : MonoBehaviour
{
    // Start is called before the first frame update
    void DestroyObjectDelay()
    {
        Destroy(gameObject, 30);
        print("A torpedo ran out of fuel");
    }
}
