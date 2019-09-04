using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrack : MonoBehaviour
{
    public Vector3 shipPosition;

    public Transform trackTarget;
    // Start is called before the first frame update
    void Start()
    {
        print("Tracking Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = trackTarget.position + shipPosition;
    }
}

//https://forum.unity.com/threads/making-camera-follow-an-object.32831/
