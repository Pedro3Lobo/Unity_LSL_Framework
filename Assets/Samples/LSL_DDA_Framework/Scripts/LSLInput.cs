using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LSL;
using TMPro;

public class LSLInput : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField inputReceive;
    private string StreamType = "PyflowStream";
    public float scaleInput = 0.1f;

    StreamInfo[] streamInfos;
    StreamInlet streamInlet;

    float[] sample;
    string[] channels;
    private int channelCount = 0;
    private XMLElement channelgroup;

    private void Start()
    {
        StreamType = inputReceive.text;
    }



    void Update()
    {

        if ((streamInlet == null) && (LSLOutput.Start_Stop))
        {
            streamInfos = LSL.LSL.resolve_stream("type", StreamType, 1, 0.0);
            if (streamInfos.Length > 0)
            {
                streamInlet = new StreamInlet(streamInfos[0]);
                channelCount = streamInlet.info().channel_count();
                channels = new string[channelCount];
                channelgroup = streamInlet.info().desc().child("channels").child("channel");

                for (int i = 0; i < channelCount; i++)
                {
                    //Debug.Log("6575756->channel name:"+ channelgroup.child_value("label") + " |loop i="+i);
                    channels[i]=channelgroup.child_value("label");
                    channelgroup=channelgroup.next_sibling();
                }
                streamInlet.open_stream();
            }
        }
       
        if (streamInlet != null)
        {
            sample = new float[channelCount];
            double lastTimeStamp = streamInlet.pull_sample(sample, 0.0f);
            if (lastTimeStamp != 0.0)
            {
                Process(sample, lastTimeStamp);
                while ((lastTimeStamp = streamInlet.pull_sample(sample, 0.0f)) != 0)
                {
                    Process(sample, lastTimeStamp);
                }
            }
        }
       
    }
    void Process(float[] newSample, double timeStamp)
    {
        int i = 0;
        foreach (float sample in newSample){
            Debug.Log("Updating var "+sample+" loop i=" + i);
            GetPublicVariables.SetValueofOutput(channels[i],sample);
            i++;
        }
    }
}
