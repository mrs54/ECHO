using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    private Animator animator;
    public GameObject door;
    // Use this for initialization
    public AudioSource SoundSource;
    public AudioClip SoundClip;

    private bool hasPlayed = false;

    void Start()
    {
        SoundSource.clip = SoundClip;

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Sonar"))
        {
            GetComponent<Animator>().SetBool("Activated", true);
            door.GetComponent<DoorScript>().Activate();
            //SoundSource.Play();
            if (!hasPlayed)
            {
                SoundSource.PlayOneShot(SoundClip);
                hasPlayed = true;
            }
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
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}