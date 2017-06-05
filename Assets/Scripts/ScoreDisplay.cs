using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	public void FillRollCard (List <int> rolls){
		rolls [-1] = 5;
	}
}
