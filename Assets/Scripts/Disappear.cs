using UnityEngine;
using System.Collections;

public class Disappear : MonoBehaviour
{
    public GameObject objectToDisappear;
    public bool invisible;
    private bool change;
    public float timeBetweenDisappears;
    private float timeBetweenDisappearsStore;
    public float disappearTime;
    private float disappearTimeStore;
    public float delayTime = 0.0f;
    // Use this for initialization
    void Start()
    {
        change = true;
        timeBetweenDisappearsStore = timeBetweenDisappears;
        disappearTimeStore = disappearTime;
        timeBetweenDisappears += delayTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (invisible)
        {
            if (timeBetweenDisappears <= 0.0f)
            {
                change = true;
                timeBetweenDisappears = timeBetweenDisappearsStore;
            }
            timeBetweenDisappears -= Time.deltaTime;
            if (change)
            {
                objectToDisappear.SetActive(false);
                invisible = false;
                change = false;
            }
        }
        else
        {
            if (disappearTime <= 0.0f)
            {
                change = true;
                disappearTime = disappearTimeStore;
            }
            disappearTime -= Time.deltaTime;
            if (change)
            {
                objectToDisappear.SetActive(true);
                invisible = true;
                change = false;
            }
        }
    }
}