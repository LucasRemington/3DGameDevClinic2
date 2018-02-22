using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_Difficulty : MonoBehaviour {

    public PlayerMovement player;
    public DeathMenu dm;
    private float score = 0.0f;
    private int difficulty = 1;
    private int maxDiff = 6;
    private int scoretoNext = 10;
    public Text scoreText;
    private bool dead = false;

	void Start () {
		
	}
	
	void Update () {
        if (dead == true){
            return;
        }

        if (score >= scoretoNext) LevelUp();
        score += Time.deltaTime * difficulty;
        scoreText.text = ((int)score).ToString();
	}

    void LevelUp()
    {
        if (difficulty == maxDiff)
        {
            return;
        }
        scoretoNext *= 2;
        difficulty++;

        player.SpeedLevel(difficulty);
    }

    public void OnDeath()
    {
        dead = true;
        dm.ToggleEndMenu(score);
    }
}
