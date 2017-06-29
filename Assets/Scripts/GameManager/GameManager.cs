﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    private int totalScore;
    private float timer;

    private bool pause;

    [SerializeField]
    private Text UIscore;
    [SerializeField]
    private Text UItimer;
    [SerializeField]
    private float levelDuration;


    



	// Use this for initialization
	void Start ()
    {
        pause = false;
        StartLevel();
	}
	
    void StartLevel()
    {
        timer = levelDuration;
        totalScore = 0;
    }


	// Update is called once per frame
	void Update ()
    {
		if (!pause)
        {
            timer -= Time.deltaTime;
            UItimer.text = timer.ToString();

            UIscore.text = "SCORE: "+ totalScore.ToString();
        }
	}

    public void Pause(bool paused)
    {
        pause = true;
    }

    public void ManipulateScore(int val)
    {
        totalScore += val;
    }
}
