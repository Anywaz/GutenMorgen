using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toothbrush : MonoBehaviour, Clickable {

    public Transform bone1;
    public Transform bone2;
    public Transform bone3;
    public Transform bone4;
    public Transform bone5;
    public float sensitivity;
    public GameObject sink;
    private WaterTap sinkScript;
    public float speed = 1.0f;
    private float oldw, oldr;

    public void onClick()
    {
        GameObject player = GameObject.FindWithTag("Player");
        transform.SetParent(player.transform);
        UnityStandardAssets.Characters.FirstPerson.FirstPersonController fpc = player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
        oldw = fpc.m_WalkSpeed;
        oldr = fpc.m_RunSpeed;
        fpc.m_WalkSpeed = 0;
        fpc.m_RunSpeed = 0;
    }



    // Use this for initialization
    void Start () {
        sinkScript = sink.gameObject.GetComponent<WaterTap>();
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.parent != null)
        {
            
        //Left side translation left/right
        if (Input.GetAxis("JoyTriggerL") > 0)
        {
            transform.localPosition += new Vector3(Time.deltaTime * -speed, 0.0f, 0.0f);
        }
        else if (Input.GetButton("JoyLB"))
        {
            transform.localPosition += new Vector3(Time.deltaTime * speed, 0.0f, 0.0f);
        }

        //Right side translation forward/backward
        if (Input.GetAxis("JoyTriggerR") > 0)
        {
            transform.localPosition += new Vector3(0, 0, Time.deltaTime * -speed);
        }
        else if (Input.GetButton("JoyRB"))
        {
            transform.localPosition += new Vector3(0, 0, Time.deltaTime * speed);
        }


            //boundary checks juice
        Vector3 localPos = transform.localPosition;
        if (localPos.x < -0.5f) transform.localPosition = new Vector3(-0.5f, localPos.y, localPos.z);
        else if (localPos.x > 0.5f) transform.localPosition = new Vector3( 0.5f, localPos.y, localPos.z);
        localPos = transform.localPosition;
        if (localPos.z < 0.2f) transform.localPosition = new Vector3(localPos.x, localPos.y, 0.2f);
        else if (localPos.z > 0.7f) transform.localPosition = new Vector3(localPos.x, localPos.y, 0.7f);
             

        }
        Bend(sink.transform.GetChild(0).transform.position);
	}

    void Bend (Vector3 dir)
    {
        Vector3 distance = bone5.transform.position - dir; 
        float strength = Mathf.Max(0, sensitivity-distance.magnitude*5*sensitivity);
        if (sinkScript.IsWaterRunning() && !sinkScript.IsFree())
        {
            Debug.Log(distance.magnitude);
            Quaternion inv = Quaternion.Inverse(transform.rotation);
            Vector3 distRel = inv * distance;
            if (distRel.x > 0) strength *= -1;
            bone1.localEulerAngles = new Vector3(0, 0, strength);
            bone2.localEulerAngles = new Vector3(0, 0, strength);
            bone3.localEulerAngles = new Vector3(0, 0, strength);
            bone4.localEulerAngles = new Vector3(0, 0, strength);
            bone5.localEulerAngles = new Vector3(0, 0, strength);
        }
        else
        {
            sinkScript.CheckOpen(distance.magnitude < 0.05f);
            if (sinkScript.IsWaterRunning())
            {
                GameObject player = GameObject.FindWithTag("Player");
                UnityStandardAssets.Characters.FirstPerson.FirstPersonController fpc = player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
                fpc.m_WalkSpeed = oldw;
                fpc.m_RunSpeed = oldr;
                Destroy(gameObject);
            }
        }
    }
}
