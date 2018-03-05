using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
//Unity will now add camera component to object  if this script is used.
public class RenderTex : MonoBehaviour {
    Camera camera;
    public Shader shader;
	// Use this for initialization
	void Awake () {
        camera = GetComponent<Camera>();
        //camera.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        camera.SetReplacementShader(shader, null);
    }
	
	// Update is called once per frame
	void Update () {
        
	}
}
