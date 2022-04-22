using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftCycle : MonoBehaviour {

	[SerializeField]
	float moveSpeed =  -1f;
	[SerializeField]
	float leftWayPointX = -11f;
	[SerializeField]
	float rigthWayPointX = 12f;
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector2 (transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
		if(transform.position.x < leftWayPointX){
			transform.position = new Vector2 (rigthWayPointX, transform.position.y);
		}
	}
}
