//Name Aaron Barnard
//Date 11/18/2014
//Credit unity API and unity tutorials.
//Instantiate arcing projectile that targets the player's position


using UnityEngine;
using System.Collections;

public class CannonBallRun : MonoBehaviour {

	private float shotTime;
	
	[SerializeField]
	private float fireRate = 3.0f;

	private bool Boom = false;

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
				if (Boom) {
						shotTime += Time.deltaTime;

						if (shotTime >= fireRate) {

								float velocity = Mathf.Sqrt (gobLobber.GetDistance () * Physics.gravity.magnitude);//determine velocity required

								//Instantiate(GameObject.cannonBall, new Vector3(i * 2.0F, 0, 0), Quaternion.identity) as Transform;//instantiate cannonball
								//i++;

								Rigidbody clone;

								clone = Instantiate (cannonBall, transform.position, transform.rotation) as Rigidbody;

								clone.velocity = transform.TransformDirection (Vector3.forward * velocity);

								shotTime = 0.0f

								//on impact destroy game object((created new script and attached it to the cannonBall game object))

						}

				}

		public void GoblobberGoesBoom (bool fire){

			Boom = fire;

				}

		}


	

	
	
	//Determine distance to target
		
	//Determine force or velocity required to reach target
			
	//Instantiate projectile at velocity determined
			
	//On impact apply damage and destroy projectile

	

}