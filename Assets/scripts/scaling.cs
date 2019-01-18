using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaling : MonoBehaviour {
    /* float x;
    public int layer;

    // Use this for initialization
    void Start() {


        x = transform.position.x;
    }

     // Update is called once per frame
    void FixedUpdate()
    {
        // y_world / (y_player - y_world) / 

        GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt(transform.position.y * -100) - 120;

        //if object is visible
         if (transform.position.y >= -1.3 && transform.position.y <= 0)
        {
            layer = Mathf.RoundToInt(transform.position.y * -1);
            GetComponent<SpriteRenderer>().sortingOrder = layer;
            transform.localScale = new Vector2(1, 1) * Mathf.Abs(transform.position.y);
        
            transform.position = new Vector3(x , transform.position.y);
        }
        else
        {
            transform.localScale = new Vector2(0, 0);
        } 

    } */

    SpriteRenderer sr;

    void Start() {
        sr = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        sr.sortingOrder = Mathf.RoundToInt(transform.position.y * -100) - 120;
    }
}
