using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleControl : MonoBehaviour {

	[SerializeField]
	float moveSpeed = -5f;

	void Update () {
		transform.position = new Vector2 (transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);	
		if(transform.position.x < -13f){
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.name.Equals ("DinoBody")){
			GameControl.instance.DinoHit();
		}
	}

}
