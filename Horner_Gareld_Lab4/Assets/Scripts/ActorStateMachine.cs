using UnityEngine;
using System.Collections;

using System;
using System.Collections.Generic;

public class ActorStateMachine : MonoBehaviour
{

		enum PlayerStates
		{
				Idle,
				Walking,
				Running
		}

		PlayerStates curstate;
		Dictionary<PlayerStates, Action> fsm = new Dictionary<PlayerStates, Action> ();
		Animator anim;
		private float maxDeltaVel;
		ActorData data;

		// Use this for initialization
		void Start ()
		{
				data = GetComponent<ActorData> ();
				anim = GetComponent<Animator> ();
				if (anim == null) {
						Debug.Log ("animator not assigned to actor");
				}
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				float h = Input.GetAxis ("Horizontal");
				float y = Input.GetAxis ("Vertical");
				anim.SetFloat ("Speed", y);
				anim.SetFloat ("Direction", h);

				transform.Rotate (0, h * data.GetRotateSpeed (), 0);

				Vector3 targetDirection = transform.forward * y;
				Vector3 targetVelocity = targetDirection * data.GetSpeed ();
				Vector3 deltaVelocity = targetVelocity - rigidbody.velocity;

				maxDeltaVel = data.GetMaxVel ();

				deltaVelocity.x = Mathf.Clamp (deltaVelocity.x, -maxDeltaVel, maxDeltaVel);
				deltaVelocity.z = Mathf.Clamp (deltaVelocity.z, -maxDeltaVel, maxDeltaVel);
				deltaVelocity.y = Mathf.Clamp (deltaVelocity.y, 0, 0);

				rigidbody.AddForce (deltaVelocity, ForceMode.VelocityChange);

		}

		//state functions

		void SetState (PlayerStates newState)
		{
				if (newState != null) {
						curstate = newState;
						Debug.Log (curstate);
				} 
				else 
				{
						curstate = PlayerStates.Idle;
				}
		}

		void IdleState ()
		{

		}



		//helper functions

	void MovePlayer(float speed){

	}
}
