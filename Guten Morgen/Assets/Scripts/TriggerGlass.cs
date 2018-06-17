using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGlass : MonoBehaviour {


	void Start() {
		enabled = false;
	}

    void OnTriggerEnter(Collider other)
    {
        if (true)
        {
            Debug.Log("Triggered...?" + other.tag);
            /*
            GameObject camera = transform.parent.parent.parent.gameObject;
            camera.GetComponent<PourMinigame>().enabled = false;
            camera.transform.parent.gameObject.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;
            camera.GetComponent<OurRayCaster>().enabled = true;
            camera.GetComponent<PourMinigame>().finish();
            this.enabled = false;*/
        }
    }

}
