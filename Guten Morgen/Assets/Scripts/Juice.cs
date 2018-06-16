using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Juice : WaterTap {
	public ParticleSystem water;
	//position of the juice at the beginning
	private Transform startPos;

	public void onClick() {
		//start waterflow
		base.onClick();
		if(transform.parent == null) {
			//hold in hand:
			//store old pos to reset it later:
		}
		else {
			transform.parent = null;
			transform.position = startPos.position;
			transform.rotation = startPos.rotation;
		}
	}
}
