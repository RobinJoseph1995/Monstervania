using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zadar : MonoBehaviour {
	bool on_ground = false;
	// Use this for initialization
	void Start () {
		//Physics.IgnoreLayerCollision(11, 9);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (transform.position.y > -1) {
			transform.position = new Vector2(transform.position.x, transform.position.y - 0.04f);
		} else {
			if (on_ground == false) {
				on_ground = true;
				dialogue.full_text = "Oh .. where am I? Wait ...  Is all coming back now ... Oh no! I have made a terrible mistake! I have released a deadly evil upon this world. I must undo the wrong I have done but I cannot do it alone.";
				dialogue.delay = 1600; 
				game.finished = true;
				game.dialogue_o.SetActive(true);
				//game.dialogue_o.SetActive(true);
			}
		}
	}
}
