using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    private static int score;
    private static int numOfPassengers;
    private static BusControl player;
    private static bool timeOver = false;
    private static bool endLevelHit = false;

    public float time;
    public Text peopleAttached;
    public Text timeRemaining;
    public Text finalScore;
    public Canvas endLevel;
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

    public static bool TimeOver {
        get { return timeOver; }
        set { timeOver = value; }
    }

    public static bool EndLevelHit {
        get { return endLevelHit; }
        set { endLevelHit = value; }
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
        float timeLeft = Mathf.Max(0, time - Time.timeSinceLevelLoad);
        timeRemaining.text = "Time: " + (timeLeft.ToString("n2"));

        if(timeLeft <= 0) {
            player.RemoveControlAndCamera();
            TimeOver = true;
        } else {
            TimeOver = false;
        }

        if(TimeOver || EndLevelHit) {
            HUD.gameObject.SetActive(false);
            if(TimeOver) {
                gameOverCanvas.gameObject.SetActive(true);
            } else if(EndLevelHit) {
                endLevel.gameObject.SetActive(true);
                finalScore.text = "Final Score: " + NumOfPassengers;
            }
        } else {
            HUD.gameObject.SetActive(true);
            gameOverCanvas.gameObject.SetActive(false);
            endLevel.gameObject.SetActive(false);
        }
    }
    
    public static void AttachPassenger() {
        NumOfPassengers++;
    }
}
