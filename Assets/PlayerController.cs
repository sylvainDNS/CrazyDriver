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
    private Vector3 move;

    // Use this for initialization
    void Start()
    {
        move = Vector3.zero;
        turn = 0;
    }

    // Update is called once per frame
    void Update()
    {
        turn = Mathf.Lerp(turn, turnSpeed * Input.GetAxis("Horizontal"), Time.deltaTime * 1f);
        transform.RotateAround(pivot.transform.position, Vector3.up, turn);

        move = Vector3.Lerp(move, Vector3.forward * speed * Input.GetAxis("Vertical"), Time.deltaTime * 1f);
        move.y = 0.1f * Time.deltaTime;
        move.z = Mathf.Clamp01(move.z);
        GetComponent<CharacterController>().Move(transform.TransformVector(move));
    }

    private void FixedUpdate()
    {
       
    }
}