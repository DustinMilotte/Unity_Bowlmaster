using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMaster {
	// Returns a list of cumulative scores, like a normal scorecard.
	public static List<int> ScoreCumulative (List<int> rolls){
		List<int> scoreCumulative = new List<int>();
		int [] temps = new int[10];
		int runningTotal = 0;

		foreach(int frameScore in ScoreFrames(rolls)){
			runningTotal += frameScore;
			scoreCumulative.Add(runningTotal);
		}
		return scoreCumulative;
	}

	// Returns a list of individual frame scores, not cumulative.
	public static List<int> ScoreFrames (List<int> rolls){
		List<int> frameList = new List<int> ();

		int bowls = 1;
		bool isFirstBall = true;
		bool workingOnStrike = false;
		bool workingOnSpare = false;
		bool workingOnTwoStrikes = false;

		foreach (int roll in rolls){
			// First ball, last frame was open.
			if(isFirstBall && !workingOnSpare && !workingOnStrike){
				//It's a strike
				if(rolls[bowls-1] == 10){
					workingOnStrike = true;
					bowls++;
				} else {
					//its not a strike
					isFirstBall = false;
					bowls ++;
				}
     		} 
			// First ball, last frame was a strike.
			else if(isFirstBall && workingOnStrike && !workingOnTwoStrikes){
				//It's a strike
				if(rolls[bowls-1] == 10){
					workingOnTwoStrikes = true;
					bowls++;
				} else {
					//its not a strike
					isFirstBall = false;
					bowls ++;
				}
			}
			//First ball, working on two strikes
			else if(isFirstBall && workingOnTwoStrikes){
				// It's a strike.
				if(rolls[bowls-1] == 10){
					frameList.Add(30);
					bowls++;
				} else {
					// Its not a strike.
					isFirstBall = false;
					workingOnTwoStrikes = false;
					frameList.Add(20 + rolls[bowls-1]);
					bowls ++;
				}
			}
			// First ball, working on a spare.
			else if (isFirstBall && workingOnSpare) {
				frameList.Add(10 + rolls[bowls-1]);
				workingOnSpare = false;
				//If it's a strike
				if(rolls[bowls-1] == 10){
					workingOnStrike = true;
					bowls++;
				} else {
					//its not a strike
					isFirstBall = false;
					bowls ++;
				}

			}
			// Second ball, last frame was open.
			else if(!isFirstBall && !workingOnStrike && !workingOnSpare){
				//If it's an open frame.
				if (rolls[bowls-1] + rolls[bowls-2] < 10){
					frameList.Add(rolls[bowls-1] + rolls[bowls-2]);
					isFirstBall = true;
					bowls++;
				} else if (rolls[bowls-1] + rolls[bowls-2] == 10){
					//If it's a spare.
					workingOnSpare = true;
					isFirstBall = true;
					bowls++;
				}
			}
			// Second ball, last frame was a strike.
			else if(!isFirstBall && workingOnStrike){
				frameList.Add(10 + rolls[bowls-2] + rolls[bowls-1]);
				workingOnStrike = false;
				//If the current frame is a spare.
				if(rolls[bowls-2] + rolls[bowls - 1] == 10){
					isFirstBall = true;
					workingOnSpare = true;
					bowls++;
				} else {
					isFirstBall = true;
					if((frameList.Count + 1) <= 10){
						frameList.Add(rolls[bowls-2] + rolls[bowls-1]);
					}
					bowls++;
				}
			}
		}
		return frameList;
	}
}