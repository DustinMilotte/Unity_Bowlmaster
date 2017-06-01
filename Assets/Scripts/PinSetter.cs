using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {
	public GameObject pinSet;

	ActionMaster actionMaster;

	private Animator animator;
	private PinCounter pinCounter;

	void Start (){
		animator = FindObjectOfType<Animator>();
		pinCounter = GameObject.FindObjectOfType<PinCounter>();
	}

	public void PerformAction(ActionMaster.Action action){
		if(action == ActionMaster.Action.Tidy){
			animator.SetTrigger("tidyTrigger");	 
		} else if (action == ActionMaster.Action.Reset ||action == ActionMaster.Action.EndTurn){
			animator.SetTrigger("resetTrigger");
			pinCounter.Reset();
		} else if (action == ActionMaster.Action.EndGame){
			throw new UnityException ("Dont know how to do that.");
		}
	}
		
	public void RaisePins(){
		foreach(Pin pin in GameObject.FindObjectsOfType<Pin>()){
			pin.RaiseIfStanding();
			Debug.Log("Raising pins");
		}
	}

	public void LowerPins(){
		foreach(Pin pin in GameObject.FindObjectsOfType<Pin>()){
			pin.Lower();
		}
		Debug.Log("lowering pins");
	}

	public void RenewPins(){
		Instantiate (pinSet, new Vector3(0, 0, 1829), Quaternion.identity);
	}
}
