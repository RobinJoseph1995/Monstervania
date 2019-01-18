using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogue : MonoBehaviour {
	public static int delay;
	public static string full_text = "";
	float wordsPerSecond = 2; // speed of typewriter
	float timeElapsed = 0;   
	
	Text text_comp;

	void Start() {
		text_comp = GetComponentInChildren<Text>();
	}

	void FixedUpdate()
	{
		if (delay == 0) {
			timeElapsed = 0;
			gameObject.SetActive(false);
			if (game.finished == true) {
				game.wingame_label.SetActive(true);
				Time.timeScale = 0;
			}

		} else {
			delay--;
		}

		timeElapsed += Time.deltaTime;
		text_comp.text = get_words(full_text,  (int)(timeElapsed * wordsPerSecond));
	}
	
	private string get_words(string text, int wordCount){
		int words = wordCount;
		// loop through each character in text
		for (int i = 0; i < text.Length; i++) { 
			if (text[i] == ' ') {
				words--;
			}
			if (words <= 0) {
				return text.Substring(0, i);
			}
		}
		return text;
	}
}
