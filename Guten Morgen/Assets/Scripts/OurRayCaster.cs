using System.Collections;
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
                        hit.transform.position = this.transform.position + this.transform.forward*0.3f;
                        hit.transform.LookAt(this.transform);
                        hit.transform.localRotation *= Quaternion.AngleAxis(180, new Vector3(0, 0, 1));
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
					holdsGlass = false;
					holdsJuice = false;
                    UnityStandardAssets.Characters.FirstPerson.FirstPersonController fpsControl;
                    fpsControl = transform.parent.gameObject.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
                    fpsControl.enabled = false;
                    this.gameObject.AddComponent<PourMinigame>();


                    GameObject child = GameObject.FindGameObjectWithTag("Glass").transform.GetChild(0).gameObject;
                    child.GetComponent<Collider>().enabled = true;
                    child.AddComponent<TriggerGlass>();
                    //start particlesystem:
                    GameObject.FindGameObjectWithTag("Juice").gameObject.GetComponent<Juice>().ps.Play();


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
