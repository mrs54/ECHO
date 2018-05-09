using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Vector3 direction;
    public float moveSpeed;
    public List<GameObject> nodes;

    private Vector3 currentDirection;

    // Use this for initialization
    void Start()
    {
        currentDirection = direction;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = currentDirection * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (nodes.Contains(collision.gameObject))
        {
            currentDirection = -currentDirection;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Crusher"))
        {
            currentDirection = -currentDirection;
        }
    }
}