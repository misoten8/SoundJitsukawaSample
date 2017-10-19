using UnityEngine;
using System.Collections;

public class VolumeSender : MonoBehaviour
{
    public float sensitivity = 100;
    public float loudness = 0;
    AudioSource _audio;
    void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }
    void Update()
    {
        loudness = GetAveragedVolume() * sensitivity;
    }
    float GetAveragedVolume()
    {
        float[] data = new float[256];
        float a = 0;
        _audio.GetOutputData(data, 0);
        foreach (float s in data)
        {
            a += Mathf.Abs(s);
        }
        return a / 256;
    }
}
