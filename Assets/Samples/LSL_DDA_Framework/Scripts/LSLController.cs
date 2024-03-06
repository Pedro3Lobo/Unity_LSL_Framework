using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LSL;

public class LSLController : MonoBehaviour
{
    
 
    private StreamOutlet outlet;
    private const float DesiredFrequency = 100f;
    private const float FixedDeltaTime = 1f / DesiredFrequency;

    private void Start()
    {
        Time.fixedDeltaTime = FixedDeltaTime;
        StreamInfo streamInfo = new StreamInfo("hello", "honey", 1, 50, LSL.channel_format_t.cf_float32);
        outlet = new StreamOutlet(streamInfo);
        Debug.Log("LSL Stream started.");
    }

    private void Update()
    {
        // Generate and send sample data
        float sampleData = Random.Range(0f, 1f);
        outlet.push_sample(new float[] { sampleData });
    }
}