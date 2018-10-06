using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketPlayerController : MonoBehaviour {

	public GameObject enemy;
	public GameObject rocket;
	
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == enemy.tag)
		{
			Destroy(collision.gameObject);
			Destroy(gameObject);
		}
		
		if (collision.gameObject.tag == rocket.tag)
		{
			Destroy(collision.gameObject);
			Destroy(gameObject);
		}
	}
}
