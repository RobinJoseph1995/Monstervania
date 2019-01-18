using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class act_title : MonoBehaviour {
	public static bool fade = false;
	int timer = 0;
	float c = 0;
	Text text;

	void Start(){
		text = GameObject.Find("act_title").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (fade) {
			if (timer == 0) {
				timer = 240;
			}

			if (timer > 180) {
				c += 0.02f;
				text.color = new Color(0.6792453f, 0.5991456f, 0.6550984f, c);
				if (c > 1) c = 1;
			} else if (timer < 60) {
				c -= 0.02f;
				text.color = new Color(0.6792453f, 0.5991456f, 0.6550984f, c);
				if(c < 0) c = 0;
			}

			timer--;

			if (timer == 0) {
				fade = false;
				gameObject.SetActive(false);
			}
		}
		
	}
}
