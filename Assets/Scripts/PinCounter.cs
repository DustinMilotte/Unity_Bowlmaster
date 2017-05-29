using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class PinCounter : MonoBehaviour {
	public Text standingDisplay;

	private GameManager gameManager;
	private int lastSettledCount = 10;
	private bool ballOutOfPlay = false;
	private int lastStandingCount = -1;
	private float lastChangeTime;


	// Use this for initialization
	void Start () {
		gameManager = GameObject.FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		standingDisplay.text = CountStanding().ToString(); 	
		if(ballOutOfPlay){
			UpdateStandingCountAndSettle();
			standingDisplay.color = Color.red; 
		}
	}

	public void Reset(){
		lastSettledCount = 10;
	}

	void OnTriggerExit (Collider collider){
		if (collider.gameObject.name == "Ball"){
			ballOutOfPlay = true;
		}
	}

	void UpdateStandingCountAndSettle(){
		// update the lastStandingCount
		int countStanding = CountStanding();
		if(countStanding != lastStandingCount){
			lastChangeTime = Time.time;
			lastStandingCount = countStanding;
		}

		float settleTime = 3f;
		if((Time.time - lastChangeTime) >= settleTime){
			// when lastStandingCount hasn't changed for 3 seconds call PinsHaveSettled
			PinsHaveSettled();	
		}
	}

	int CountStanding(){
		// loop through all pins in scene. return number of standing pins.\
		int standing = 0;
		foreach(Pin pin in GameObject.FindObjectsOfType<Pin>()){
			if(pin.IsStanding()){
				++standing;
			}
		}
		return standing;
	}

	void PinsHaveSettled(){
		int pinFall = lastSettledCount - CountStanding();
		lastSettledCount = CountStanding();

		gameManager.Bowl(pinFall);

 		lastStandingCount = -1;
		ballOutOfPlay = false;
		standingDisplay.color = Color.green;
	}
}
