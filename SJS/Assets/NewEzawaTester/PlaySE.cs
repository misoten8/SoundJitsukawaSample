using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySE : MonoBehaviour {

    //音声ファイル格納用変数
    private AudioSource se;

   // [SerializeField]
    public AudioClip SE_01;
    public AudioClip SE_02;

    // Use this for initialization
    void Start () {
        se = GetComponent<AudioSource>();
    }

    void Update()
    {

        //指定のキーが押されたら音声ファイルの再生をする
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            se.PlayOneShot(SE_01);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            se.PlayOneShot(SE_02);
        }
    }
}
