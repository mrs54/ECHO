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
    private SpriteRenderer mySpriteRenderer;

    public float timer;
    private bool starttimer = false;
    private bool mute = false;
    private bool stop = false;
    public bool facingRight=true;
    public string screamButton = "Fire1_P1";
    public string horizontalButton = "Horizontal_P1";
    public string verticalButton = "Vertical_P1";

    public AudioClip SoundClip;

    public AudioSource SoundSource;

    public Camera cameraa;
    public Camera camerab;

    KeyCode echoForth = KeyCode.Mouse0;
    // Use this for initialization
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        if (SoundSource)
        {
            SoundSource.clip = SoundClip;
        }
       
        cameraa.enabled = true;
        camerab.enabled = false;

        mySpriteRenderer = GetComponent<SpriteRenderer>();

        
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
            if(!stop)
            velocity = new Vector3(Input.GetAxis(horizontalButton), Input.GetAxis(verticalButton), 0.0f) * moveSpeed;

            if (velocity.x < -3)
            {
                facingRight = false;
                mySpriteRenderer.flipX = true;
                
            }
            else if(velocity.x > 3)
            {
                facingRight = true;
                mySpriteRenderer.flipX = false;
                

            }

            if (Input.GetButtonDown(screamButton) && (Time.time - fireTimer) >= fireRate)
            {
                GetComponent<Animator>().SetBool("Scream", true);
                float direction = facingRight ? 1f : -1f;

                if (!mute)
                    Instantiate(soundWave,
                    transform.position + (transform.right * forwardOffset * direction) + (transform.up * upOffset),
                    Quaternion.identity);


                fireTimer = Time.time;

            }

            


            //}
            else if (Manager.GM && Input.GetKeyDown(Manager.GM.echo) && (Time.time - fireTimer) >= fireRate)
            {
                GetComponent<Animator>().SetBool("Scream", true);
                if (!mute)
                    Instantiate(soundWave,
                    transform.position + (transform.right * forwardOffset) + (transform.up * upOffset),
                    Quaternion.identity);
                fireTimer = Time.time;
            }
            else
            {
                GetComponent<Animator>().SetBool("Scream", false);
            }
            if (Input.GetButtonDown("/"))
            {
                SceneManager.LoadScene("modeChoose");
                
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
        if (collision.gameObject.layer == LayerMask.NameToLayer("Obstacle") || collision.gameObject.layer == LayerMask.NameToLayer("Crusher") || collision.gameObject.layer == LayerMask.NameToLayer("Spikes"))
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
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Fruit"))
        {
            collision.gameObject.GetComponent<Animator>().SetBool("Nom", true);
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Nozone"))
        {
            mute = true;
            collision.gameObject.GetComponent<Animator>().SetBool("Scream", false);
            Debug.Log("NO SCREEM");
        }
        Debug.Log("SCREEM");

        if (collision.gameObject.layer == LayerMask.NameToLayer("Redlight"))
        {
            stop = true;
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Nozone"))
        {
            mute = false;

        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Redlight"))
        {
            stop = false;
            GetComponent<Rigidbody2D>().velocity = velocity;
        }

    }
    public void Die()
    {
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        GetComponent<Animator>().SetBool("Dead", true);
        dying = true;
        GetComponent<Rigidbody2D>().gravityScale = 1.0f;
        GetComponent<Collider2D>().enabled = false;

        if (SoundSource)
        {
            SoundSource.Play();
        }
        
    }

}
