using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    private GameObject player;
    private GameObject _object;
    public Button activeHook;
    private Image btnImage;
    // Start is called before the first frame update
    void Start () {
        player = GameObject.Find ("Player");
        _object = GameObject.Find ("Object");
    }

    // Update is called once per frame
    public void restartPosition () {
        player.transform.position = Vector3.zero;
        _object.transform.position = Vector3.zero;
    }


}