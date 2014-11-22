using UnityEngine;
using System.Collections;

public class SkeletonView : MonoBehaviour {

	//------------------------------------------------------------------------------
	//Name: Gareld Horner
	//Date: 11/22/14
	//Credit: Prototyping 1 Experiment 4, Unity Scripting API
	//Purpose: target player if within trigger.
	//------------------------------------------------------------------------------

	SkeletonStateMachine skelly;
	SkeletonData data;
	Transform player;

	// Use this for initialization
	void Start () {
		skelly = GetComponentInParent<SkeletonStateMachine> ();
		data = GetComponentInParent<SkeletonData> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider other){
		if (other.tag == "Player") {
						Vector3 target = other.transform.position;
						target.y = 0;
						float distance = Vector3.Distance (transform.position, target);
						Vector3 tarDir = other.transform.position - transform.position;
						Vector3 forward = transform.forward;
						float angle = Vector3.Angle (tarDir, forward);
						if (angle <= data.GetAngle ()) {
								Debug.Log ("Skelly Loves Ladies");
								skelly.CanSee (other.transform, true);
						}
				} else {
			skelly.CanSee(other.transform, false);
		}
	}

	
	public Transform GetPlayer(){
		return player;
	}
}
