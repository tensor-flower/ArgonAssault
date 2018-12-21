//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour {
	Text text;
	int score = 0;
	
	void Start () {
		text = GetComponent<Text>();
		Display();
	}

	private void Display(){
		text.text = score.ToString();
	}

	public void AddScore(int scoreToAdd){
		score += scoreToAdd;
		Display();
	}
}
