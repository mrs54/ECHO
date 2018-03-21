using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class munch : MonoBehaviour
{

    public AudioSource SoundSource;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            SoundSource.Play();
            
        }
    }
}
