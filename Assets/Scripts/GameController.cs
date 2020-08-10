using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    private GameObject player;
    private GameObject _object;
    public PullPush pullPush;
    public Button pullButton;
    public Button pushButton;
    private Image pullBtnImage;
    private Image pushBtnImage;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        _object = GameObject.Find("Object");
    }

    // Update is called once per frame
    public void restartPosition(){
        player.transform.position = Vector3.zero;
        _object.transform.position = Vector3.zero;
    }

    public void pushTrue(){
        pullPush.GetComponent<PullPush>();
        pullPush.pushObject = true;
        pullBtnImage = pullButton.GetComponent<Image>();
        pullBtnImage.color = new Color(pullBtnImage.color.r, pullBtnImage.color.g, pullBtnImage.color.b, 0.3f);

        pushBtnImage = pushButton.GetComponent<Image>();
        pushBtnImage.color = new Color(pushBtnImage.color.r, pushBtnImage.color.g, pushBtnImage.color.b, 0.8f);
    }

    public void pushFalse(){
        pullPush.GetComponent<PullPush>();
        pullPush.pushObject = false;

        pullBtnImage = pullButton.GetComponent<Image>();
        pullBtnImage.color = new Color(pullBtnImage.color.r, pullBtnImage.color.g, pullBtnImage.color.b, 0.8f);

        pushBtnImage = pushButton.GetComponent<Image>();
        pushBtnImage.color = new Color(pushBtnImage.color.r, pushBtnImage.color.g, pushBtnImage.color.b, 0.3f);
    }
}
