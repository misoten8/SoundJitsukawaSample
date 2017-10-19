using UnityEngine;
using System.Collections;

public class VolumeTarget : MonoBehaviour
{
    VolumeSender target;
    [SerializeField] Renderer rend;

    private void Awake()
    {
        target = GameObject.Find("Main Camera").GetComponent<VolumeSender>();
    }

    private void Update()
    {
        if (target.loudness < 1.0f) return;
        rend.material.SetFloat("_Volume", target.loudness);
    }

    public float volume
    {
        get { return rend.material.GetFloat("Volume"); }
        set { rend.material.GetFloat("Volume"); }
    }
}
