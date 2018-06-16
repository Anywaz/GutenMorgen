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
	}
	
	// Update is called once per frame
	void Update () {
        //Left stick translation of juice
        float translation = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        juice.transform.Translate(0, translation, 0);
        translation = Input.GetAxis("Vertical") * speed;
        translation *= Time.deltaTime;
        juice.transform.Translate(0, 0, translation);

        //boundary checks juice
        Vector3 localPos = juice.transform.localPosition;
        if (localPos.x < -1.0f) juice.transform.localPosition.Set(-1.0f, localPos.y, localPos.z);
        if (localPos.x > 1.0f) juice.transform.localPosition.Set(1.0f, localPos.y, localPos.z);

        if (localPos.y < -1.0f) juice.transform.localPosition.Set(localPos.x, -1.0f, localPos.z);
        if (localPos.y > 1.0f) juice.transform.localPosition.Set(localPos.x, 1.0f, localPos.z);

        //Right stick translation of glass
        translation = Input.GetAxis("Mouse X") * speed; //Controller right stick x-axis
        translation *= Time.deltaTime;
        glass.transform.Translate(translation, 0, 0);
        translation = Input.GetAxis("Mouse Y") * speed; //Controller right stick y-axis
        translation *= Time.deltaTime;
        glass.transform.Translate(0, translation, 0);

        //boundary checks glass
        localPos = glass.transform.localPosition;
        if (localPos.x < -1.0f) glass.transform.localPosition.Set(-1.0f, localPos.y, localPos.z);
        if (localPos.x > 1.0f) glass.transform.localPosition.Set(1.0f, localPos.y, localPos.z);

        if (localPos.y < -1.0f) glass.transform.localPosition.Set(localPos.x, -1.0f, localPos.z);
        if (localPos.y > 1.0f) glass.transform.localPosition.Set(localPos.x, 1.0f, localPos.z);

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
            glass.transform.Rotate(0, 0, Time.deltaTime * 100.0f);
        }
        else if (Input.GetButton("JoyRB"))
        {
            glass.transform.Rotate(0, 0, Time.deltaTime * -100.0f);
        }
	}
}
