﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    private static int score;
    private static int numOfPassengers;
    private static BusControl player;
    private static bool gameOver = false;

    public float time;
    public Text peopleAttached;
    public Text timeRemaining;
    public Canvas HUD;
    public Canvas gameOverCanvas;

    public static int Score {
        get { return score; }
        set { score = value; }
    }

    public static int NumOfPassengers {
        get { return numOfPassengers; }
        set { numOfPassengers = value; }
    }

    public static BusControl Player {
        get { return player; }
        set { player = value; }
    }

    public static bool GameOver {
        get { return gameOver; }
        set { gameOver = value; }
    }

    // Use this for initialization
    void Start () {
        Score = 0;
        NumOfPassengers = 0;
        Player = FindObjectOfType<BusControl>();
	}
	
	// Update is called once per frame
	void Update () {
        peopleAttached.text = "Passengers: " + NumOfPassengers;
        float timeLeft = time - Time.timeSinceLevelLoad;
        timeRemaining.text = "Time: " + (timeLeft.ToString("n2"));

        if(GameOver) {
            print("game over 2");
            HUD.gameObject.SetActive(false);
            gameOverCanvas.gameObject.SetActive(true);
        }
    }

    public static void AttachPassenger() {
        NumOfPassengers++;
    }
}
