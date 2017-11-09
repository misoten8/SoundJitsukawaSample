using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatTiming : MonoBehaviour {

    public int nBeatTiming;

    public Vector3 mPos, mScl;
    private AudioSource se;

    public Vector3 velocity;
    public GameObject beamPrefab;
    public Timing[] sclTimings;

    Vector3 initialPosition, initialVelocity;

    int shotMusicalTime;
    int beamIndex;

    // Use this for initialization
    void Start() {
        se = GetComponent<AudioSource>();

        // 開始の演出    
        if (Music.CurrentSection.Name == "Start")
        {
            transform.localScale = new Vector3(0.0f, Mathf.Clamp01((float)Music.MusicalTime / 16.0f));
        }
    }

    // Update is called once per frame
    void Update() {

        // 更新
        transform.localPosition += mPos;
        transform.localScale = mScl;

        // 移動量の減衰
        mPos.x += (0.0f - mPos.x) * 0.01f;
        mPos.y += (0.0f - mPos.y) * 0.01f;
        mPos.z += (0.0f - mPos.z) * 0.01f;

        mScl.x += (1.0f - mScl.x) * 0.1f;
        mScl.y += (1.0f - mScl.y) * 0.1f;
        mScl.z += (1.0f - mScl.z) * 0.1f;

        //if (Music.IsJustChangedAt(1))
        //{
        //    mScl = Music.Just.Bar % 2 == 0 ?
        //        new Vector3(2.0f, 2.0f, 2.0f) : new Vector3(1.0f, 1.0f, 1.0f);
        //}

        // ビートに合わせてこの処理を行う(一定間隔）
        if (Music.IsJustChangedBeat())
        {
            // 拡大縮小 
            mScl = Music.Just.Beat % nBeatTiming == 0 ? // % 何ビートごとに
                new Vector3(7.0f, 7.0f, 7.0f) : new Vector3(1.0f, 1.0f, 1.0f);
        }
    }

    //public void OnShot()
    //{
    //    if (Music.CurrentSection.Name == "Play3")
    //    {
    //        shotMusicalTime = 2;
    //    }
    //    else
    //    {
    //        shotMusicalTime = 3;
    //    }
    //}
}

    //public Vector3 velocity;
    //public GameObject beamPrefab;
    //public Timing[] beamTimings;

    //Vector3 initialPosition, initialVelocity;

    //int shotMusicalTime;
    //int beamIndex;

    //// Use this for initialization
    //void Start()
    //{
    //    initialPosition = transform.position;
    //    initialVelocity = velocity;
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    if (Music.CurrentSection.Name.StartsWith("Play"))
    //    {
    //        CheckShot();

    //        if (shotMusicalTime > 0)
    //        {
    //            if (Music.IsJustChanged)
    //            {
    //                --shotMusicalTime;
    //            }
    //        }
    //        else
    //        {
    //            UpdatePosition();
    //        }
    //    }
    //}

    //void CheckShot()
    //{
    //    if (beamIndex < beamTimings.Length && Music.IsNearChanged
    //        && (beamTimings[beamIndex].CurrentMusicalTime - 4 == Music.Near.CurrentMusicalTime))
    //    {
    //        Beam beam = (Instantiate(beamPrefab) as GameObject).GetComponent<Beam>();
    //        beam.transform.parent = transform;
    //        beam.transform.localPosition = Vector3.zero;
    //        beam.Initialize(beamTimings[beamIndex]);
    //        ++beamIndex;
    //    }
    //}

    //void UpdatePosition()
    //{
    //    transform.position += velocity * Time.deltaTime;
    //    if (transform.position.x <= -Field.FieldLength || Field.FieldLength <= transform.position.x)
    //    {
    //        //side wall
    //        velocity.x = Mathf.Abs(velocity.x) * -Mathf.Sign(transform.position.x);
    //        Music.QuantizePlay(GetComponent<AudioSource>());
    //    }
    //    if (Field.FieldLength <= transform.position.y)
    //    {
    //        //roof
    //        velocity.y = Mathf.Abs(velocity.y) * -Mathf.Sign(transform.position.y);
    //        Music.QuantizePlay(GetComponent<AudioSource>(), 7);
    //    }
    //    else if (transform.position.y <= -Field.FieldLength)
    //    {
    //        //floor
    //        Music.SeekToSection("GameOver");
    //    }
    //}

    //public void OnShot()
    //{
    //    if (Music.CurrentSection.Name == "Play3")
    //    {
    //        shotMusicalTime = 2;
    //    }
    //    else
    //    {
    //        shotMusicalTime = 3;
    //    }
    //}

    //public void OnRestart()
    //{
    //    shotMusicalTime = 0;
    //    beamIndex = 0;
    //    transform.position = initialPosition;
    //    velocity = initialVelocity;
    //}
