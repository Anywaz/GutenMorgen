using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Juice : MonoBehaviour, Clickable {
	//position of the juice at the beginning
	private Transform startPos;
    public ParticleSystem ps;

	public void onClick() {
		transform.parent.SetParent(GameObject.FindWithTag("MainCamera").transform);

        transform.parent.localPosition = new Vector3(-0.3f, 0.05f, 0.7f);
        transform.parent.localRotation = Quaternion.AngleAxis(90.0f, Vector3.right);
        transform.parent.localRotation *= Quaternion.AngleAxis(-90.0f, Vector3.forward);

        Debug.Log("Name of Parent: " + this.transform.parent.parent.name);
	}
}
