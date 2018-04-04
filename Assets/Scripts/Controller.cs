using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour
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
    void Start()
    {

    }

    void Update()
    {
        /* Basic input logic. GetKey is grabbing
		 * the keycodes we created in our Game Manager
		 */
        //if(Input.GetKey(GameManager.GM.forward))
        //	transform.position += Vector3.forward / 2;
        //if( Input.GetKey(GameManager.GM.backward))
        //	transform.position += -Vector3.forward / 2;
        //if( Input.GetKey(GameManager.GM.left))
        //	transform.position += Vector3.left / 2;
        //if( Input.GetKey(GameManager.GM.right))
        //	transform.position += Vector3.right / 2;
        if (!dying)
        {
            velocity = new Vector3(Input.GetAxis(horizontalButton), Input.GetAxis(verticalButton), 0.0f) * moveSpeed;
            if (Input.GetKeyDown(GameManager.GM.echo) && (Time.time - fireTimer) >= fireRate)
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
}
