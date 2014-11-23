using UnityEngine;
using System.Collections;

public class SkeletonView : MonoBehaviour {

	//------------------------------------------------------------------------------
	//Name: Gareld Horner
	//Date: 11/22/14
	//Credit: Prototyping 1 Experiment 4, Unity Scripting API
	//Purpose: target player if within trigger.
	//------------------------------------------------------------------------------
	[SerializeField]
	SkeletonStateMachine skelly;
	[SerializeField]
	SkeletonData data;
	[SerializeField]
	Health health;
	Transform player;
	[SerializeField]
	SphereCollider col;
	[SerializeField]
	bool inView;


	// Use this for initialization
	void Start () {




	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider other){
		if (other.tag == "Player") {
			//Debug.Log ("Player in viewing area");
			inView = false;
						Vector3 direction = other.transform.position - transform.position;
						float angle = Vector3.Angle (direction, transform.forward);
			if (angle< data.GetAngle() * .05f){
				//Debug.Log ("Player at angle " + angle);
				RaycastHit hit;
				if (Physics.Raycast(transform.position + transform.up, direction.normalized, out hit)){
					if (hit.collider.tag == "Player"){
						//Debug.Log("skelly saw the lady"); 
						skelly.setChase(other.transform);
						inView = true;
					}
				}
		}
	}

	

}
				}
