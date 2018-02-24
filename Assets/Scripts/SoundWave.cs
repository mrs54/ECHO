using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundWave : MonoBehaviour
{
    public float liveTime;
    public float maxRange;

    private bool stopMoving;
    private bool reduceLight;
    private float liveTimer;
    private float reduceLightTimer;
    private float reduceTime = 1.0f;

    // Use this for initialization
    void Start()
    {
        liveTimer = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (!stopMoving)
        {
            if (GetComponent<BirdSpit>() == null)
            {
                GetComponent<Rigidbody2D>().MovePosition(transform.position + transform.right * 0.2f);
            }
        }
        else
        {
            if (GetComponent<Light>().range < maxRange && !reduceLight)
            {
                GetComponent<Light>().range += Time.deltaTime * 10.0f;
            }
            else
            {
                if (reduceLight == false)
                {
                    reduceLightTimer = Time.time;
                }
                reduceLight = true;

                if (Time.time - reduceLightTimer >= reduceTime)
                {
                    if (GetComponent<Light>().range > 0)
                    {
                        GetComponent<Light>().range -= Time.deltaTime * 2.0f;
                    }
                    else
                    {
                        Destroy(gameObject);
                    }
                }
            }
        }
        if (Time.time - liveTimer >= liveTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Light>().enabled = true;
            transform.position = new Vector3(transform.position.x, transform.position.y, 0.5f);
            stopMoving = true;
        }
    }

    public bool IsStopped()
    {
        return stopMoving;
    }
}
