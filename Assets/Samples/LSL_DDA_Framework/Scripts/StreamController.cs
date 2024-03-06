using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LSL;

public class StreamController : MonoBehaviour
{
    private StreamOutlet outlet;
    private float[] currentSample;

    public string StreamName = "Unity.ExampleStream";
    public string StreamType = "Unity.StreamType";
    public string StreamId = "MyStreamID-Unity1234";
    // Start is called before the first frame update
    void Start()
    {
        initStream();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = gameObject.transform.position;
        //currentSample[0] = DummyCode.x;
        //currentSample[1] = DummyCode.y;
        //currentSample[2] = DummyCode.z;
        outlet.push_sample(currentSample);
    }

    public void initStream()
    {
        StreamInfo streamInfo = new StreamInfo(StreamName, StreamType, 3, Time.fixedDeltaTime * 1000, LSL.channel_format_t.cf_float32);
        XMLElement chans = streamInfo.desc().append_child("channels");
        chans.append_child("channel").append_child_value("label", "X");
        chans.append_child("channel").append_child_value("label", "Y");
        chans.append_child("channel").append_child_value("label", "Z");
        outlet = new StreamOutlet(streamInfo);
        currentSample = new float[3];
    }

    public void Start_Stream()
    {

    }

    public void Pause_Stream()
    {

    }

    public void End_Stream()
    {

    }


}
