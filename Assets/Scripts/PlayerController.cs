using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 2f;
    public float jumpForce = 5f;
    public Joystick joyStick;
    public float bulletForce = 5f;
    public GameObject bulletPrefab;
    public Transform firePoint;
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
        moveVelocity = moveInput * speed * Time.deltaTime;
        if (isGrounded == true) {
            if (Input.GetButtonDown ("Jump")) {
                rb.AddForce (new Vector2 (0, jumpForce), ForceMode2D.Impulse);
                isGrounded = false;
            }
        }

    }

    private void FixedUpdate () {
        transform.position += moveVelocity;
        Animate ();
    }

    void Animate () {
        animator.SetFloat ("Horizontal", moveInput.x);
        animator.SetFloat ("Speed", moveVelocity.magnitude);
        animator.SetBool ("Grounded", isGrounded);

    }

    void Shoot () {
        Vector3 dir = Camera.main.ScreenToWorldPoint (Input.mousePosition);

        dir = dir - transform.position;
        float angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;

        GameObject bullet = Instantiate (bulletPrefab, transform.position, transform.rotation) as GameObject;
        bullet.AddComponent<Rigidbody2D> ().gravityScale = 0;
        bullet.GetComponent<Rigidbody2D> ().velocity = new Vector2 (dir.x * bulletForce, dir.y * bulletForce);
        bullet.transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
        Destroy (bullet, 3);
    }

    private void OnCollisionEnter2D (Collision2D other) {
        if (other.gameObject.tag == "Floor") {
            isGrounded = true;
        }
    }
}