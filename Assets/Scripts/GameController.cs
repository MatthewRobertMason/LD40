using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    private static int score;
    private static int numOfPassengers;
    private static BusControl player;

    public Text peopleAttached;

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

    // Use this for initialization
    void Start () {
        Score = 0;
        NumOfPassengers = 0;
        Player = FindObjectOfType<BusControl>();
	}
	
	// Update is called once per frame
	void Update () {
        peopleAttached.text = "Passengers: " + NumOfPassengers;
    }

    public static void AttachPassenger() {
        NumOfPassengers++;
    }
}
