using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	public Ball ball;

	private Vector3 offset;
	private Vector3 startPosition;

	// Use this for initialization
	void Start () {
		offset = transform.position - ball.transform.position;
		startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.z < 1750){
			transform.position = ball.transform.position + offset;
		}
		if(!ball.inPlay){
			transform.position = startPosition;
		}
	}
}
