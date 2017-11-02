using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour {

    private Text scoreText;

	void Start () {
        scoreText = GetComponent<Text>();
        scoreText.text = "0";
	}

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
}
