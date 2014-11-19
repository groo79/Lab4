using UnityEngine;
using System.Collections;

public class Melee : MonoBehaviour {

	int damageDealt = 50;
	
	 float distance;
	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () { 
	
	}

	if(Input.GetKeyDown(KeyCode.alpha1) {

		var hit : RaycastHit;

		if (Physics.Raycast (transform.position, transform.TransformDirection(Vector3.forward), hit)){

			Distance = hit.distance;

			hit.Transform.SendMessage("ApplyDamage",damageDealt, SendMessageOptions.DontRequireReciever);
		}

	}
}
 