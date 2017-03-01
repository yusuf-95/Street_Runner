﻿using UnityEngine;
using System.Collections;

public class PlayerMotor : MonoBehaviour {

    private CharacterController controller;
    private Vector3 moveVector;

    private float speed = 10.0f;
    private float verticalVelocity = 0.0f;
    private float gravity = 12.0f;
    public static bool TriggerHit = false;
    public static bool ResetBarrel = false;

    // Use this for initialization
    void Start () {

        controller = GetComponent<CharacterController>();

	}
	
	// Update is called once per frame
	void Update () {

        moveVector = Vector3.zero;

        //if (controller.isGrounded)
        //{
        //    verticalVelocity = -0.5f;
        //}
        //else
        //{
        //    verticalVelocity -= gravity * Time.deltaTime;
        //}
        moveVector.x = Input.GetAxisRaw("Horizontal") * speed;

        //moveVector.y = verticalVelocity;

        moveVector.z = speed;

        controller.Move(Vector3.forward * speed * Time.deltaTime);

	}

}
