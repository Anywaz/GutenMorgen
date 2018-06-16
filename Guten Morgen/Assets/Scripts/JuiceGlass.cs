using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuiceGlass : MonoBehaviour, Clickable {

	public void onClick() {
		transform.SetParent(GameObject.FindWithTag("MainCamera").transform);

        transform.localPosition = new Vector3(0.3f, 0.05f, 0.7f);
        transform.localRotation = Quaternion.AngleAxis(90.0f, Vector3.right);

        Debug.Log("Name of Parent: " + this.transform.parent.name);
    }
}
