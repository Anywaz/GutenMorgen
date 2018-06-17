using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

    public Button startButton;
    public Button quitButton;
    private bool quit;

    // Use this for initialization
    void Start () {
        quit = false;
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void StartHover()
    {
        Text text = startButton.transform.GetChild(0).GetComponent<Text>();
        text.color = new Color(1, 1, 1, 1);
    }

    public void QuitHover()
    {
        if (!quit)
        {
            Text text = quitButton.transform.GetChild(0).GetComponent<Text>();
            text.color = new Color(1, 1, 1, 1);
        }
    }

    public void StartUnhover()
    {
        Text text = startButton.transform.GetChild(0).GetComponent<Text>();
        text.color = new Color(.2f, .2f, .2f, 1);
    }

    public void QuitUnhover()
    {
        if (!quit)
        {
            Text text = quitButton.transform.GetChild(0).GetComponent<Text>();
            text.color = new Color(.2f, .2f, .2f, 1);
        }
    }

    public void StartOnClick()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitOnClick()
    {
        quit = true;
        Text text = quitButton.transform.GetChild(0).GetComponent<Text>();
        text.color = new Color(0, 0, 0, 0);
    }
}
