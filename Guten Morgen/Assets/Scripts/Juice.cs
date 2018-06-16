using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Juice : WaterTap {
	//position of the juice at the beginning
	private Transform startPos;

	public override void onClick() {
        //start waterflow
        Debug.Log("before onClick in Base");
		base.onClick();
        Debug.Log("after onClick in Base");
		transform.SetParent(GameObject.FindWithTag("MainCamera").transform);

        transform.localPosition = new Vector3(-0.3f, 0.05f, 0.7f);
        transform.localRotation = Quaternion.AngleAxis(90.0f, Vector3.right);
        transform.localRotation *= Quaternion.AngleAxis(-90.0f, Vector3.forward);

        Debug.Log("Name of Parent: " + this.transform.parent.name);
	}
}
