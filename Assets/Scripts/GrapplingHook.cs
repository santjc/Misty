using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{

    SpringJoint2D joint;
    Vector3 targetPos;
    Touch touch;
    RaycastHit2D hit;
    public float maxDist = 5f;
    public LayerMask mask;
    // Start is called before the first frame update
    void Start()
    {
        joint = GetComponent<SpringJoint2D>();
        joint.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
         if (Input.touchCount > 0) {
            touch = Input.GetTouch (0);

            if (touch.phase == TouchPhase.Began) {
                StartJoint();
            }

            if (touch.phase == TouchPhase.Ended) {
                StopJoint ();
            }
         }

    }

    void StartJoint(){
            targetPos = Camera.main.ScreenToWorldPoint (touch.position);
            targetPos.z = 0;

            hit = Physics2D.Raycast(transform.position, targetPos - transform.position,maxDist,mask);
             Debug.DrawRay (transform.position, hit.point, Color.blue);

            if(hit.collider != null){
                joint.enabled = true;
                joint.connectedBody = hit.collider.gameObject.GetComponent<Rigidbody2D>();
                joint.distance = Vector2.Distance(transform.position,hit.point);
            }
    }

    void StopJoint(){
        joint.enabled = false;
    }
}
