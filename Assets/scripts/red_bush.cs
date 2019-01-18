using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class red_bush : MonoBehaviour {
	bool berry = true;
	
	public Sprite bush;
	
	Collider2D col;
	SpriteRenderer sr;
	bool pl_hit;

	void Start() {
		col = GetComponent<Collider2D>();
		sr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (berry) {
			if (col.IsTouchingLayers(LayerMask.GetMask("Player"))) {
				if (player.compare_values(player.y, transform.position.y, 0.02f)) {
					player.hunger += 1f;
					berry = false;
					sr.sprite = bush;
				}
			}
		}
	}
}
