using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour {

	public static bool isGameOver = false;
	public static int score = 0;
	public static int ballsCount = 10;
	public GameObject scoreObject; //jar kase current score er textmesh ase
	public GameObject ballCountObject;  //jar kase current ballCount thakbe
	public GameObject powerMeasureObject; //power show korbe

	// Use this for initialization
	void Start () {
		init ();
	}
	
	// Update is called once per frame
	void Update () {
		if (gameManager.isGameOver) {

		}
	}

	void init(){
		score = 0;
		if (SceneManager.GetActiveScene ().buildIndex == 0)
			ballsCount = 10;
		if (SceneManager.GetActiveScene ().buildIndex == 1)
			ballsCount = 7;
		showUpdatedBallCount ();
		showUpdatedScore ();
	}

	public void showUpdatedBallCount(){
		ballCountObject.GetComponent<TextMesh> ().text = "Balls Left : " + ballsCount.ToString();
	}

	public void showUpdatedScore(){
		scoreObject.GetComponent<TextMesh> ().text = "Score : " + score.ToString();
	}

	public void showUpdatedPower(){
		powerMeasureObject.GetComponent<TextMesh> ().text = "" + (ballControl.inputMultiplier * 100).ToString();
	}

	public void loadScene(int index)
	{	
		SceneManager.LoadScene (index);
	}
}
