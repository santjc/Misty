﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 2f;
    public float maxSpeed = 4f;
    public float jumpForce = 2f;
    public Joystick joyStick;
    private bool isGrounded;

    private Rigidbody2D rb;
    private Vector3 moveVelocity;
    Vector3 moveInput;

    public Animator animator;
    // Start is called before the first frame update
    void Start () {
        rb = GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void Update () {

        
        if (joyStick.Horizontal >= .2f) {
            moveInput.x = speed;
        }
        else if(joyStick.Horizontal <= -.2f){
            moveInput.x = -speed;
        }else{
            moveInput.x = 0;
        }
        moveVelocity.x = moveInput.x * Time.deltaTime;
        if (isGrounded == true) {
            if (joyStick.Vertical > .5f) {
                rb.AddForce (new Vector2 (0, jumpForce), ForceMode2D.Impulse);
                isGrounded = false;
            }
        }

    }

    private void FixedUpdate () {
        transform.position += moveVelocity;

        if(rb.velocity.magnitude > maxSpeed){
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
        Animate ();
    }

    void Animate () {
        animator.SetFloat ("Horizontal", moveInput.x);
        animator.SetFloat ("Speed", moveVelocity.magnitude);
        animator.SetBool ("Grounded", isGrounded);

    }

    private void OnCollisionEnter2D (Collision2D other) {
        if (other.gameObject.tag == "Floor") {
            isGrounded = true;
        }
    }
}