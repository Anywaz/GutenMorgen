using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Juice : MonoBehaviour, Clickable {
	public ParticleSystem water;

	public void onClick() {
		if( water.isPlaying) {
			water.Stop();
		}
		else {
			water.Play();
		}
	}
}
