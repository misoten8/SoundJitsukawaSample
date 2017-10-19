using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyalumeController : MonoBehaviour
{
    Renderer rend;
    private WaveformRenderer audio_;

    // Filter paramters
    public float colorQuickness = 0.001f;

    Color baseColor;
    public int resolution = 1024;

    void Start ()
    {
        rend = GetComponent<Renderer>();
        baseColor = rend.material.GetColor("_BaseColor");
        audio_ = GameObject.Find("RawImage").GetComponent<WaveformRenderer>();
    }
	
	void Update ()
    {
        float low = 0.0f, mid = 0.0f, high = 0.0f;
        float sampleRate = AudioSettings.outputSampleRate;

        for (int i = 0; i < audio_.spectrum.Length; ++i)
        {
            var freq = sampleRate / resolution * i; // kHz
            if (freq < SpectrumAnalyzer.lowFrequencyThreshold)
            {
                low += audio_.spectrum[i];
            }
            else if (freq < SpectrumAnalyzer.midFrequencyThreshold)
            {
                mid += audio_.spectrum[i];
            }
            else if (freq < SpectrumAnalyzer.highFrequencyThreshold)
            {
                high += audio_.spectrum[i];
            }
        }

        Color target = new Color(
            high * SpectrumAnalyzer.highEnhance,
            mid * SpectrumAnalyzer.midEnhance,
            low * SpectrumAnalyzer.lowEnhance);
       // Debug.Log(target);
        var color = baseColor;
        color.r += (target.r - color.r) * colorQuickness + 0.1f;
        color.g += (target.g - color.g) * colorQuickness + 0.1f;
        color.b += (target.b - color.b) * colorQuickness + 0.1f;
        baseColor = color;
        rend.material.SetColor("_BaseColor", baseColor);
        //Debug.Log(baseColor);
    }
}
