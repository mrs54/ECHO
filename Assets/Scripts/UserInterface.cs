using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UserInterface : MonoBehaviour
{
    public Image buttonImage;
    public Sprite[] sprites;
    private int currentSprite;
    private bool startedAudio;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (startedAudio && !transform.GetChild(0).GetComponent<AudioSource>().isPlaying)
        {
            SceneManager.LoadScene(1);
        }
    }

    public void ChangeImage()
    {
        currentSprite++;
        if (currentSprite > 1)
        {
            currentSprite = 0;
        }
        buttonImage.sprite = sprites[currentSprite];
    }

    public void StartGame()
    {
        if (!startedAudio)
        {
            transform.GetChild(0).GetComponent<AudioSource>().Play();
            startedAudio = true;
        }
    }
}
