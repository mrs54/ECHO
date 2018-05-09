using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundWave : MonoBehaviour
{
    public float liveTime;
    public float maxRange;
    private Animator animator;
    private bool stopMoving;
    private bool reduceLight;
    private float liveTimer;
    private float reduceLightTimer;
    private float reduceTime = 1.0f;
    public float moveSpeed;
    public bool usesGravity;
    private SpriteRenderer echoSpriteRenderer;
    private bool hasFlipped = false;
    private bool mfacingRight = false;
    private bool startedAudio;
    public List<AudioClip> squeaks;
    private AudioSource audioSrc;

    private float direction = 1f;
    // Use this for initialization
    
    protected void Start()
    {
        liveTimer = Time.time;
        audioSrc = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();

        echoSpriteRenderer = GetComponent<SpriteRenderer>();

        GameObject soundwave = GameObject.Find("SoundWave");

        if (!GameObject.Find("Player").GetComponent<Player>().facingRight)
        {
            mfacingRight = true;
            direction = -1;
                echoSpriteRenderer.flipX = true;
        }
        GetComponent<Rigidbody2D>().MovePosition(transform.position + transform.right * Time.deltaTime * moveSpeed * direction + 
            (usesGravity ? .15f * Physics.gravity * Time.deltaTime : Vector3.zero));

    }

    // Update is called once per frame
    protected void Update()
    {
        if (!stopMoving)
        {

            GetComponent<Rigidbody2D>().MovePosition(transform.position + transform.right * Time.deltaTime * moveSpeed * direction + (usesGravity ?.15f* Physics.gravity * Time.deltaTime:Vector3.zero));


            //if (!GameObject.Find("Player").GetComponent <Player> ().facingRight)
            //{
            //    GetComponent<Rigidbody2D>().MovePosition(transform.position + transform.right * Time.deltaTime * -moveSpeed + (usesGravity ? .15f * Physics.gravity * Time.deltaTime : Vector3.zero));
            //    echoSpriteRenderer.flipX = true;

            //    hasFlipped = true;

            //    if (hasFlipped)
            //        {
            //            Debug.Log("BAHAAAA");
            //            hasFlipped = false;
            //        }
            //}
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
        //new
        if (!startedAudio && audioSrc != null)
        {
            audioSrc.clip = squeaks[Random.Range(0, squeaks.Count)];
            audioSrc.Play();
            startedAudio = true;
        }
    }
    public void Die()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        animator.StopPlayback();
        StartCoroutine(delayeddeath());
    }
    IEnumerator delayeddeath()
    {
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            if (audioSrc != null)
                audioSrc.Stop();
            GetComponent<Light>().enabled = true;
            transform.position = new Vector3(transform.position.x, transform.position.y, 0.5f);
            stopMoving = true;
            if(animator != null)
                animator.SetTrigger("impacting");

        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Border"))
        {
            if (audioSrc != null)
                audioSrc.Stop();
            GetComponent<Light>().enabled = true;
            transform.position = new Vector3(transform.position.x, transform.position.y, 0.5f);
            stopMoving = true;
            if (animator != null)
                animator.SetTrigger("impacting");

        }

    }

    public bool IsStopped()
    {
        return stopMoving;
    }
}
