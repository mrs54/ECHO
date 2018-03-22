using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;




public class OptionMenu : MonoBehaviour {

    private Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();

    public Text scream;

    private GameObject currentKey;

    private Color32 normal = new Color32(39, 171, 249, 255);
    private Color32 selected = new Color32(239, 116, 36, 255);

	// Use this for initialization
	void Start () {
        keys.Add("Echo", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Echo","Mouse0")));

        scream.text = keys["Echo"].ToString();

	}
	
	// Update is called once per frame
	void Update ()
        {

        if (Input.GetKeyDown(keys["Echo"]))
        {
            Debug.Log("AAAAAAAA");
        }

        }

    public void ChangeKey(GameObject clicked)
    {
        if (currentKey != null)
        {
            currentKey.GetComponent<Image>().color = normal;
        }

        currentKey = clicked;
        currentKey.GetComponent<Image>().color = selected;

    }
    void OnGUI()
    {
        if (currentKey != null)
        {
            Event e = Event.current;
            if (e.isKey)
            {
                keys[currentKey.name] = e.keyCode;
                currentKey.transform.GetChild(0).GetComponent<Text>().text = e.keyCode.ToString();
                currentKey.GetComponent<Image>().color = normal;
                currentKey = null;
            }
        }
    }

    public void SaveKeys()
    {
        foreach (var key in keys)
        {
            PlayerPrefs.SetString(key.Key, key.Value.ToString());

        }
        Debug.Log("Saved Game");
        PlayerPrefs.Save();
    }

    public void LetsMove()
    {
        Application.LoadLevel("mainMenu");

    }
}

