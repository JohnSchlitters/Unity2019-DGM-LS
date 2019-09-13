using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class splashAfterTime : MonoBehaviour
{
    // Start is called before the first frame update
    public void Start()
    {
        StartCoroutine(artillerySplashDown());

    }

    public IEnumerator artillerySplashDown()
    {
        yield return new WaitForSeconds(10f);
        Destroy(this.gameObject);
        print("A shell has hit the water");
    }
}