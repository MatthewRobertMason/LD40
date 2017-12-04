using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GoToNextLevel() {
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCountInBuildSettings);
        GameController.TimeOver = false;
        GameController.EndLevelHit = false;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("small");
    }

    public void Quit() {
        Application.Quit();
    }

    public void Restart() {
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene);
    }

    public static void Replace() {
        GameController.Player.transform.position = GameController.StartPoint;
        GameController.Player.transform.rotation = GameController.StartOrientation;
        var rb = GameController.Player.GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0, 0, 0);
    }

    public void FixStuck()
    {
        GameController.Player.transform.position = GameController.StartPoint;
        GameController.Player.transform.rotation = GameController.StartOrientation;
        var rb = GameController.Player.GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0, 0, 0);
    }
}
