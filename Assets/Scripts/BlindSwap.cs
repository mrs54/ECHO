using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlindSwap : MonoBehaviour
{

    public Camera camera1;
    public Camera camera2;

    void Start()
    {
        camera1.enabled = true;
        camera2.enabled = false;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.V) && camera1.enabled == true)
        {
            camera1.enabled = false;
            camera2.enabled = true;
        }
        else if (Input.GetKeyDown(KeyCode.V) && (camera2.enabled == true))
        {
            camera1.enabled = true;
            camera2.enabled = false;
        }
    }
}