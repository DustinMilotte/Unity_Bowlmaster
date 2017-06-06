using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using System.Linq;

[TestFixture]
public class ScoreDisplayTest {
	
	[Test]
	public void T00PassingTest () {
		Assert.AreEqual (1, 1);
	}

	[Test]
	public void T01Bowl1 (){
		int[] rolls = {1};
		string rollsString = "1";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls (rolls.ToList()));
	}

	[Test]
	public void T02Bowl12 (){
		int[] rolls = {1,2};
		string rollsString = "12";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls (rolls.ToList()));
	}

	[Test]
	public void T03BowlOpenFrames(){
		int[] rolls = {1,2, 3,4, 5,3, 7,1};
		string rollsString = "12345371";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls (rolls.ToList()));
	}

	[Test]
	public void T04BowlSpare (){
		int[] rolls = {1,9};
		string rollsString = "1/";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls (rolls.ToList()));
	}

	[Test]
	public void T05BowlStrike (){
		int[] rolls = {10};
		string rollsString = "X ";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls (rolls.ToList()));
	}

	[Test]
	public void T06BowlTwoStrikes (){
		int[] rolls = {10,10};
		string rollsString = "X X ";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls (rolls.ToList()));
	}

	[Test]
	public void T07BowlMixedabcd (){
		int[] rolls = {10,10, 2,8, 10, 3,7};
		string rollsString = "X X 2/X 3/";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls (rolls.ToList()));
	}

	[Test]
	public void T08Bowl9FramesMixed (){
		int[] rolls = {1,9, 10, 2,3, 5,4, 10, 10, 2,8, 3,7, 10};
		string rollsString = "1/X 2354X X 2/3/X ";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls (rolls.ToList()));
	}

	[Test]
	public void T09TenthFrameX12 (){
		int[] rolls = {1,9, 10, 2,3, 5,4, 10, 10, 2,8, 3,7, 10, 10,1,2};
		string rollsString = "1/X 2354X X 2/3/X X12";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls (rolls.ToList()));
	}

	[Test]
	public void T10TenthFrame283 (){
		int[] rolls = {1,9, 10, 2,3, 5,4, 10, 10, 2,8, 3,7, 10, 2,8,3};
		string rollsString = "1/X 2354X X 2/3/X 2/3";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls (rolls.ToList()));
	}

	[Test]
	public void T11TenthFrameGutters (){
		int[] rolls = {1,9, 10, 2,3, 5,4, 10, 10, 2,8, 3,7, 10, 0,0};
		string rollsString = "1/X 2354X X 2/3/X 00";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls (rolls.ToList()));
	}

	[Test]
	public void T12PerfectGame (){
		int[] rolls = {10, 10, 10, 10, 10, 10, 10, 10, 10, 10,10,10};
		string rollsString = "X X X X X X X X X XXX";
		Assert.AreEqual (rollsString, ScoreDisplay.FormatRolls (rolls.ToList()));
	}
}