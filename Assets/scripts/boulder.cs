using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boulder : MonoBehaviour {
//	float y;
	float speed = 0.28f;
	bool pl_hit;

	Collider2D col;

	void Start() {
	//	y = transform.position.y;
		col = GetComponent<Collider2D>();
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (game.start == true) {
			//transform.position = new Vector2(transform.position.x, y);

			transform.position += Vector3.down * speed * Time.deltaTime; 

			if (transform.position.y < -2) {
				Destroy(gameObject);
			} 

			if(col.IsTouchingLayers(LayerMask.GetMask("Player"))) {
				if (player.compare_values(player.y, transform.position.y, 0.02f)) {
					if (player.height < 0.1f) {
						Destroy(gameObject);
						player.health -= 3;
					}
				}
			}
		}
	}
}
