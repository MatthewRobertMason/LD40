using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    private int score;
    private int numOfPassengers;
    private static BusControl player;

    public int Score {
        get { return score; }
        set { score = value; }
    }

    public int NumOfPassengers {
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
		
	}
}
