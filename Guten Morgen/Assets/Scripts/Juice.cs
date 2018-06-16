using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Juice : WaterTap {
	//position of the juice at the beginning
	private Transform startPos;

	public void onClick() {
		//start waterflow
		base.onClick();
		transform.SetParent(GameObject.FindWithTag("Player").transform);

	}
}
