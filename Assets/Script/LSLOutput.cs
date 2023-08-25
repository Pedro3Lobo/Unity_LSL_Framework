using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LSL;

public class LSLOutput : MonoBehaviour
{
    private StreamOutlet outlet;
    private float[] currentSample;

    private const float DesiredFrequency = 1000f;
    private const float FixedDeltaTime = 1f / DesiredFrequency;

    public string StreamName = "Unity.ExampleStream";
    public string StreamType = "Unity.StreamType";
    public string StreamId = "MyStreamID-Unity1234";

    // Start is called before the first frame updateS

    private void Awake()
    {
        // Set the fixedDeltaTime to the desired frequency
        Time.fixedDeltaTime = FixedDeltaTime;
    }

    void Start()
    {
        StreamInfo streamInfo = new StreamInfo(StreamName, StreamType, 10, DesiredFrequency, LSL.channel_format_t.cf_float32);
        XMLElement chans = streamInfo.desc().append_child("channels");
        chans.append_child("channel").append_child_value("label", "X1");
        chans.append_child("channel").append_child_value("label", "X2");
        chans.append_child("channel").append_child_value("label", "X3");
        chans.append_child("channel").append_child_value("label", "X4");
        chans.append_child("channel").append_child_value("label", "X5");
        chans.append_child("channel").append_child_value("label", "X6");
        chans.append_child("channel").append_child_value("label", "X7");
        chans.append_child("channel").append_child_value("label", "X8");
        chans.append_child("channel").append_child_value("label", "X9");
        chans.append_child("channel").append_child_value("label", "X10");
        outlet = new StreamOutlet(streamInfo);
        currentSample = new float[10];
    }


    // FixedUpdate is a good hook for objects that are governed mostly by physics (gravity, momentum).
    // Update might be better for objects that are governed by code (stimulus, event).
    void FixedUpdate()
    {
        Vector3 pos = gameObject.transform.position;
        currentSample[0] = DummyCode.x % 2;
        currentSample[1] = DummyCode.x % 3;
        currentSample[2] = DummyCode.x % 4;
        currentSample[3] = DummyCode.x % 5;
        currentSample[4] = DummyCode.x % 7;
        currentSample[5] = DummyCode.x % 8;
        currentSample[6] = DummyCode.x % 4;
        currentSample[7] = DummyCode.x % 3;
        currentSample[8] = DummyCode.x % 7;
        currentSample[9] = DummyCode.x % 6;

        outlet.push_sample(currentSample);
    }
}