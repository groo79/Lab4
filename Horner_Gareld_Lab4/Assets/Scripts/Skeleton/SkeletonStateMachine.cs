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
	Health health;
	waypoint point;
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
		private Transform[] navPoints;
		int navIndex = 0;

		//variable to call the current wait time in states.
		float waitTime;
	
		//timer used for waiting.
		float timer;

		//bool to tell if player is seen by enemy
		bool iSeeYou = false;
		bool canAttack = false;
		bool isDead = false;
		float speed;
	[SerializeField]
		Transform player;
	//trying to prevent setwaypoint from running more than once.
	bool newWaypointAllowed = true;

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
				health = GetComponent<Health> ();
				waitTime = navPoitWait;
				navIndex = 0;

				

	
		}
	
		// Update is called once per frame
		void Update ()
		{
				timer += Time.deltaTime;
				fsm [curstate].Invoke ();
		if (health.GetHealth() <= 0.0f) {
			SetState(States.death);
			isDead = true;
		}
				
		}
		

		void OnTriggerEnter (Collider other)
		{

				if (newWaypointAllowed == true) {

						if (other.tag == "Waypoint") {
								point = other.gameObject.GetComponent<waypoint>();
								timer = 0f;
								SetWaypoint ();
				newWaypointAllowed = false;

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
		Debug.Log ("Skelly State " + curstate);
		}

		void IdleState ()
		{
				CheckAttack ();
				skelly.Stop ();
				anim.SetFloat ("Speed", 0.0f);
				if (timer >= waitTime) {
						SetState (States.patrol);
				}

		}

		void PatrolState ()
		{
		CheckAttack ();
		Wait ();
				FindSpeed ();
				skelly.speed = data.GetWalk ();
				if (speed <= .001f) {
						anim.SetFloat ("Speed", 0);
				}

				if (timer >= waitTime) {
						FindDestination ();
			newWaypointAllowed = true;
						anim.SetFloat ("Speed", (data.GetWalk () / data.GetRun ()));
				}



		}

		void ChaseState ()
		{
				newWaypointAllowed = false;
				CheckAttack ();
				skelly.SetDestination (player.position);
				skelly.speed = data.GetRun ();
				anim.SetFloat ("Speed", 1f);
		waitTime = chaseEndWait;
				

		}

		void AttackState ()
		{

		anim.SetFloat ("Speed", 0);
		skelly.Stop ();
		anim.SetTrigger ("Attack");
		if (!canAttack) {
			SetState(States.chase);	
		}
		}

		void DeathState ()
		{
		skelly.Stop ();
		anim.SetTrigger ("Die");
		}

		//helper functions

		void FindDestination ()
		{
				Vector3 newTravelPosition = navPoints [navIndex].position;
				skelly.SetDestination (newTravelPosition);
		}

		void SetWaypoint ()
		{
		if (newWaypointAllowed) {
						++navIndex;
						if (navIndex >= navPoints.Length) {
				
								navIndex = 0;
					
						}
						Debug.Log ("Waypoint " + navIndex + " selected");
						newWaypointAllowed = false;
						timer = 0;
				}
		}

		public void setChase(Transform person)
		{
		if (!canAttack) {
			player = person;
			SetState(States.chase);
		}
	}

		void FindSpeed ()
		{
				Vector3 lastPosition = transform.position;
				float dist = Vector3.Distance (lastPosition, transform.position);
				speed = Mathf.Abs (dist) / Time.deltaTime;
		}

	public void ChangeAttackState(Transform person, bool state){
		player = person;
		canAttack = state;
	}

void CheckAttack(){
		if (canAttack) {
			SetState(States.attack);
		}
}
	public bool IsDead(){
		return isDead;
	}
	void targetPlayer(){

	}	

	void Wait(){
		if (point.getPause ()) {
						waitTime = endPointWait;		
				} else if (point.getPause () == false) {
			waitTime = endPointWait;
		}
	}

}
