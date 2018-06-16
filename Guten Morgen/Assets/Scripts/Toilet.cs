using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toilet : MonoBehaviour, Clickable {
    private bool clicked;
    public void onClick()
    {
        if (!clicked) //TODO: Play Sound?
            ;
        else //TODO: Open/Go to toilet
            ;
        
    }

    // Use this for initialization
    void Start () {
        clicked = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
