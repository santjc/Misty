using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PullPush : MonoBehaviour {

    // public Button pullButton;
    // public Button pushButton;
    private Rigidbody2D rb;
    private Animator animator;
    public float pullForce = 3f;
    public float pushForce = 2f;
    public bool pushObject;
    Vector3 mousePosition;

    int layerMask = 1 << 9;

    // Start is called before the first frame update
    void Start () {
        rb = GetComponent<Rigidbody2D> ();
        animator = gameObject.GetComponent<Animator> ();
        mousePosition = Input.mousePosition;
    }

    // private void FixedUpdate() {
    //     pullBtn.onClick.AddListener(Pull());
    // }
    private void FixedUpdate () {
        mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);

        if (Input.GetMouseButton (0)) {
            Debug.Log ("mouse1");
            PushPullObject();
        }
    }

    public void Pull () {

        Vector3 diff = mousePosition - transform.position;
        // diff.Normalize();
        animator.SetFloat ("Horizontal", diff.x);
        animator.SetFloat ("Speed", Mathf.Abs (diff.x));
        rb.AddForce (diff * pullForce, ForceMode2D.Impulse);

        // transform.position = Vector3.MoveTowards(transform.position,diff, force * Time.deltaTime);
    }

    public void PushPullObject () {
        RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero, layerMask);
        Debug.DrawRay (transform.position, Camera.main.ScreenToWorldPoint (Input.mousePosition), Color.blue);
        if (hit.collider != null) {

            if (hit.collider.tag == "Object") {
                Debug.Log (hit.collider.tag);
                Rigidbody2D rbO = hit.collider.gameObject.GetComponent<Rigidbody2D> ();
                Vector3 diff = transform.position - hit.collider.transform.position;


                if (pushObject == true) {
                    rbO.AddForce (-diff * pushForce, ForceMode2D.Impulse);
                } else {
                    rbO.AddForce (diff * pullForce, ForceMode2D.Impulse);
                }

            }
        }
    }
}