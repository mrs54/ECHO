using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwlPole : MonoBehaviour
{
    public float fireRate;
    public GameObject birdSpit;
    public Transform[] spitPoints;

    private float fireTimer;
    private int currentSpitPoint;
    private bool shot;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if ((GetComponent<SpriteRenderer>().sprite.name == "OVO spreadsheet_16" && !shot))
        {
            shot = true;
            if (GetComponent<SpriteRenderer>().sprite.name == "OVO spreadsheet (1)_16")
            {
                currentSpitPoint = 0;
            }
            else if (GetComponent<SpriteRenderer>().sprite.name == "OVO spreadsheet (1)_21")
            {
                currentSpitPoint = 1;
            }
            GameObject spit = Instantiate(birdSpit, spitPoints[currentSpitPoint].position, spitPoints[currentSpitPoint].rotation);
            if (GetComponent<SpriteRenderer>().flipX)
            {
                spit.GetComponent<BirdSpit>().SetDirection(transform.right);
            }
            else
            {
                spit.GetComponent<BirdSpit>().SetDirection(-transform.right);
            }
        }

        if (GetComponent<SpriteRenderer>().sprite.name == "OVO spreadsheet_1")
        {
            shot = false;
        }
    }
}
