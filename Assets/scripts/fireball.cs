using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour
{
    public float speed;
    //private Transform player;
    private Vector2 target;
    GameObject pl;
   // Rigidbody2D rb;
    // Use this for initialization
    void Start()
    {
        pl = GameObject.Find("player");
        target = new Vector2(pl.transform.position.x, pl.transform.position.y);
        //rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //To destroy fireball when touches the ground
        if(this.transform.position.y <= -1.0f) {
            Destroy(this.gameObject);
        } 
        
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    // damage player and leave
    private void OnTriggerEnter2D(Collider2D col)
    {
       
        if (col.name == "player_body") {
            player.health -= 1;
            Destroy(this.gameObject);
        }
    }
}
