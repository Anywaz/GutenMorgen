using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuiceGlass : MonoBehaviour, Clickable {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.parent != null) {
			CharacterController chara = transform.parent.gameObject.GetComponent<CharacterController>();
		}
	} 

	public void onClick() {
		transform.SetParent(gameObject.FindWithTag("Player"));
		
	}
}
