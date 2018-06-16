using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTap : MonoBehaviour, Clickable  {
	public ParticleSystem water;

	public virtual void onClick() {
		if( water.isPlaying) {
            Debug.Log("Hello Water?");
			water.Stop();
		}
		else {
			water.Play();
		}
	}

	public bool isWaterRunning() {
		return water.isPlaying;
	}
}


