using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class ShipMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        print("Starting Ship Movement");
    }

    public int shipgear = 1; //this will control how fast the ship moves, allowing player to maneuver better

 //   public int shipspeed = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) //increase speed
            if (shipgear == 5)
            {
                print("Failure to Reach Higher Gear : Already at FLK Speed");
            }
            else
            {
                shipgear += 1;
                print("Increasing Ship Gear");
            }

        if (Input.GetKeyDown(KeyCode.S)) //decrease speed
            if (shipgear == 0)
            {
                print("Failure to Reach Lower Gear : Already in Reverse");
            }
            else
            {
                shipgear -= 1;
            }

        if (shipgear == 0)
        {
            transform.Translate(Vector3.down * Time.deltaTime * 1);
            print("Ship Full Reverse");
        }

        if (shipgear == 1)
        {
            transform.Translate(Vector3.up * Time.deltaTime * 0);
            print("Ship Full Stop");
        }

        if (shipgear == 2)
        {
            transform.Translate(Vector3.up * Time.deltaTime * (float) 1.5);
            print("Ship 1/4 Speed Ahead");
        }

        if (shipgear == 3)
        {
            transform.Translate(Vector3.up * Time.deltaTime * 3);
            print("Ship 1/2 Speed Ahead");
        }

        if (shipgear == 4)
        {
            transform.Translate(Vector3.up * Time.deltaTime * (float) 4.5);
            print("Ship 3/4 Speed Ahead");
        }

        if (shipgear == 5)
        {
            transform.Translate(Vector3.up * Time.deltaTime * 6);
            print("Ship Flank Ahead");
        }

        if (shipgear > 5)
        {
            shipgear = 5;
        }

        if (Input.GetKey(KeyCode.A))
        {
            if (shipgear == 1)
            {
                transform.Rotate(Vector3.forward * Time.deltaTime * 0); //stationary ship cannot turn
            }
            if (shipgear == 2 || shipgear == 3)
            {
                transform.Rotate(Vector3.forward * Time.deltaTime * 6); //turn left, slightly faster
            }
            if (shipgear == 4 || shipgear == 5)
            {
                transform.Rotate(Vector3.forward * Time.deltaTime * 4); //turn left
            }
            if (shipgear == 0)
            {
                transform.Rotate(Vector3.back * Time.deltaTime * 2); //turn right, ship is in reverse
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (shipgear == 1)
            {
                transform.Rotate(Vector3.back * Time.deltaTime * 0); //stationary ship cannot turn
            }
            if (shipgear == 2 || shipgear == 3)
            {
                transform.Rotate(Vector3.back * Time.deltaTime * 6); //turn right, slightly faster
            }
            if (shipgear == 4 || shipgear == 5)
            {
                transform.Rotate(Vector3.back * Time.deltaTime * 4); //turn right
            }
            if (shipgear == 0)
            {
                transform.Rotate(Vector3.forward * Time.deltaTime * 2); //turn left, ship is in reverse
            }
        }
    }

 /*   void OnCollisionEnter(Collision targetObj) //trying to measure collision with an object
    {
        if (targetObj.gameObject.tag == "Islands")
        {
             transform.Translate(Vector3.up * Time.deltaTime * 0);
             print("Collided with an object");
        }
    } */
}

//largely compiled from information on unity reference documents for moving an object and taking a key press, works well
//enough for the needs