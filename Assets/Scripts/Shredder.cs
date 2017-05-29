using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour {

	void OnTriggerExit (Collider obj){
		GameObject objExited = obj.gameObject;

		if(objExited.GetComponent<Pin>()){
			Destroy(objExited);
		}
	}
}
