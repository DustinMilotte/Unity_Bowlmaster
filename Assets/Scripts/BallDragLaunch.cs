﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Ball))]
public class BallDragLaunch : MonoBehaviour {

	private Ball ball;
	private Vector3 dragStart, dragEnd;
	private float startTime, endTime;

	// Use this for initialization
	void Start () {
		ball = GetComponent <Ball>();
	}

	public void MoveStart(float amount){
		if(!ball.inPlay){
			float xPos = Mathf.Clamp(ball.transform.position.x + amount, -45f, 45f);
			float yPos = ball.transform.position.y;
			float zPos = ball.transform.position.z;
			ball.transform.position = new Vector3(xPos, yPos, zPos);
		}
	}

	public void DragStart(){
		// Capture time and position of drag start.
		if(!ball.inPlay){
			dragStart = Input.mousePosition;
			startTime = Time.time;
		}
	}

	public void DragEnd(){
		// Launch the ball.
		if(!ball.inPlay){
			dragEnd = Input.mousePosition;
			endTime = Time.time;

			float dragDuration = endTime-startTime;
	
			//speed = distance / time
			float launchSpeedX = (dragEnd.x - dragStart.x) / dragDuration;
			float launchSpeedZ = (dragEnd.y - dragEnd.z) / dragDuration;

			Vector3 launchVelocity = new Vector3(launchSpeedX, 0, launchSpeedZ);
			ball.Launch(launchVelocity);
		}
	}
}
