using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpit : SoundWave
{
    public AudioClip SoundClip;

    public AudioSource SoundSource;

    private Vector3 direction;

    // Use this for initialization
    new void Start()
    {
        base.Start();
        SoundSource.clip = SoundClip;
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
    }

    public void SetDirection(Vector3 dir)
    {
        direction = dir;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        SoundSource.Play();
        Debug.Log("Sound has played");
        if (!(GetComponent<SoundWave>().IsStopped()))
        {
          

            if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                collision.gameObject.GetComponent<Player>().Die();
            }

           

        }
        Destroy(gameObject, 5);
    }
}
