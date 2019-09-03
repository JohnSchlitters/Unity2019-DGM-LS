using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MainGunTracking : MonoBehaviour
{
    void Update()
    {
        //rotation of object
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 5.23f;

        Vector3 objectPosition = Camera.main.WorldToScreenPoint(transform.position);
        mousePosition.x = mousePosition.x - objectPosition.x;
        mousePosition.y = mousePosition.y - objectPosition.y;
        float angle = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        //https://answers.unity.com/questions/10615/rotate-objectweapon-towards-mouse-cursor-2d.html
    }
}