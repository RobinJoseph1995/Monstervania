using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game : MonoBehaviour {
	public static bool start = false;
	public static bool defeat = false;
    public static bool finished = false;
	public static GameObject player_o;
	public static GameObject flying_enemy_o;
	public static GameObject map_o;

	bool menu = true;
	GameObject game_title_o;
	public static GameObject start_b;
    public static GameObject restart_b;
	public static GameObject quit_b;
	public static GameObject timer_label_o;
	public static GameObject endgame_label_o;
    public static GameObject wingame_label;
    public static GameObject dialogue_o;
    public static GameObject act_title_o;
    AudioSource music;

    void Start() {
		player_o = GameObject.Find("player");
		player_o.SetActive(false);

		flying_enemy_o = GameObject.Find("flying_enemy");
		flying_enemy_o.SetActive(false);
		map_o = GameObject.Find("map");

		game_title_o = GameObject.Find("game_title");
		start_b = GameObject.Find("start_b");
        restart_b = GameObject.Find("restart_b");
        restart_b.SetActive(false);
		quit_b = GameObject.Find("quit_b");
		timer_label_o = GameObject.Find("timer_label");
		timer_label_o.SetActive(false);
		act_title_o = GameObject.Find("act_title");
		act_title_o.SetActive(false);
		//screen1_description_o = GameObject.Find("screen1_description");
		//screen1_description_o.SetActive(false);
		endgame_label_o = GameObject.Find("endgame_label");
        wingame_label = GameObject.Find("wingame_label");
        if (player.isRestarted == false)
        {
            endgame_label_o.SetActive(false);
        }
        else
        {
            endgame_label_o.SetActive(true);
        }

		music = GameObject.Find("camera").GetComponent<AudioSource>();
        dialogue_o = GameObject.Find("dialogue");
        dialogue_o.SetActive(false);
        wingame_label.SetActive(false);
    }

	public void start_game() {
        wingame_label.SetActive(false);
        player.hunger = 10.0f;
        player.health = 10.0f;
		player_o.SetActive(true);
		timer_label_o.SetActive(true);
		//screen1_title_o.SetActive(true);
		//screen1_description_o.SetActive(true);

		game_title_o.SetActive(false);
		start_b.SetActive(false);
        restart_b.SetActive(false);
		quit_b.SetActive(false);
        endgame_label_o.SetActive(false);

        dialogue_o.SetActive(true);

        music.Stop();

        dialogue.full_text = "I see the village burning! Must get there. No time to waste!";
        dialogue.delay = 420;
    }

    public void end_game() {
        dialogue_o.SetActive(true);

        dialogue.full_text = "Oh .. where am I? Wait ...  Is all coming back now ... Oh no! I have made a terrible mistake! I have released a deadly evil upon this world. I must undo the wrong I have done but I cannot do it alone.";
        dialogue.delay = 420;  
    }

	void FixedUpdate() {
        if (dialogue_o.activeSelf && dialogue.delay == 0 && !start)
        {
            start = true;
            act_title_o.SetActive(true);
            act_title.fade = true;
        }

        if (start)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                menu = !menu;
            }
        }
    }

    public void quit_game()
    {
        print("Quit will work on build");
        Application.Quit();
    }

}
