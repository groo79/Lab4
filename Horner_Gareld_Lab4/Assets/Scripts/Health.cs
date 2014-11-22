//Name Aaron Barnard
//Date 11/18/2014
//Credit unity API and unity tutorials.
//Keep track of health and damage taken by player and enemies.

using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	[SerializeField]
	private int maxHealth;

	[SerializeField]
	private int hitPoints;

	//private int damageDealt;

	// Use this for initialization
	void Start () {

		hitPoints = maxHealth;

		//player hp starting
		//player current hp

		//skeleton hp starting
		//skeleton current hp

		//turret hp starting
		//turret current hp
	
	}
	
	// Update is called once per frame
	void Update () {

	
	
	}

	//cannonball damage
	//skeleton sword damage
	//player sword damage

	public int GetHealth () {

		return hitPoints;

	}

	 public void ApplyBooBoo (int ouchies) {

		hitPoints -= ouchies;

	 }

}
