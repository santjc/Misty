using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {

    private Transform cam;
    private Vector3 lastCameraPos;
    public float parallaxEffect = .5f;
    private float textureUnitSizeX;

    private void Start () {
        cam = Camera.main.transform;
        lastCameraPos = cam.position;
        Sprite sprite = GetComponent<SpriteRenderer> ().sprite;
        Texture2D texture = sprite.texture;
        textureUnitSizeX = texture.width / sprite.pixelsPerUnit;
    }

    private void LateUpdate () {
        Vector3 deltaMovement = cam.position - lastCameraPos;
        transform.position += deltaMovement * parallaxEffect;
        lastCameraPos = cam.position;
        

        if ( Mathf.Abs(cam.position.x - transform.position.x) >= textureUnitSizeX) {
            float offsetPositionX = (cam.position.x - transform.position.x) % textureUnitSizeX;
            transform.position = new Vector3 (cam.position.x + offsetPositionX, transform.position.y, 0);
        }
    }
}