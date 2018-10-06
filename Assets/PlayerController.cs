using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float turnSpeed;
    public float speed;
    public Transform pivot;

    private float turn;
    private Vector3 movement;

    public Transform canonLeft;
    public Transform canonRight;
    public GameObject rocket;
    public float shootPower;

    private bool isLeft = true;


    // Use this for initialization
    void Start()
    {
        movement = Vector3.zero;
        turn = 0;
    }

    // Update is called once per frame
    void Update()
    {
        move();

        shoot();

    }

    private void shoot()
    {
        GameObject myRocket;
        if (Input.GetKeyDown("mouse 0"))
        {
            if (isLeft)
            {
                myRocket = Instantiate(rocket, canonLeft.position, Quaternion.identity);
                isLeft = !isLeft;
            }
            else
            {
                myRocket = Instantiate(rocket, canonRight.position, Quaternion.identity);
                isLeft = !isLeft;
            }

            myRocket.GetComponent<Rigidbody>().AddForce(transform.forward * shootPower, ForceMode.Acceleration);
            Destroy(myRocket, 10);
        }
    }

    private void move()
    {
        turn = Mathf.Lerp(turn, turnSpeed * Input.GetAxis("Horizontal"), Time.deltaTime * 1f);
        transform.RotateAround(pivot.transform.position, Vector3.up, turn);

        movement = Vector3.Lerp(movement, Vector3.forward * speed * Input.GetAxis("Vertical"), Time.deltaTime * 1f);
        movement.y -= 0.1f * Time.deltaTime;
        //movement.z = Mathf.Clamp01(movement.z);
        GetComponent<CharacterController>().Move(transform.TransformVector(movement));
        
        
    }
}