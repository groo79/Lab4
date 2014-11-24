// Name: Aaron Barnard
// Date: 11/22/2014
// Credit: Unity Scripting API on raycasting
// Purpose: Store and pass along damage info for weapons

using UnityEngine;
using System.Collections;

public class Damage : MonoBehaviour {


	[SerializeField]
	int damage;

	Health health;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		health = other.gameObject.GetComponent<Health> ();
		if (health != null) {
				
			health.ApplyBooBoo(damage);
	}

}
}
