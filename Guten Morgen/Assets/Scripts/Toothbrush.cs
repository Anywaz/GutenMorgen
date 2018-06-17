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

    public void onClick()
    {
        transform.SetParent(GameObject.FindWithTag("Player").transform);
    }



    // Use this for initialization
    void Start () {
        sinkScript = sink.gameObject.GetComponent<WaterTap>();
    }
	
	// Update is called once per frame
	void Update () {
        
            Bend(sink.transform.GetChild(0).transform.position);
	}

    void Bend (Vector3 dir)
    {
        Vector3 distance = transform.position - dir; 
        float strength = Mathf.Max(0, sensitivity-distance.magnitude*5*sensitivity);
        if (sinkScript.IsWaterRunning() && !sinkScript.IsFree())
        {
            Debug.Log(distance.magnitude);
            Quaternion inv = Quaternion.Inverse(transform.rotation);
            Vector3 distRel = inv * distance;
            if (distRel.x > 0) strength *= -1;
            bone1.localEulerAngles = new Vector3 (0, 0, strength);
            bone2.localEulerAngles = new Vector3 (0, 0, strength);
            bone3.localEulerAngles = new Vector3 (0, 0, strength);
            bone4.localEulerAngles = new Vector3 (0, 0, strength);
            bone5.localEulerAngles = new Vector3 (0, 0, strength);
        }
        else sinkScript.CheckOpen(distance.magnitude<0.125);
    }
}
