using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public Vector3 direction;
    public float moveSpeed;
    public float targetOffset;
    private Vector3 targetPosition;
    private bool activated;
    private float startTime;
    private float totalJourneyLength;

    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (activated)
        {
            float distCovered = (Time.time - startTime) * moveSpeed;
            float distRemaining = distCovered / totalJourneyLength;
            transform.position = Vector3.Lerp(transform.position, targetPosition, distRemaining);
        }
    }

    public void Activate()
    {
        activated = true;
        startTime = Time.time;
        targetPosition = transform.position + direction * targetOffset;
        totalJourneyLength = Vector3.Distance(targetPosition, transform.position);
    }
}
