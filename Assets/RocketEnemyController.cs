using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RocketEnemyController : MonoBehaviour
{
    public GameObject rocket;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (collision.gameObject.tag == rocket.tag)
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}