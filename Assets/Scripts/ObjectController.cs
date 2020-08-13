using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour {

    Vector3 mousePosition;
    public float power = 1f;
    public float maxDrag = 2f;
    private Rigidbody2D rb;

    private bool isBeingHeld = false;
    // Start is called before the first frame update
    Vector3 dragStartPos;
    Touch touch;

    private void Start () {
        rb = GetComponent<Rigidbody2D> ();
    }
    private void Update () {
        if (Input.touchCount > 0) {
            touch = Input.GetTouch (0);

            if (touch.phase == TouchPhase.Began) {
                DragStart ();
            }

            if (touch.phase == TouchPhase.Moved) {
                Dragging ();
            }

            if (touch.phase == TouchPhase.Ended) {
                DragRelease ();
            }
        }

        void DragStart () {
            Vector3 dragStartPos = Camera.main.ScreenToWorldPoint (touch.position);
            dragStartPos.z = 0f;
        }

        void Dragging () {
            Vector3 draggingPos = Camera.main.ScreenToWorldPoint (touch.position);
            draggingPos.z = 0f;
        }

        void DragRelease () {
            Vector3 dragReleasePos = Camera.main.ScreenToWorldPoint (touch.position);
            dragReleasePos.z = 0f;
            transform.position = dragReleasePos;
        }
    }
}