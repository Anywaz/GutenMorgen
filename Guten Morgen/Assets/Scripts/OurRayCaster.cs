﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OurRayCaster : MonoBehaviour {

	public float raycastRange;
    public GameObject checklist;
    private bool isChecklistActive;
    private bool checklistAcquired;

    private bool holdsJuice, holdsGlass;
	// Use this for initialization
	void Start () {
        isChecklistActive = false;
        checklistAcquired = false;
        holdsGlass = false;
        holdsJuice = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("JoyA")) {
            Debug.Log("Start Raycast");
            //this casts the raycast
            RaycastHit hit;
            bool didHit = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, raycastRange);
            Debug.Log("i hit:" + didHit);
            if(didHit) {
                Debug.Log(hit.transform.tag);
                Clickable clicked = hit.transform.gameObject.GetComponent<Clickable>();
                if(!(holdsGlass || holdsJuice)) {
                    if (hit.transform.tag.Equals("checklist"))
                    {
                        Debug.Log("hit is checklist");
                        checklistAcquired = true;
                        hit.transform.position = this.transform.position + this.transform.forward;
                        hit.transform.LookAt(this.transform);
                        hit.transform.SetParent(this.transform);
                        checklist.SetActive(false);
                        //hier animation der checklist stoppen?
                    }
                    if(clicked != null && !hit.transform.tag.Equals("Juice") && !hit.transform.tag.Equals("Glass")) {
                        //we hit a clickable!
                        clicked.onClick();
                        Debug.Log("onClick");
                    }
                }
                if (hit.transform.tag.Equals("Juice")) {
                    holdsJuice = true;
                    clicked.onClick();
                    Debug.Log("This is a unique message");
                    Debug.Log("onClick");
                }
                if (hit.transform.tag.Equals("Glass") ) {
                    holdsGlass = true;
                    clicked.onClick();
                    Debug.Log("onClick");
                }
                if(holdsGlass && holdsJuice) {
                    UnityStandardAssets.Characters.FirstPerson.FirstPersonController fpsControl;
                    fpsControl = transform.parent.gameObject.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
                    fpsControl.enabled = false;
                    this.gameObject.AddComponent<PourMinigame>();
                    this.enabled = false;
                }
            }
        }
        if (Input.GetButtonDown("JoyY") && checklistAcquired)
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
