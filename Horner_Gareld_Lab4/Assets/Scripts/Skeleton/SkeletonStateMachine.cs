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
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				fsm [curstate].Invoke ();
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

		}

		void PatrolState ()
		{

		}

		void ChaseState ()
		{

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
				//Debug.Log ("Waypoint " + navIndex + " selected");
			
				if (navIndex >= navPoints.Length) {
				
						navIndex = 0;
					
				}
		}
}
