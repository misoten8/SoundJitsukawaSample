using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class WaveformRenderer : MonoBehaviour
{
    [SerializeField]
    AudioSource audioSource;
    public RawImage image;
    [SerializeField]
    int imageWidth;

    Texture2D texture;
    float[] _spectrum = new float[50000];
    public float[] spectrum
    {
        get { return _spectrum; }
    }
    void Awake()
    {
        texture = new Texture2D(imageWidth, 1);
        texture.SetPixels(Enumerable.Range(0, imageWidth).Select(_ => Color.clear).ToArray());
        texture.Apply();
        image.texture = texture;
    }

    void Update()
    {
        audioSource.clip.GetData(_spectrum, audioSource.timeSamples);

        int textureX = 0;
        int skipSamples = 200;
        float maxSample = 0;

        for (int i = 0, l = _spectrum.Length; i < l && textureX < imageWidth; i++)
        {
            maxSample = Mathf.Max(maxSample, _spectrum[i]);

            if (i % skipSamples == 0)
            {
                texture.SetPixel(textureX, 0, new Color(maxSample, 0, 0));
                maxSample = 0;
                textureX++;
            }
        }

        texture.Apply();
        
    }
}
