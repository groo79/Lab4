using UnityEngine;
using System.Collections;

public class ActorStateMachine : MonoBehaviour
{

	Animator anim;
	private float speed = 1.0f;
	[SerializeField]
	private float maxDeltaVel = 10.0f;

		// Use this for initialization
		void Start ()
		{
				anim = GetComponent<Animator> ();
				if (anim == null) {
						Debug.Log ("animator not assigned to actor");
				}
	
		}
	
		// Update is called once per frame
		void Update ()
		{
		float h = Input.GetAxis("Horizontal");
		float y = Input.GetAxis ("Vertical");
		anim.SetFloat ("Speed", y);
		anim.SetFloat ("Direction", h);

		transform.Rotate (0, h, 0);

		Vector3 targetDirection = transform.forward * y;
		Vector3 targetVelocity = targetDirection * speed;
		Vector3 deltaVelocity = targetVelocity - rigidbody.velocity;

		deltaVelocity.x = Mathf.Clamp (deltaVelocity.x, -maxDeltaVel, maxDeltaVel);
		deltaVelocity.z = Mathf.Clamp (deltaVelocity.z, -maxDeltaVel, maxDeltaVel);
		deltaVelocity.y = Mathf.Clamp (deltaVelocity.y, 0, 0);

		rigidbody.AddForce (deltaVelocity, ForceMode.VelocityChange);

		}
}
