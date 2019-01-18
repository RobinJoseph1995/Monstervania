using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour {
    public static float health = 10.0f;
    public static float hunger = 10.0f;
    public static float height; //defines jumping
    public static float y = -1.184f;
    public static bool isRestarted = false;
    public GameObject rock;
    public GameObject rockspawn;
    const int fire_rate = 60;
    int fire_timer = 0;
    Rigidbody2D rb;
    Collider2D col;
    Animator anim;
    public static float move_speed = 0.008f;
    float sidestep_speed = 0.6f;
    float jump_speed = 16.0f;
    //AudioSource sound;
    float hor;
    float ver;
    bool jump = false;
    const float distance_speed = 0.00001f;
    const float sky_speed = 0.0025f;

    SpriteRenderer health_sprite;
    SpriteRenderer hunger_sprite;

    // Use this for initialization
    void Start () {
        health_sprite = GameObject.Find("health").GetComponent<SpriteRenderer>();
        hunger_sprite = GameObject.Find("hunger").GetComponent<SpriteRenderer>();

        anim = gameObject.GetComponentInChildren<Animator>();
        rb = gameObject.GetComponentInChildren<Rigidbody2D>();
        col = gameObject.GetComponentInChildren<Collider2D>();
        y = transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate () {
        if (game.start) {

            if((Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.Mouse0)) && fire_timer == 0) {
                GameObject rockInstance = Instantiate(rock, GameObject.FindGameObjectWithTag("rockSpawn").transform.position, Quaternion.identity);
                rockInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 2.0f);
                fire_timer = fire_rate;
            } else if (fire_timer > 0) {
                fire_timer--;
            }

            if (game.flying_enemy_o != null) {
                if(game.map_o.transform.position.y <= -42 && game.flying_enemy_o.activeSelf==false){
                    game.flying_enemy_o.SetActive(true);
                    move_speed = 0f;
                }
            }

            //new speedup added on the stack

            if(health<=0 )
            {
                health = 0;
            }
            if (hunger <= 0)
            {
                hunger = 0;
            }
            health_sprite.size = new Vector2(0.07f * health, 0.06f);
            hunger_sprite.size = new Vector2(0.07f * hunger, 0.06f);

            anim.SetBool("jump", jump);
            anim.SetFloat("ver", ver);
            anim.SetFloat("hor", hor);

            height = col.transform.position.y;
            
            bool ground = col.IsTouchingLayers(LayerMask.GetMask("Ground"));

            // JUMP
            if (Input.GetKey(KeyCode.Space) && ground)
            {
                rb.AddForce(new Vector2(0,  jump_speed));
                jump = true;
                hunger -= 0.02f;
            } 
            else if (jump && ground) {
                jump = false;
            }

            // FORWARD BACKWARDS
            if (Input.GetKey(KeyCode.W) && game.map_o.transform.position.y >= -42) {
                game.map_o.transform.position = new Vector2(game.map_o.transform.position.x, game.map_o.transform.position.y - move_speed);
                ver = 1;
                hunger -= 0.002f;
            } else if (Input.GetKey(KeyCode.S) && game.map_o.transform.position.y < 0) {
                game.map_o.transform.position = new Vector2(game.map_o.transform.position.x, game.map_o.transform.position.y + move_speed);
                ver = -1;
                hunger -= 0.002f;
            } else if (ver != 0) {
                ver = 0;
            }

            // SIDESTEP
            if (Input.GetKey(KeyCode.D))
            {
                if (transform.position.x < 1.8f)
                    transform.position += Vector3.right * sidestep_speed * Time.deltaTime;     
            
                hunger -= 0.002f;
                hor = 1;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                if (transform.position.x > -1.8f)
                    transform.position += Vector3.left * sidestep_speed * Time.deltaTime;
                
                hunger -= 0.002f;
                hor = -1;
            } else if (hor != 0) {
                hor = 0;
            }

            //Game over if health 0
            if(health <=0 || hunger <=0)
            {
                
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                game.endgame_label_o.SetActive(true);
                isRestarted = true;
                //game.player_o.SetActive(false);
                //game.quit_b.SetActive(true);
                //game.restart_b.SetActive(true);
                //Time.timeScale = 0;
            }
        }    
    }

    public static bool compare_values(float f1, float f2, float f3) {
       // Debug.Log(f1 + "    " + f2);
        if ((f1 <= (f2 + f3)) && (f1 >= (f2 - f3))) {
            return true;
        }

        return false;
    }

}
