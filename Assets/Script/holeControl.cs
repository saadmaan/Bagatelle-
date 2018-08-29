using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class holeControl : MonoBehaviour {

	public int point; //specific point for the specific hole

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "ball")
        {	
			/*update score according to the point of the hole*/
			if (gameObject.name == "goldenHole") {
				gameManager.ballsCount += 3;
				GameObject.Find ("_GM").GetComponent<gameManager> ().showUpdatedBallCount ();
			}
			if (gameObject.tag == "gameOver") {
				print ("gameOver");
				col.gameObject.GetComponent<ballControl> ().setInitialPosition ();
				col.gameObject.GetComponent<ballControl>().init();
				gameManager.isGameOver = true;
				Time.timeScale = 0;
				return;
			}
			gameManager.score += point;
			if (gameManager.score >= 100 && SceneManager.GetActiveScene().buildIndex == 0)
				SceneManager.LoadScene ("game1");
			if (gameManager.score >= 200 && SceneManager.GetActiveScene ().buildIndex == 1) {
				print ("game Complete");
				Time.timeScale = 0f;
			}
			GameObject.Find ("_GM").GetComponent<gameManager> ().showUpdatedScore ();
			//print ("present score = " + gameManager.score);
			//print ("collided with hole");
			col.gameObject.GetComponent<ballControl>().init();
				
        }
    }
}
