using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OurRayCaster : MonoBehaviour {

	public float raycastRange;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("space")) {
			Debug.Log("Start Raycast");
			//this casts the raycast
			RaycastHit hit;
			bool didHit = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, raycastRange);
			Debug.Log("i hit:" + didHit);
			if(didHit) {
				Clickable clicked = hit.transform.gameObject.GetComponent<Clickable>();
				if(clicked != null) {
					//we hit a clickable!
					clicked.onClick();
					Debug.Log("onClick");
				}
			}
        }
	}
}
