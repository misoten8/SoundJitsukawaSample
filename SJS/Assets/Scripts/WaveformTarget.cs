using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveformTarget : MonoBehaviour
{
    private void Start()
    {
        Renderer rend = GetComponent<Renderer>();
        rend.material.SetTexture("_MainTex", GameObject.Find("RawImage").GetComponent<WaveformRenderer>().image.texture);
    }
}
