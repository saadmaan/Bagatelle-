using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballControl : MonoBehaviour {

    private Vector3 force;
    //starting position of the ball
    public Vector3 startPosition;
	public int baseForce = 10;     //baseforce * inputMultiplier hobe
	public static float inputMultiplier = 0f; //bar er percentage wise etar value hobe
	public bool backToStart = true;   //startposition e ball thakle eta true hobe

	// Use this for initialization
	void Start () {
        setInitialPosition();
		//GetComponent<Rigidbody> ().useGravity = false;
        //force = new Vector3(0, 1000, 0);
		init();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (1)) {
			
			print ("healthbar start");
		}
	}

	public void launchBall(){
		//Apply force
		if (backToStart) {
			backToStart = false;
			/*health bar currrnt position*/
			print ("mouse");
			GetComponent<Rigidbody> ().useGravity = true;
			GetComponent<Rigidbody> ().isKinematic = false;
			force = new Vector3 (0, baseForce * inputMultiplier, 0);
			inputMultiplier = 0f;
			transform.GetComponent<Rigidbody> ().AddForce (force);

			//balls Left update
			gameManager.ballsCount--;
			GameObject.Find ("_GM").GetComponent<gameManager> ().showUpdatedBallCount ();
			//transform.position = new Vector3(transform.position.x, transform.position.y, -1f);
		}
		if (gameManager.ballsCount == 0) {
			print ("gameOver");
			Time.timeScale = 0;
			gameManager.isGameOver = true;

		}
	}

    void OnCollisionEnter(Collision sample)
    {	
        if (sample.gameObject.tag == "ground")
        {	
			print ("collided with ground");
			init ();
        }
		if (sample.gameObject.tag == "forceIncrease")
		{	
			print ("increased force");
			transform.GetComponent<Rigidbody> ().AddForce (new Vector3 (Random.Range(500,3000), Random.Range(500,1000), 0));
		}
             
    }

	public void init()
	{	
		GameObject.Find ("_GM").GetComponent<gameManager> ().showUpdatedBallCount ();
		backToStart = true;
		GetComponent<Rigidbody> ().useGravity = false;
		GetComponent<Rigidbody> ().isKinematic = true;
		transform.position = startPosition;
	}

    public void setInitialPosition()
    {
        startPosition = transform.position;
    }
}
