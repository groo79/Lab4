using UnityEngine;
using System.Collections;

public class Melee : MonoBehaviour {

	int damageDealt = 50;
	
	float distance;

	RaycastHit hit;
	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () { 

		if (Input.GetButton(" Fire1 ")) {
			
			if (Physics.Raycast (transform.position, transform.forward, out hit)){
				
				distance = hit.distance;

			}
			
		}
	
	}


}
 