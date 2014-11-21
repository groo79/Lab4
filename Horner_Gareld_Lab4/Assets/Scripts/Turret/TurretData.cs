using UnityEngine;
using System.Collections;

public class TurretData : MonoBehaviour
{

		//***********************************************
		//Name Gareld Horner
		//Date 11/18/2014
		//
		//purpose set data model for turret state machine
		//***********************************************


		//inspector variables
		[SerializeField]
		float
				fieldOfViewAngle = 5.0f;
		[SerializeField]
		float
				timeUntilFire = 0.5f;
		[SerializeField]
		float
				rotationSpeed = 1.0f;

		//internal variables
		float timer;
		bool timerRunning;



		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		//accessors
		public float GetAngle ()
		{
				return fieldOfViewAngle;
		}

		public float GetTimeUntilFire ()
		{
				return timeUntilFire;
		}

		public float GetTimer ()
		{
				return timer;
		}

		public bool IsTimerRunning ()
		{
				return timerRunning;
		}

		public float GetRotationSpeed ()
		{
				return rotationSpeed;
		}

		//mutators

		public void StartTimer ()
		{
				timerRunning = true;
		}

		public void StopTimer ()
		{
				timerRunning = false;
		}
}
