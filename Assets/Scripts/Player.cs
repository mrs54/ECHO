using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject soundWave;
    public float moveSpeed;
    public float fireRate;
    public float forwardOffset;
    public float upOffset;

    private bool dying;
    private Vector3 velocity;
    private float fireTimer;
    private int currentScene;

    public float timer;
    private bool starttimer = false;

    public string screamButton = "Fire1_P1";
    public string horizontalButton = "Horizontal_P1";
    public string verticalButton = "Vertical_P1";

    public AudioClip SoundClip;

    public AudioSource SoundSource;

    public Camera cameraa;
    public Camera camerab;


    // Use this for initialization
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        SoundSource.clip = SoundClip;
        cameraa.enabled = true;
        camerab.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -7)
        {
            starttimer = true;

            if (starttimer)
            {
                timer -= 1.0f * Time.deltaTime;

                if (timer <= 0.0f)
                {

                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //Makes player respawn if they fall below map
                    starttimer = false;

                }
            }
            
        }
        velocity = Vector3.zero;
        Cursor.lockState = CursorLockMode.Locked; //locks cursor in death
        if (!dying)
        {
            velocity = new Vector3(Input.GetAxis(horizontalButton), Input.GetAxis(verticalButton), 0.0f) * moveSpeed;

            if (Input.GetButtonDown(screamButton) && (Time.time - fireTimer) >= fireRate)
            {
                GetComponent<Animator>().SetBool("Scream", true);
                Instantiate(soundWave,
                    transform.position + (transform.right * forwardOffset) + (transform.up * upOffset),
                    Quaternion.identity);
                fireTimer = Time.time;
            }
            else
            {
                GetComponent<Animator>().SetBool("Scream", false);
            }
        }
    }

    private void FixedUpdate()
    {
        if (!dying)
        {
            GetComponent<Rigidbody2D>().velocity = velocity;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            if (collision.transform.position.x < transform.position.x)
            {
                transform.right = Vector3.left;
            }

            Die();

            cameraa.enabled = false;
            camerab.enabled = true;
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Net"))
        {
            GetComponent<Rigidbody2D>().gravityScale = 0f;
            GetComponent<Collider2D>().enabled = true;
            Debug.Log("cAUGHT EM");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Fruit"))
        {
            collision.gameObject.GetComponent<Animator>().SetBool("Nom", true);
        }
    }
    
    public void Die()
    {
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        GetComponent<Animator>().SetBool("Dead", true);
        dying = true;
        GetComponent<Rigidbody2D>().gravityScale = 1.0f;
        GetComponent<Collider2D>().enabled = false;
        SoundSource.Play();

        
    }
}
