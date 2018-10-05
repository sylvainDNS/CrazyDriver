using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour {

	public GameObject enemy;
	
	// Use this for initialization
	void Start () {
		
	}
	
	
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == enemy.tag)
		{
			Destroy(collision.gameObject);
			Destroy(gameObject);
		}
	}
}
