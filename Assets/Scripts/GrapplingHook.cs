using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{

    SpringJoint2D joint;
    Vector3 targetPos;
    Touch touch;
    public bool activePull;
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
         if (Input.touchCount > 0 && activePull == true) {
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


    // public void Push() {
    //     RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero, layerMask);
    //     Debug.DrawRay (transform.position, Camera.main.ScreenToWorldPoint (Input.mousePosition), Color.blue);
    //     if (hit.collider != null) {
    //         Rigidbody2D rbO = hit.collider.gameObject.GetComponent<Rigidbody2D> ();
    //         Vector3 diff = transform.position - hit.collider.transform.position;
    //             rbO.AddForce (-diff * pushForce, ForceMode2D.Impulse);
    //     }
    // }
}
