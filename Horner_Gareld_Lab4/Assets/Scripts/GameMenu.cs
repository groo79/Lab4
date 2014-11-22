using UnityEngine;
using System.Collections;

public class GameMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	
	}

	void OnMouseEnter()
	{
		renderer.material.color=Color.red;
	}
	
	void OnMouseExit()
	{
		//change text color
		renderer.material.color=Color.white;
	}
	
	void OnMouseUp()
	{
		
		Application.LoadLevel(1);
		
	}
}
