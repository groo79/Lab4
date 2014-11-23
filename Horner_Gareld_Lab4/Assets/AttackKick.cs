using UnityEngine;
using System.Collections;

public class AttackKick : MonoBehaviour {

	[SerializeField]
	private float force = 500;

	public bool Kick = false;

	[SerializeField]
	private float radius = 1.0f;

	public Transform kickTransform;

	private const int enemies = 9;
	
	[SerializeField]
	private GameObject Enemy;

	//private Enemy[]
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		KickForce ();
		kickYouFace ();
	}
	
	void KickForce ()
	{

		Collider[] kickColliders = Physics.OverlapSphere(kickTransform.position, radius, (1 << enemies));
		foreach (Collider hit in kickColliders)
		{
			Debug.Log ("hit");
			Kick = true;
		}
	}
	
	void kickYouFace ()
	{
		if (Kick == true && Input.GetButton ("Fire3"))
			{

			Vector3 dir = Enemy.transform.position - transform.position; dir.y = 0; // keep the force horizontal 
			Enemy.rigidbody.AddForce(dir.normalized * force, ForceMode.Force);
			Debug.Log("I kicked Your face");
		
		}
	}
}