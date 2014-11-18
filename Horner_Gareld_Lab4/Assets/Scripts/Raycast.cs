using UnityEngine;
using System.Collections;

public class Raycast : MonoBehaviour {

	/// <summary>
	/// Name: Gareld Horner
	/// Date: 11/17/2014
	/// 
	/// Purpose: provide a racasting script that is versatile and can be used for many things
	/// </summary>

	[SerializeField]
	private float length = 1.0f;
	private bool seeing = false;
	RaycastHit hit;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Physics.Raycast(transform.position, transform.forward, out hit, length)){
			Debug.Log("I see something");
		}
		Debug.DrawRay (transform.position, transform.forward * length, Color.green);
	}

	public bool IsSeeing(){
		return seeing;
	}
	public string GetTag(){
		return hit.collider.tag;
	}
}
