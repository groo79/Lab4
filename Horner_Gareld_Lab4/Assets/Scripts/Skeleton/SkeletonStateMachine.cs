using UnityEngine;
using System.Collections;

using System;
using System.Collections.Generic;

public class SkeletonStateMachine : MonoBehaviour
{

		//***********************************************
		//Name Gareld Horner
		//Date 11/20/2014
		//credit: Skeletons Pack by bshgame available at http://u3d.as/2fA in Unity asset store.
		//state machine for skeleton enemy
		//***********************************************

		enum States
		{
				idle,
				patrol,
				chase,
				attack,
				death
		}

		States curstate;
		Dictionary<States, Action> fsm = new Dictionary<States, Action> ();
		NavMeshAgent skelly;
		SkeletonData data;
		Raycast vision;
		Animator anim;
		[SerializeField]
		private float
				navPoitWait;
		[SerializeField]
		private float
				endPointWait;
		[SerializeField]
		private float
				chaseEndWait;
		[SerializeField]
		private Transform[]
				navPoints;
		int navIndex = 0;

		//variable to call the current wait time in states.
		float waitTime;
	
		//timer used for waiting.
		float timer;

		//bool to tell if player is seen by enemy
		bool iSeeYou = false;
		float speed;
	Vector3 player;

		// Use this for initialization
		void Start ()
		{

				fsm.Add (States.idle, IdleState);
				fsm.Add (States.patrol, PatrolState);
				fsm.Add (States.chase, ChaseState);
				fsm.Add (States.attack, AttackState);
				fsm.Add (States.death, DeathState);

				skelly = GetComponent<NavMeshAgent> ();
				data = GetComponent<SkeletonData> ();
				vision = GetComponent<Raycast> ();
				anim = GetComponent<Animator> ();
				waitTime = navPoitWait;
				navIndex = 0;

				

	
		}
	
		// Update is called once per frame
		void Update ()
		{
				timer += Time.deltaTime;
				fsm [curstate].Invoke ();
		}

		void OnTriggerEnter (Collider other)
		{

				if (curstate != States.chase) {

						if (other.tag == "Waypoint") {

								timer = 0f;
								SetWaypoint ();

						}
				}	
		}

		void OnTriggerExit (Collider other)
		{
				if (other.tag == "Player") {
						if (curstate == States.chase) {
								SetState (States.idle);
						}
				}

		}

		//state functions

		void SetState (States newState)
		{
				if (newState != null) {
						curstate = newState;	
				} else {
						curstate = States.idle;
				}
		}

		void IdleState ()
		{
				skelly.Stop ();
				anim.SetFloat ("Speed", 0.0f);
				if (timer >= endPointWait) {
						SetState (States.patrol);
				}

		}

		void PatrolState ()
		{
				FindSpeed ();
				skelly.speed = data.GetWalk ();
				if (speed <= .001f) {
						anim.SetFloat ("Speed", 0);
				}

				if (timer >= waitTime) {
						FindDestination ();
						anim.SetFloat ("Speed", (data.GetWalk () / data.GetRun ()));
				}



		}

		void ChaseState ()
		{
				skelly.SetDestination (player);
				skelly.speed = data.GetRun ();
				anim.SetFloat ("Speed", 1f);
				

		}

		void AttackState ()
		{

		}

		void DeathState ()
		{

		}

		//helper functions

		void FindDestination ()
		{
				Vector3 newTravelPosition = navPoints [navIndex].position;
				skelly.SetDestination (newTravelPosition);
		}

		void SetWaypoint ()
		{
				++navIndex;
				Debug.Log ("Waypoint " + navIndex + " selected");
			
				if (navIndex >= navPoints.Length) {
				
						navIndex = 0;
					
				}
		}

		public void CanSee (Transform person, bool canSee)
		{
				if (canSee) {
						player = person.position;
						SetState (States.chase);
						if (!canSee) {
								SetState(States.patrol);
								navIndex = 0;

						}
				}	

		}

		void FindSpeed ()
		{
				Vector3 lastPosition = transform.position;
				float dist = Vector3.Distance (lastPosition, transform.position);
				speed = Mathf.Abs (dist) / Time.deltaTime;
		}

}
