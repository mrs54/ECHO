using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFollow : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    void Update()
    {
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,10f));

    }
}
