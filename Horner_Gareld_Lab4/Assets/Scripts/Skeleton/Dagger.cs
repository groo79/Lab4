using UnityEngine;
using System.Collections;

public class Dagger : MonoBehaviour
{

		//***********************************************
		//Name Gareld Horner
		//Date 11/20/2014
		//
		//Hold data on dagger
		//***********************************************

		[SerializeField]
		int
				damage = 5;

		//accessors

		public int GetDamage ()
		{
				return damage;
		}

}
