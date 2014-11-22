using UnityEngine;
using System.Collections;

using System;
using System.Collections.Generic;

public class TurretMachine : MonoBehaviour
{
		//***********************************************
		//Name Gareld Horner & Aaron Barnard
		//Date 11/18/2014
		//Credit: Unity Answers, Scripting API.
		//purpose set data model for turret state machine
		//***********************************************

		enum TurretState
		{
				Idle,
				Tracking,
				Attack
		}

		private TurretState curState;
		private Dictionary<TurretState, Action> fsm = new Dictionary<TurretState, Action> ();
		private TurretData data;
		private Transform player;
		private float distance;
		private Raycast ray;
		private CannonBallRun shooster;


		// Use this for initialization
		void Start ()
		{
				data = GetComponent<TurretData> ();
				ray = GetComponent<Raycast> ();
				shooster = GetComponent<CannonBallRun> ();

				fsm.Add (TurretState.Idle, IdleState);
				fsm.Add (TurretState.Tracking, TrackingState);
				fsm.Add (TurretState.Attack, AttackState);

				curState = TurretState.Idle;

		}

		// Update is called once per frame
		void Update ()
		{
				if (curState != null) {
						fsm [curState].Invoke ();
				}
		}

		void OnTriggerStay (Collider other)
		{
				if (other.tag == "Player" && ray.IsSeeing () == false) {
						player = other.gameObject.transform;
						SetState (TurretState.Tracking);

				} 
		}

		void OnTriggerExit (Collider other)
		{
				SetState (TurretState.Idle);
		}

		//state functions

		void SetState (TurretState newState)
		{
				if (newState != null) {
						curState = newState;
				} else {
						curState = TurretState.Idle;
				}
				Debug.Log (curState);
		}

		void IdleState ()
		{


		}

		void TrackingState ()
		{
				shooster.GoblobberGoesBoom (false);
				LocatePlayer ();
				if (ray.IsSeeing () == true) {
						SetState (TurretState.Attack);
				}
			
		}

		void AttackState ()
		{
				shooster.GoblobberGoesBoom (true);
				if (ray.IsSeeing () == false) {
						SetState (TurretState.Tracking);
						
				}
		}



		//helper functions

		void LocatePlayer ()
		{
				Vector3 target = player.position;
				target.y = 0;
				distance = Vector3.Distance (transform.position, target);
				Vector3 tarDir = player.position - transform.position;
				Vector3 forward = transform.forward;
				float angle = Vector3.Angle (tarDir, forward);
				if (angle <= data.GetAngle ()) {
						tarDir.y = 0;
						float step = data.GetRotationSpeed () * Time.deltaTime;
						Vector3 newDir = Vector3.RotateTowards (transform.forward, tarDir, step, 0.0F);
						Debug.DrawRay (transform.position, newDir, Color.red);
						transform.rotation = Quaternion.LookRotation (newDir);
						//Debug.Log (distance + " meters to player");
				}
		}

		//accessors

		public float GetDistance ()
		{
				return distance;
		}

		public Transform GetPlayer ()
		{
				return player;
		}
}
