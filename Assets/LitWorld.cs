using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[ExecuteInEditMode]
[RequireComponent(typeof(Image))]
public class LitWorld : MonoBehaviour {
    Material material;
    Image image;
    public Camera camera;

	// Use this for initialization
	void Start () {
        image = GetComponent<Image>();
        material = Instantiate<Material>(image.material);
        material.mainTexture = camera.targetTexture;
        if (camera.targetTexture==null)
        {
            Debug.Log("Target Texture is missing");
        }
        if (camera.targetTexture == material.mainTexture)
        {
            Debug.Log("Success");
        }
        image.material = material;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
