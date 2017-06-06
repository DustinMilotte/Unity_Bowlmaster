using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {
	public Text [] rollTexts, frameTexts;
		
	void Start () {
		rollTexts[0].text = "X";
		frameTexts[0].text = "0";
	}
	
	public void FillRolls (List <int> rolls){
		string rollsString = FormatRolls(rolls);
		for (int i=0; i < rollsString.Length; i++){
			rollTexts[i].text = rollsString[i].ToString();
		}
	}

	public void FillFrames(List <int> frames){
		for (int i=0; i < frames.Count; i++){
			frameTexts[i].text = frames[i].ToString();
		}
	}

	public static string FormatRolls(List <int> rolls){
		string output = "";
		int lastRoll=0;

		foreach(int roll in rolls){
			if(roll == 0){
				output += '-';
			} else if(output.Length >= 18 && roll == 10){					// Special case for last frame.
					output += "X";
			} else if(roll == 10 && output.Length % 2 == 0){				// If it's a strike.
				output += "X ";
			} else if((output.Length % 2 != 0 || output.Length == 20)		// If it's a spare.
				&& (roll + lastRoll == 10)){								
				output += '/'; 
			} else {														// All other bowls.
				string currentRoll = roll.ToString();
				output += currentRoll;
			}
		lastRoll= roll;														// Update last roll.
		}
		return output;
	}
}
