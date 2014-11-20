using UnityEngine;
using System.Collections;

using System;
using System.Collections.Generic;

public class TurretMachine : MonoBehaviour
{

		enum TurretState
		{
				Idle,
				Tracking,
				Attack
		}

		TurretState curState;
		Dictionary<TurretState, Action> fsm = new Dictionary<TurretState, Action> ();
		TurretData data;
		Transform player;
		float distance;
		Raycast ray;


		// Use this for initialization
		void Start ()
		{
				data = GetComponent<TurretData> ();
				ray = GetComponent<Raycast> ();

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
				LocatePlayer ();
				if (ray.IsSeeing () == true) {
						SetState (TurretState.Attack);
				}
			
		}

		void AttackState ()
		{
				if (ray.IsSeeing () == false) {
						SetState (TurretState.Tracking);
				}
		}



		//helper functions

		void LocatePlayer ()
		{
				distance = Vector3.Distance (transform.position, player.position);
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

	public Transform GetPlayer(){
		return player;
	}
}
