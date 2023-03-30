using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LSL;

public class LSLOutput : MonoBehaviour
{
    private StreamOutlet outlet;
    private float[] currentSample;


    public string StreamName = "Unity.ExampleStream";
    public string StreamType = "Unity.StreamType";
    public string StreamId = "MyStreamID-Unity1234";

    // Start is called before the first frame update
    void Start()
    {
        StreamInfo streamInfo = new StreamInfo(StreamName, StreamType, 3, Time.fixedDeltaTime * 1000, LSL.channel_format_t.cf_float32);
        XMLElement chans = streamInfo.desc().append_child("channels");
        chans.append_child("channel").append_child_value("label", "X");
        chans.append_child("channel").append_child_value("label", "Y");
        chans.append_child("channel").append_child_value("label", "Z");
        outlet = new StreamOutlet(streamInfo);
        currentSample = new float[3];
    }


    // FixedUpdate is a good hook for objects that are governed mostly by physics (gravity, momentum).
    // Update might be better for objects that are governed by code (stimulus, event).
    void FixedUpdate()
    {
        Vector3 pos = gameObject.transform.position;
        currentSample[0] = 1;
        currentSample[1] = 2;
        currentSample[2] = 3;
        outlet.push_sample(currentSample);
    }
}