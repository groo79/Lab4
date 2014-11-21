using UnityEngine;
using System.Collections;

public class Raycast : MonoBehaviour
{

		/// <summary>
		/// Name: Gareld Horner
		/// Date: 11/17/2014
		/// Credit: Unity Scripting API on raycasting
		/// Purpose: provide a racasting script that is versatile and can be used for many things
		/// </summary>

		[SerializeField]
		private float
				length = 1.0f;
		private bool seeing = false;
		RaycastHit hit;
		[SerializeField]
		private float
				heightAdjust = 0.0f;
		private Vector3 height;
		// Use this for initialization
		void Start ()
		{
			
		}
	
		// Update is called once per frame
		void Update ()
		{
				height = new Vector3 (transform.position.x, transform.position.y + heightAdjust, transform.position.z);
				if (Physics.Raycast (height, transform.forward, out hit, length)) {
						//Debug.Log("I see something");
						if (hit.collider.tag == "Player") {
								seeing = true;
								Debug.Log ("Seeing Player");
						} else {
								seeing = false;
						}
				} else {
						seeing = false;
				}
				Debug.DrawRay (height, transform.forward * length, Color.green);
		}

		public bool IsSeeing ()
		{
				return seeing;
		}

		public string GetTag ()
		{
				return hit.collider.tag;
		}
}
