using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checklist : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnEnable()
    {
        Debug.Log("This is in enable, we are enabled!");
    }

    private void OnDisable()
    {
        Debug.Log("This is in disable, we were disabled :(");
    }
}
