using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LSL;

public class LSLController : MonoBehaviour
{
    public string Stream_Name ;
    public int SampleSize ;
    public List<string> ChannelsNames = new List<string>();
    public float Modifier;
    public int Channels;
    
    private StreamOutlet outlet;
    private float sample = 00f; // data to be sent
    private float[] data;
    private int i = 0;

    void Start()
    {
        data = new float[ChannelsNames.Count];
        // create a new stream info and outlet
        StreamInfo streamInfo = new StreamInfo(Stream_Name, "MyStreamType", ChannelsNames.Count, SampleSize, channel_format_t.cf_float32, "myStreamID");
        XMLElement chans = streamInfo.desc().append_child("channels");

        foreach (string Channel in ChannelsNames) {
            chans.append_child_value("label", Channel);
        }
        //Debug.Log("chans:"+chans);
        outlet = new StreamOutlet(streamInfo);
       
    }

    void FixedUpdate()
    {
        i++;

        Add_Value();

        outlet.push_sample(data);
        //Debug.Log("X ->"+ DummyCode.x);
    }

    private void Add_Value()
    {
        for(int p = 0; p != ChannelsNames.Count; p++)
        {
            switch (p)
            {
                case 0:
                    data[0] = DummyCode.x * Modifier;
                    break;

                case 1:
                    data[1] = DummyCode.y * Modifier;
                    break;

                case 2:
                    data[2] = DummyCode.z * Modifier;
                    break;

                case 3:
                    data[3] = -DummyCode.x * Modifier;
                    break;

                default:
                    data[p] = DummyCode.x * Modifier* 029.38372089f;
                    break;

            }
        }
    }


}

