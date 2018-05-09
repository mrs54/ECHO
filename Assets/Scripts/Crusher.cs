using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crusher : MonoBehaviour
{

    private bool crushed;
    public Vector3 direction;
    public float moveSpeed;
    private Vector3 startPosition;
    private bool falling;
    private Animator animator;

    private Vector3 currentDirection;
    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetTrigger("Rise");
        currentDirection = direction;
        startPosition = transform.position;
        falling = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (falling && transform.position.y < startPosition.y)
        {
            currentDirection = -currentDirection;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            animator.SetTrigger("Rise");
            falling = false;
        }
    }
    public void Rise()
    {
        
        GetComponent<Rigidbody2D>().velocity = currentDirection * moveSpeed;
        Debug.Log("BANG");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.transform.name + " "+LayerMask.LayerToName(collision.gameObject.layer));
        if (collision.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            falling = true;
            currentDirection = -currentDirection;
            GetComponent<Rigidbody2D>().velocity = currentDirection * moveSpeed;
        }

        //if (collision.gameObject.layer == LayerMask.NameToLayer("Halt"))
        //{
        //    crushed = false;
        //}
    }
}
