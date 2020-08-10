using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PullPush : MonoBehaviour {

    // public Button pullButton;
    // public Button pushButton;
    private Rigidbody2D rb;
    private Animator animator;
    public bool pushObject;
    Vector3 mousePosition;
    float pushForce = 2f;
    float pullForce = 2f;

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