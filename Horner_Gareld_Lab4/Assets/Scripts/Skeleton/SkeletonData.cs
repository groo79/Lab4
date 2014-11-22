using UnityEngine;
using System.Collections;

public class SkeletonData : MonoBehaviour {

	/// <summary>
	/// Name: Gareld Horner
	/// Date: 11/20/2014
	/// credit: Skeletons Pack by bshgame available at http://u3d.as/2fA in Unity asset store.
	/// Purpose: data for skeleton enemy
	/// </summary>

	[SerializeField]
	private float WalkSpeed;
	[SerializeField]
	private float RunSpeed;
	[SerializeField]
	float angleOfView;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public float GetAngle(){
		return angleOfView;
	}
	public float GetRun(){
		return RunSpeed;
	}

	public float GetWalk(){
		return WalkSpeed;
	}
}
