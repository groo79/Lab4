using UnityEngine;
using System.Collections;

public class CannonBall : MonoBehaviour {

	[SerializeField]
	private int Damage = 50;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter (Collision col)
	{
			Destroy(gameObject);
	}

	public int GetDamage (){

		return Damage;

	}
}
