using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class Spotlight : MonoBehaviour {
    public Camera camera;
    public Material material;
	// Use this for initialization
	void Start () {
        material.SetTexture("_LitTex", camera.targetTexture);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
