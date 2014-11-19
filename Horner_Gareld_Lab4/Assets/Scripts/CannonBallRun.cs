using UnityEngine;
using System.Collections;

public class BallisticVelocity : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
//		rigidbody.AddForce(transform.forward  force, ForceMode.Impulse);
//		rigidbody.AddForce(transform.up  force, ForceMode.Impulse);
//		rigidbody.AddTorque(torque, ForceMode.Force);
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		shotTime += Time.deltaTime;
		if(shotTime >= fireRate)
		{
			if(!(name.GetComponent("Tower") as Tower).canAim)
			{
				GameObject cannonBall = Instantiate(mortar, gunTip.position, Quaternion.identity) as GameObject;
				cannonBall.rigidbody.velocity = BallisticVelocity(target, shootAngle);
				Destroy(cannonBall, 10); // cannonball disappears after 10 seconds
				shotTime = 0.0f;
			}
		}
	}
	Vector3 BallisticVelocity(Transform target, float angle)
	{
		Vector3 dir = target.position - gunTip.position; // get Target Direction
		float height = dir.y; // get height difference
		dir.y = 0; // retain only the horizontal direction
		float dist = dir.magnitude; // get horizontal distance
		float a = angle * Mathf.Deg2Rad; // Convert angle to radians
		dir.y = dist * Mathf.Tan(a); // set dir to the elevation angle.
		dist += height / Mathf.Tan(a); // Correction for small height differences
		// Calculate the velocity magnitude
		float velocity = Mathf.Sqrt(dist * Physics.gravity.magnitude / Mathf.Sin(2 * a));
		return velocity * dir.normalized; // Return the velocity vector.

	}
	

}