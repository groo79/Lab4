using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour 
{
	/*
	public Vector3 offset;
	public Transform target;
	public float rotateSpeed = 5;//*/

	[SerializeField]
	private float distanceUp;
	[SerializeField]
	private float distanceAway;
	[SerializeField]
	private float smooth;
	[SerializeField]
	private Transform follow;

	private Vector3 targetPosition;
	
	void Start() 
	{
		//offset = transform.position - target.transform.position;
	}

	void LateUpdate()
	{


		targetPosition = follow.position + follow.up * distanceUp - follow.forward * distanceAway;
		Debug.DrawRay ( follow.position, follow.up * distanceUp, Color.red );
		Debug.DrawRay ( follow.position, -1f * follow.forward * distanceAway, Color.blue );
		Debug.DrawLine ( follow.position, targetPosition, Color.magenta );

		transform.position = Vector3.Lerp ( transform.position, targetPosition, Time.deltaTime * smooth );

		transform.LookAt( follow );
	}
	
	/*
	void LateUpdate() 
	{
		float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
		target.transform.Rotate(0, horizontal, 0);
		
		float desiredAngle = target.transform.eulerAngles.y;
		Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
		transform.position = target.transform.position - (rotation * offset);
		
		transform.LookAt(target.transform);
	}//*/
}
