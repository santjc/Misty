using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour {

    
    private GameObject player;
    private LineRenderer lineRend;
    float distanceMag;
    Vector3 distance;

    private void Start () {
        player = GameObject.Find ("Player");
        lineRend = GetComponent<LineRenderer> ();
    }
    private void Update () {
        distance = transform.position - player.transform.position;
        distanceMag = (transform.position - player.transform.position).magnitude;
        if (distanceMag < 5f) {
            lineRend.SetPosition (0, transform.position);
            lineRend.SetPosition (1, player.transform.position);
        }
        else{
            lineRend.SetPosition(1,Vector3.zero);
            lineRend.SetPosition (0, Vector3.zero);
        }

    }


}