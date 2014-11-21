using UnityEngine;
using System.Collections;

public class CannonBallRun : MonoBehaviour {

	private float shotTime;
	
	private float fireRate = 5.0f;

	private float shootAngle = 45;

	[SerializeField]
	private Rigidbody cannonBall;

	//private Vector3 target = Player.Position;

	private float canAim;

	private TurretMachine gobLobber;

	//private float distance = TurretMachine.GetDistance; 
	
	// Use this for initialization
	void Start () {

		gobLobber = GetComponent<TurretMachine> ();
		
	}
	
	// Update is called once per frame
	void Update ()
	{
				shotTime += Time.deltaTime;

				if (shotTime >= fireRate) {

						float velocity = Mathf.Sqrt (gobLobber.GetDistance () * Physics.gravity.magnitude);//determine velocity required

						//Instantiate(GameObject.cannonBall, new Vector3(i * 2.0F, 0, 0), Quaternion.identity) as Transform;//instantiate cannonball
						//i++;

						Rigidbody clone;

						clone = Instantiate (cannonBall, transform.position, transform.rotation) as Rigidbody;

						clone.velocity = transform.TransformDirection (Vector3.forward * velocity);

						//on impact destroy game object((created new script and attached it to the cannonBall game object))

				}

		}


	

	
	
	//Determine distance to target
		
	//Determine force or velocity required to reach target
			
	//Instantiate projectile at velocity determined
			
	//On impact apply damage and destroy projectile

	

}