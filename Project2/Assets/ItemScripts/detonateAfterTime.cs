﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detonateAfterTime : MonoBehaviour
{
    // Start is called before the first frame update
    public void Start()
    {
        StartCoroutine(torpedoFuelTimeout());

    }

    public IEnumerator torpedoFuelTimeout()
    {
        yield return new WaitForSeconds(30f);
        Destroy(this.gameObject);
        print("A torpedo ran out of fuel");
    }
}
