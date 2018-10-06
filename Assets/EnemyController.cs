using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public float movement;

    private GameObject player;

    public float frequence;
    public float shootPower;
    public Transform canon;
    public GameObject rocket;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        StartCoroutine(shoot());
    }

    void Update()
    {
        move();
    }

    private void move()
    {
        transform.LookAt(player.transform.position);
        movement *= Time.deltaTime;

        transform.Translate(movement, 0, speed);
    }

    IEnumerator shoot()
    {
        while (true)
        {
            GameObject myRocket = Instantiate(rocket, canon.position, Quaternion.identity);

            myRocket.GetComponent<Rigidbody>().AddForce(transform.forward * shootPower, ForceMode.Acceleration);
            Destroy(myRocket, 4);

            yield return new WaitForSeconds(frequence);
        }
    }
}