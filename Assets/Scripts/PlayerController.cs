using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 2f;
    public float maxSpeed = 4f;
    public float jumpForce = 3f;
    private bool isGrounded;

    private Rigidbody2D rb;
    float moveInput;

    public GameObject[] steelObj;

    public Animator animator;
    // Start is called before the first frame update
    void Start () {
        rb = GetComponent<Rigidbody2D> ();
        steelObj = GameObject.FindGameObjectsWithTag ("steelObj");
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKey (KeyCode.Z)) {
            SteelPush ();
        }

        if (Input.GetKey (KeyCode.X)) {
            IronPull ();
        }

        Animate ();


    }

    private void FixedUpdate () {
        moveInput = Input.GetAxisRaw ("Horizontal");
        rb.velocity = new Vector2((moveInput) * maxSpeed, rb.velocity.y);


        
        if (rb.velocity.magnitude > maxSpeed) {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
        

    }

    public void Jump () {
        if (isGrounded == true) {
            rb.AddForce (Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    void Animate () {
        animator.SetFloat ("Horizontal", moveInput);
        animator.SetFloat ("Speed", rb.velocity.magnitude);
        animator.SetBool ("Grounded", isGrounded);

    }

    private void OnCollisionEnter2D (Collision2D other) {
        if (other.gameObject.tag == "Floor") {
            isGrounded = true;
        }
    }

    public void SteelPush () {
        for (int i = 0; i < steelObj.Length; i++) {
            Vector3 distance = transform.position - steelObj[i].transform.position;
            float dMag = distance.magnitude;
            if (dMag < 5f) {
                rb.AddForce (distance * jumpForce, ForceMode2D.Impulse);
            }
        }
    }

    public void IronPull () {
        for (int i = 0; i < steelObj.Length; i++) {
            Vector3 distance = transform.position - steelObj[i].transform.position;
            float dMag = distance.magnitude;
            if (dMag < 5f) {
                rb.AddForce (-distance * jumpForce * jumpForce, ForceMode2D.Impulse);
            }
        }
    }
}