using UnityEngine;
using System.Collections;

public class ActorData : MonoBehaviour
{

	//***********************************************
	//Name Gareld Horner
	//Date 11/18/2014
	//
	//purpose set data model for turret state machine
	//***********************************************

		[SerializeField]
		private float
				speed = 1.0f;
		[SerializeField]
		private float
				runSpeed = 3.0f;
		[SerializeField]
		private float
				maxDeltaVel = 10.0f;
		[SerializeField]
		float
				rotationSpeed;

		//accessors

		public float GetSpeed ()
		{
				return speed;
		}

		public float GetRunSpeed ()
		{
				return runSpeed;
		}

		public float GetMaxVel ()
		{
				return maxDeltaVel;
		}

		public float GetRotateSpeed ()
		{
				return rotationSpeed;
		}
}
