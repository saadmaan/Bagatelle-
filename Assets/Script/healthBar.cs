using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthBar : MonoBehaviour {
    public float T, C;
	private bool barRunning = false; //detects whether bar is active or not
	private bool isDecreasing = true; //detects if the bar is decreasing

	// Use this for initialization
	void Start () {
		init ();
	}
	
	// Update is called once per frame
	void Update () {
		if (gameManager.isGameOver == false) {
			if (Input.GetKeyDown (KeyCode.A) && !barRunning) {	
				barRunning = true;
				print ("doing damage");
			} else if (barRunning && Input.GetKeyDown (KeyCode.A)) {
				print ("power = " + (C / T) * 100 + "%");
				ballControl.inputMultiplier = (C / T);
				GameObject.Find ("_GM").GetComponent<gameManager> ().showUpdatedPower ();
				barRunning = false;
				transform.localScale = new Vector3 (1.4f, 0.4f, 1);
			} else if (barRunning) { //jotokkhon lafabe totokkhon nicher condition detect korbe
				if (isDecreasing) {
					C -= 3f;
					transform.localScale = new Vector3((C/T) * 1.4f, 0.4f, 1);
					if (C <= 0)
						isDecreasing = false; //ekhon theke increase kora suru korbe
				} else {
					C += 3f;
					transform.localScale = new Vector3((C/T) * 1.4f, 0.4f, 1);
					if (C >= 50)
						isDecreasing = true;
				}
			}
		}

	}
    void damage()
    {
		
    }

	void init(){
		T = 50;
		C = T;
		isDecreasing = true;
		barRunning = false;
	}
}

