using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

    public GameObject thePlatform;
    public Transform generationPoint;
    public float distanceBetween;
    private float platformWidth;

   public float distanceBetweenMin;
   public float distanceBetweenMax;

    public GameObject[] thePlatforms;
    private int platformSelector;

    // Use this for initialization
    void Start () {
        platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x < generationPoint.position.x)
        {
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);

            transform.position = new Vector3(transform.position.x + platformWidth + distanceBetween, transform.position.y, transform.position.z);

            platformSelector = Random.Range(0, thePlatforms.Length);

            Instantiate(/*thePlatform,*/ thePlatforms[platformSelector], transform.position, transform.rotation);
        }
	}
}
