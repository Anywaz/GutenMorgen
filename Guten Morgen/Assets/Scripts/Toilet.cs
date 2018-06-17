using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toilet : MonoBehaviour, Clickable {
    private bool clicked;
    private bool open;
    public float openAngle, closeAngle;
    public float speed;
public void onClick()
    {
        if (!clicked)
        {
            GetComponent<AudioSource>().Play();
            clicked = true;
        }
        else
        {
            open = !open;
        }
        
    }

    // Use this for initialization
    void Start () {
        clicked = false;
        open = false;
        if (speed < 1.0f) speed = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
        Quaternion target;

        if (open) target = Quaternion.Euler(openAngle, -90, 90);
        else target = Quaternion.Euler(closeAngle, -90, 90);

        transform.localRotation = Quaternion.Slerp(transform.localRotation, target, Time.deltaTime*speed);
	}
}
