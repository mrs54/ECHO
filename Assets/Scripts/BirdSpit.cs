using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpit : MonoBehaviour
{
    public float moveSpeed;
    private Vector3 direction;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        if (!(GetComponent<SoundWave>().IsStopped()))
        {
            GetComponent<Rigidbody2D>().MovePosition(transform.position + direction * moveSpeed);
        }
    }

    public void SetDirection(Vector3 dir)
    {
        direction = dir;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!(GetComponent<SoundWave>().IsStopped()))
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                collision.gameObject.GetComponent<Player>().Die();
            }
        }
    }
}
