using UnityEngine;
using System.Collections;

public class waypoint : MonoBehaviour {

	//***********************************************
	//Name Gareld Horner
	//Date 11/20/2014
	//
	//Hold data on Waypoint
	//***********************************************

	[SerializeField]
	private bool longPause;

	public bool getPause(){
		return longPause;
	}
}
