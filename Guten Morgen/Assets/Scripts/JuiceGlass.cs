using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuiceGlass : MonoBehaviour, Clickable {

	public void onClick() {
		transform.parent.SetParent(GameObject.FindWithTag("MainCamera").transform);

        transform.parent.localPosition = new Vector3(0.3f, 0.05f, 0.7f);
        transform.parent.localRotation = Quaternion.AngleAxis(90.0f, Vector3.right);
		transform.parent.localRotation *= Quaternion.AngleAxis(180, Vector3.up);

       

        Debug.Log("Name of Parent: " + this.transform.parent.name);
    }
}
