using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PourMeSome : MonoBehaviour, Clickable {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void onClick() {
		this.GetComponent<Animator>().Play("PourCoffee");
	}
}
