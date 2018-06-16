using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTap : MonoBehaviour, Clickable  {
	public ParticleSystem water;
    private bool freeOpen;

	public virtual void onClick() {
		if( water.isPlaying) {
            Debug.Log("Hello Water?");
			water.Stop();
		}
		else {
			water.Play();
		}
	}

	public bool IsWaterRunning() {
		return water.isPlaying;
	}

    public bool IsFree()
    {
        return freeOpen;
    }

    public void CheckOpen(bool free)
    {
        freeOpen = free;
    }
}


