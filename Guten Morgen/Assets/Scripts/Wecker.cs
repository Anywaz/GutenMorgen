using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wecker : MonoBehaviour, Clickable {

    private bool animating;
    private float timeElapsed;
    public float speed;
    public GameObject start, end;
    private Vector3 startPos, endPos;
    private Quaternion startQuat, endQuat;
    public float rotAngle;

    public void onClick()
    {
        AudioSource alarm = gameObject.GetComponent<AudioSource>();
        alarm.Stop();
        animating = false;
    }

    // Use this for initialization
    void Start () {
        endPos = end.transform.position;
        startPos = start.transform.position;
        startQuat = transform.rotation * Quaternion.Euler(Vector3.back * rotAngle);
        endQuat = transform.rotation * Quaternion.Euler(Vector3.back * -rotAngle);
        Destroy(start);
        Destroy(end);
        animating = true;
        timeElapsed = 0f;
    }

	// Update is called once per frame
	void Update () {
		if (animating)
        {

            timeElapsed += Time.deltaTime*speed;
            if (timeElapsed < 1.0) { 
                transform.position = Vector3.Lerp(startPos, endPos, timeElapsed);
                transform.rotation = Quaternion.Slerp(startQuat, endQuat, timeElapsed);
            }
            else {
                transform.position = Vector3.Lerp(endPos, startPos, timeElapsed-1.0f);
                transform.rotation = Quaternion.Slerp(endQuat, startQuat, timeElapsed-1.0f);
                if (timeElapsed >= 2.0f) timeElapsed = 0f;
            }
            
        }
	}
}
