using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PourMinigame : MonoBehaviour {

    private GameObject glass, juice;
    public float speed = 1.0f;

	// Use this for initialization
	void Start () {
        glass = GameObject.FindGameObjectWithTag("Glass");
        juice = GameObject.FindGameObjectWithTag("Juice");

        GameObject child = glass.transform.GetChild(0).gameObject;
        child.GetComponent<Collider>().enabled = true;
        child.GetComponent<TriggerGlass>().enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
        if(transform.rotation != transform.parent.transform.rotation) {
            float step = 45 * Time.deltaTime;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, transform.parent.transform.rotation, step);
        }

        //Left stick translation of juice
        float translation = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        juice.transform.parent.transform.Translate(0, translation, 0);
        translation = Input.GetAxis("Vertical") * speed;
        translation *= Time.deltaTime;
        juice.transform.parent.transform.Translate(0, 0, -translation);

        //boundary checks juice
        Vector3 localPos = juice.transform.parent.transform.localPosition;
        if (localPos.x < -0.5f) juice.transform.parent.transform.localPosition = new Vector3(-0.5f, localPos.y, localPos.z);
        else if (localPos.x > 0.5f) juice.transform.parent.transform.localPosition = new Vector3( 0.5f, localPos.y, localPos.z);
        localPos = juice.transform.parent.transform.localPosition;
        if (localPos.y < -0.4f) juice.transform.parent.transform.localPosition = new Vector3(localPos.x, -0.4f, localPos.z);
        else if (localPos.y > 0.4f) juice.transform.parent.transform.localPosition = new Vector3(localPos.x, 0.4f, localPos.z);

        //Right stick translation of glass
        translation = Input.GetAxis("Mouse X") * speed; //Controller right stick x-axis
        translation *= Time.deltaTime;
        glass.transform.parent.transform.Translate(-translation, 0, 0);
        translation = Input.GetAxis("Mouse Y") * speed; //Controller right stick y-axis
        translation *= Time.deltaTime;
        glass.transform.parent.transform.Translate(0, 0, translation);

        //boundary checks glass
        localPos = glass.transform.parent.transform.localPosition;
        if (localPos.x < -0.5f) glass.transform.parent.transform.localPosition = new Vector3(-0.5f, localPos.y, localPos.z);
        else if (localPos.x > 0.5f) glass.transform.parent.transform.localPosition = new Vector3(0.5f, localPos.y, localPos.z);
        localPos = glass.transform.parent.transform.localPosition;

        if (localPos.y < -0.4f) glass.transform.parent.transform.localPosition = new Vector3(localPos.x, -0.4f, localPos.z);
        else if (localPos.y > 0.4f) glass.transform.parent.transform.localPosition  = new Vector3(localPos.x, 0.4f, localPos.z);

        //Left side rotation of juice
        if (Input.GetAxis("JoyTriggerL") > 0)
        {
            juice.transform.Rotate(Time.deltaTime * 100.0f, 0.0f, 0.0f);
        }
        else if (Input.GetButton("JoyLB"))
        {
            juice.transform.Rotate(Time.deltaTime * -100.0f, 0.0f, 0.0f);
        }

        //Right side rotation of glass
        if (Input.GetAxis("JoyTriggerR") > 0)
        {
            glass.transform.Rotate(0, Time.deltaTime * -100.0f, 0);
        }
        else if (Input.GetButton("JoyRB"))
        {
            glass.transform.Rotate(0, Time.deltaTime * 100.0f, 0);
        }
	}

    public void finish() {
        Destroy(glass);
        Destroy(juice);
        Destroy(this);
    }
}
