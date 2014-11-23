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

	[SerializeField]
	float fineTuneAim = 0.0f;

	private bool Boom = false;

	[SerializeField]
	private Rigidbody cannonBall;
	[SerializeField]
	private Transform barrel;

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

				if (Boom) {
			
					if (shotTime >= fireRate) {
		
					Debug.Log ("fire!!");

					float velocity = Mathf.Sqrt ((gobLobber.GetDistance () + fineTuneAim) * Physics.gravity.magnitude);//determine velocity required

					Rigidbody clone;

					clone = Instantiate (cannonBall, barrel.position, barrel.rotation) as Rigidbody;

					clone.velocity = barrel.TransformDirection (Vector3.forward * velocity);

					shotTime = 0.0f;


				}

			}

		}

		public void GoblobberGoesBoom (bool fire){

			Boom = fire;

				}




	

	
	
	//Determine distance to target
		
	//Determine force or velocity required to reach target
			
	//Instantiate projectile at velocity determined
			
	//On impact apply damage and destroy projectile

	

}