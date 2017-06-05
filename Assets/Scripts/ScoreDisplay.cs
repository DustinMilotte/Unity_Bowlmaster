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
		//Your code here
		return output;
	}
//>>>>>>> 83fa59f1caaf457a6e1d46f06b4bb88b40b697f4
}
