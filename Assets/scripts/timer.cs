using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour {
    float timeLeft = 180.0f;
    private string zero = "00:00"; 

    void Update()
    {
        if (game.flying_enemy_o != null) {
            if(game.start && game.flying_enemy_o.activeSelf == false) {

                string timeString="";
                if (game.defeat) {
                    game.timer_label_o.GetComponent<Text>().text = "Time: " + timeString;
                }
                else {
                    timeLeft -= Time.fixedDeltaTime;
                    int seconds = (int)(timeLeft % 60);
                    int minutes = (int)(timeLeft / 60) % 60;
                    timeString = string.Format("{0:00}:{1:00}", minutes, seconds);
                    game.timer_label_o.GetComponent<Text>().text  = "Time: " + timeString;
                    if (timeString == zero) {
                        timeLeft = 0.0f;
                        game.endgame_label_o.SetActive(true);
                        game.defeat = true;
                        Time.timeScale = 0;
                    }
                }
            }
        }
    }

}
