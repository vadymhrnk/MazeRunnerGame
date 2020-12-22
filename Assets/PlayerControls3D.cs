using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls3D : MonoBehaviour
{
    public float speed = 2.0f;

    public float jumpSpeed = 8.0f;

    public float gravity = 20.0f;

    private Vector3 moveDir = Vector3.zero;

    private CharacterController controller;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        if (controller.isGrounded)
        {
            moveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDir = transform.TransformDirection(moveDir);
            moveDir *= speed;
        }

        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        { 
            moveDir.y = jumpSpeed;
        }
        moveDir.y -= gravity * Time.deltaTime;

        controller.Move(moveDir * Time.deltaTime);
    }
}