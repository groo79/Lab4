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
		private bool isRunning = false;
		private float moveSpeed;
		[SerializeField]
		private bool
				moving = false;
		[SerializeField]
		private bool
				running = false;

		// Use this for initialization
		void Start ()
		{
				fsm.Add (PlayerStates.Idle, IdleState);
				fsm.Add (PlayerStates.Walking, WalkState);
				fsm.Add (PlayerStates.Running, RunState);
				data = GetComponent<ActorData> ();
				anim = GetComponent<Animator> ();
				SetState (PlayerStates.Idle);
				if (anim == null) {
						Debug.Log ("animator not assigned to actor");
				}
				moveSpeed = data.GetSpeed ();
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				
				fsm [curstate].Invoke ();
				IsRunning ();

		}
	 

		//state functions

		void SetState (PlayerStates newState)
		{
				if (newState != null) {
						curstate = newState;
						Debug.Log (curstate);
				} else {
						curstate = PlayerStates.Idle;
				}
				Debug.Log (curstate);
		}

		void IdleState ()
		{
				MovePlayer ();
				if (moving == true && running == false) {
						SetState (PlayerStates.Walking);
				}
				if (moving == true && running == true) {
						SetState (PlayerStates.Running);
				}

		}

		void WalkState ()
		{
				moveSpeed = data.GetSpeed ();
				MovePlayer ();
				if (moving == false) {
						SetState (PlayerStates.Idle);
				}
				if (moving = true && running == true) {
						SetState (PlayerStates.Running);
				}

		}

		void RunState ()
		{
				moveSpeed = data.GetRunSpeed ();
				MovePlayer ();
				if (moving == false) {
						SetState (PlayerStates.Idle);
				}
				if (moving = true && running == false) {
						SetState (PlayerStates.Walking);
				}
		}



		//helper functions

		void IsRunning ()
		{
				if (Input.GetKeyDown (KeyCode.LeftShift)) {

						anim.SetBool ("Running", true);
						running = true;
				}
				if (Input.GetKeyUp (KeyCode.LeftShift)) {

						anim.SetBool ("Running", false);
						running = false;
				}
		}

		void MovePlayer ()
		{
				IsRunning ();
				float h = Input.GetAxis ("Horizontal");
				float y = Input.GetAxis ("Vertical");
				anim.SetFloat ("Speed", y);
				anim.SetFloat ("Direction", h);

				if (h > 0.01f || h < -0.01f) {
						moving = true;
				}

				if (y > 0.01f || y < -0.01f) {
						moving = true;
				} else {
						moving = false;	
				}


				transform.Rotate (0, h * data.GetRotateSpeed (), 0);
		
				Vector3 targetDirection = transform.forward * y;
				Vector3 targetVelocity = targetDirection * moveSpeed;
				Vector3 deltaVelocity = targetVelocity - rigidbody.velocity;
		
				maxDeltaVel = data.GetMaxVel ();
		
				deltaVelocity.x = Mathf.Clamp (deltaVelocity.x, -maxDeltaVel, maxDeltaVel);
				deltaVelocity.z = Mathf.Clamp (deltaVelocity.z, -maxDeltaVel, maxDeltaVel);
				deltaVelocity.y = Mathf.Clamp (deltaVelocity.y, 0, 0);
		
				rigidbody.AddForce (deltaVelocity, ForceMode.VelocityChange);
		}

		void IsMoving ()
		{
				if (moving == true && running == false) {
						SetState (PlayerStates.Walking);
				} 
				if (moving == true && running == true) {
						SetState (PlayerStates.Running);
				} 
				if (moving == false) {
						SetState (PlayerStates.Idle);
				} 
		}
}
