using UnityEngine;
using System.Collections;

using System;
using System.Collections.Generic;

public class ActorStateMachine : MonoBehaviour
{

		//***********************************************
		//Name Gareld Horner & Aaron Barnard
		//Date 11/18/2014
		/*Credit Prototyping I experiments & Unity API 
	 * Skeleton asset courtesy of unity asset store 
	 * Female warrior Asset courtesy of unity asset store https://www.assetstore.unity3d.com/en/#!/content/2613*/
		//purpose set data model for turret state machine
		//***********************************************

		enum PlayerStates
		{
				Idle,
				Walking,
				Running,
				Death,
				LightAttack,
				HeavyAttack,
				Kick

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
		private Health iNeedABandAid;
		private bool boughtTheFarm = false;
		private int attackButton;

		// Use this for initialization
		void Start ()
		{
				fsm.Add (PlayerStates.Idle, IdleState);
				fsm.Add (PlayerStates.Walking, WalkState);
				fsm.Add (PlayerStates.Running, RunState);
				fsm.Add (PlayerStates.Death, DeathState);
				fsm.Add (PlayerStates.LightAttack, LightAttackState);
				fsm.Add (PlayerStates.HeavyAttack, HeavyAttackState);
				fsm.Add (PlayerStates.Kick, KickState);
				data = GetComponent<ActorData> ();
				anim = GetComponent<Animator> ();
				SetState (PlayerStates.Idle);
				iNeedABandAid = GetComponent<Health> ();
				if (anim == null) {
						Debug.Log ("animator not assigned to actor");
				}
				moveSpeed = data.GetSpeed ();
				if (anim == null) {
						Debug.Log ("No Animator Attached");

				}
		}
	
		// Update is called once per frame
		void Update ()
		{
				
				fsm [curstate].Invoke ();
				IsRunning ();
				if (iNeedABandAid.GetHealth () <= 0) {

						boughtTheFarm = true;
						SetState (PlayerStates.Death);

				}

		
				if (Input.GetButton ("Fire1")) { //combat

						Debug.Log ("Light Attack active");
						SetState (PlayerStates.LightAttack);
			
				}
		
				if (Input.GetButton ("Fire2")) { //combat


						Debug.Log ("Heavy attack active");
						SetState (PlayerStates.HeavyAttack);
			
				}

				if (Input.GetButton ("Fire3")) { //combat
			
			
						Debug.Log ("Kick Active");
						SetState (PlayerStates.Kick);
			
				}
		
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

		void DeathState ()
		{ //combat

				anim.SetBool ("Die", true);
	
		}

		void LightAttackState ()
		{ //combat normal damage

				anim.SetTrigger ("AttackLight");
				SetState (PlayerStates.Idle);
	

		}

		void HeavyAttackState ()
		{ //combat normal damage * 1.5
		
				anim.SetTrigger ("AttackHeavy");
				SetState (PlayerStates.Idle);
		
		
		}
	
		void KickState ()
		{ //combat (no damage just knocked back 2 meters unless emplaced ie. turret)
		
				anim.SetTrigger ("Kick");
				SetState (PlayerStates.Idle);
		
		
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
				if (!boughtTheFarm) {
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
