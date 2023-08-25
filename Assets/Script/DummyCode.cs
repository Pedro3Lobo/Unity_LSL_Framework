using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyCode : MonoBehaviour
{

    public static float x = 0, y = 0, z = 0;
    private float i = 0;
    private bool up_down_funk;
    public LSLStreamer StreamFloat;
    [SerializeField] public const float DesiredFrequency = 1000f;
    private const float FixedDeltaTime = 1f / DesiredFrequency;

    private void Awake()
    {
        // Set the fixedDeltaTime to the desired frequency
        Time.fixedDeltaTime = FixedDeltaTime;
    }

    private void Start()
    {
        StreamFloat.StartStream();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (up_down_funk) {
            //Debug.Log("Flag 1 : UP");

            if (i < 1)
            {
                i += Time.deltaTime;
                x = i;

            }
            else
            {
                up_down_funk = false;
            }
        }
        else
        {
           // Debug.Log("Flag 2 : DOWN");
            if (i > 0)
            {
                i = i-Time.deltaTime*2;
                x = i;
               // Debug.Log("Flag 3 : i- time delta =" + i + " time delta = " + Time.deltaTime);
            }
            else
            {
                up_down_funk = true;
            }
        }
        
        y = -x;
        z = 2 + x;
        i+= Time.deltaTime;

        float[] sdsd = new float[] {y, x, z, x/3, y, z, z, y, 5, 7};

        StreamFloat.StreamData(sdsd);


    }
}
