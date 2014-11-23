using UnityEngine;
using System.Collections;

public class SkeletonAttack : MonoBehaviour
{

		//------------------------------------------------------------------------------
		//Name: Gareld Horner
		//Date: 11/22/14
		//Credit: Prototyping 1 Experiment 4, Unity Scripting API
		//Purpose: target player if within trigger.
		//------------------------------------------------------------------------------
		[SerializeField]
		SkeletonStateMachine
				skelly;
		[SerializeField]
		SkeletonData
				data;
		Transform player;

		// Use this for initialization
		void Start ()
		{

		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		void OnTriggerStay (Collider other)
		{
				if (other.tag == "Player") {
						skelly.ChangeAttackState (true);
				} else {
						skelly.ChangeAttackState (false);
				}
		}

		void OnTriggerExit (Collider other)
		{
				skelly.ChangeAttackState (false);

		}
}