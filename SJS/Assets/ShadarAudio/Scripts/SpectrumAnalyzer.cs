using UnityEngine;

public class SpectrumAnalyzer : MonoBehaviour
{
    [SerializeField]
    float Diameter = 1.0f;
    int resolution = 1024;
    public Transform lowMeter, midMeter, highMeter;
    static public float lowFrequencyThreshold = 14700, midFrequencyThreshold = 29400, highFrequencyThreshold = 44100;
    static public float lowEnhance = 0.01f, midEnhance = 0.1f, highEnhance = 1f;

    private AudioSource audio_;

    void Start()
    {
        audio_ = GameObject.Find("Main Camera").GetComponent<AudioSource>();
    }

    void Update()
    { 
        float[] spectrum = audio_.GetSpectrumData(resolution, 0, FFTWindow.BlackmanHarris);

        var deltaFreq = AudioSettings.outputSampleRate / resolution;
        float low = 0f, mid = 0f, high = 0f;

        for (var i = 0; i < resolution; ++i)
        {
            var freq = deltaFreq * i;
            if (freq <= lowFrequencyThreshold) low += spectrum[i];
            else if (freq <= midFrequencyThreshold) mid += spectrum[i];
            else if (freq <= highFrequencyThreshold) high += spectrum[i];
        }

        low *= lowEnhance * Diameter;
        mid *= midEnhance * Diameter;
        high *= highEnhance * Diameter;

        lowMeter.localScale = new Vector3(lowMeter.localScale.x, low, lowMeter.localScale.z);
        midMeter.localScale = new Vector3(midMeter.localScale.x, mid, midMeter.localScale.z);
        highMeter.localScale = new Vector3(highMeter.localScale.x, high, highMeter.localScale.z);

        lowMeter.localPosition = new Vector3(lowMeter.localPosition.x, 0.5f * low - 2.0f, lowMeter.localPosition.z);
        midMeter.localPosition = new Vector3(midMeter.localPosition.x, 0.5f * mid - 2.0f, midMeter.localPosition.z);
        highMeter.localPosition = new Vector3(highMeter.localPosition.x, 0.5f * high - 2.0f, highMeter.localPosition.z);
    }
}