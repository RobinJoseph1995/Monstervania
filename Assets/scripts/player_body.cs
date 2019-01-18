using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_body : MonoBehaviour {
    AudioSource sound;

	// Use this for initialization
	void Start () {
		sound = gameObject.GetComponent<AudioSource>();
	}
	
	public void step_sound() {
		sound.pitch = Random.value * 0.2f + 0.8f;
        sound.Play();
    }
}
