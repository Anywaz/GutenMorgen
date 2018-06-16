using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour, Clickable {
    private bool open;
    public void onClick()
    {
        //TODO: Open/Close Animation
        open = !open;
    }

    // Use this for initialization
    void Start () {
        open = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
