using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TortuousRoute : Route
{
    [SerializeField]
    private float tortuousSpeed = 0.0f;
    [SerializeField]
    private float width = 0.0f;
    private float length = 0.0f;
    private float angle = 0.0f;
    private float tortuousAngle = 0.0f;

    void OnEnable()
    {
        length = Vector2.Distance(new Vector2(target.transform.position.x, target.transform.position.z), new Vector2(transform.position.x, transform.position.z));
        angle = Mathf.Atan2(target.transform.position.x - transform.position.x, target.transform.position.z - transform.position.z);
    }

    void OnDisable()
    {
        angle = 0.0f;
        length = 0.0f;
        tortuousAngle = 0.0f;
    }

    void Update()
    {
        transform.position = (new Vector3(Mathf.Sin(angle), 0.0f, Mathf.Cos(angle)) * length) + (new Vector3(Mathf.Sin(angle + Mathf.PI * 0.5f), 0.0f, Mathf.Cos(angle + Mathf.PI * 0.5f)) * (Mathf.Sin(tortuousAngle) * width));
        length -= speed;
        tortuousAngle += tortuousSpeed;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Base")
        {
            AudioManager.PlaySE("button");
            gameObject.SetActive(false);
        }
    }
}
