using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toothbrush : MonoBehaviour, Clickable {

    public Transform bone1;
    public Transform bone2;
    public Transform bone3;
    public float sensitivity;
    public GameObject sink;
    private WaterTap sinkScript;

    public void onClick()
    {
        transform.SetParent(GameObject.FindWithTag("Player").transform);
    }



    // Use this for initialization
    void Start () {
        bone1 = transform.Find("Bone008");
        bone2 = bone1.Find("Bone009");
        bone3 = bone2.Find("Bone010");
        sinkScript = sink.gameObject.GetComponent<WaterTap>();
    }
	
	// Update is called once per frame
	void Update () {
        
            Bend(sink.transform.position);
	}

    void Bend (Vector3 dir)
    {
        Vector3 distance = transform.position - dir;
        float strength = Mathf.Max(0, sensitivity - distance.magnitude);
        if (sinkScript.IsWaterRunning() && !sinkScript.IsFree())
        {
            bone1.eulerAngles = new Vector3(0, 0, strength);
            bone2.eulerAngles = new Vector3(0, 0, strength);
            bone3.eulerAngles = new Vector3(0, 0, strength);
        }
        else sinkScript.CheckOpen(strength>sensitivity/5);
    }
}
