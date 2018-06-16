using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OurRayCaster : MonoBehaviour {

	public float raycastRange;
    public GameObject checklist;
    private bool isChecklistActive;
    private bool checklistAcquired;
	// Use this for initialization
	void Start () {
        isChecklistActive = false;
        checklistAcquired = false;
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
                Debug.Log(hit.transform.tag);
				Clickable clicked = hit.transform.gameObject.GetComponent<Clickable>();
                if (hit.transform.tag.Equals("checklist"))
                {
                    Debug.Log("hit is checklist");
                    checklistAcquired = true;
                    hit.transform.position = this.transform.position;
                    hit.transform.SetParent(this.transform);
                    //hier animation der checklist stoppen?
                }
				if(clicked != null) {
					//we hit a clickable!
					clicked.onClick();
					Debug.Log("onClick");
				}
			}
        }
        if (Input.GetKeyDown(KeyCode.H) && checklistAcquired)
        {
            if (isChecklistActive)
            {
                //deactivate
                isChecklistActive = false;
                checklist.SetActive(false);
            }
            else
            {
                Debug.Log("pushed H key.");
                Debug.Log("isChecklistActive?: " + isChecklistActive);
                checklist.SetActive(true);
                isChecklistActive = true;
            }
        }
	}
}
