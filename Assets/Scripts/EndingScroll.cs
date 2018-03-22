using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingScroll : MonoBehaviour
{
    public GameObject batSprite;
    public GameObject image;
    public GameObject names;
    public float scrollSpeed;

    private bool play;
    // Use this for initialization

    public IEnumerator Run()
    {
        yield return new WaitForSeconds(14f);
        Debug.Log("DEAD");
        Application.Quit();
    }

    void Start()
    {
        play = true;
        StartCoroutine(Run());
    }

    // Update is called once per frame
    void Update()
    {
        if (play)
        {
            if (batSprite.transform.position.y > 0)
            {
                batSprite.transform.Translate(Vector3.down * scrollSpeed);
            }
            if (image.transform.position.y > -800)
            {
                image.transform.Translate(Vector3.down * scrollSpeed);
            }
            if (names.transform.position.y > -800)
            {
                names.transform.Translate(Vector3.down * scrollSpeed);
            }
        }
    }

    public void PlayIt()
    {
        play = true;
    }
    
    
}
