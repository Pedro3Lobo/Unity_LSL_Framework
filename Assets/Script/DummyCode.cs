using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyCode : MonoBehaviour
{

    public static float x = 0, y = 0, z = 0;
    private float i = 0;
    private bool up_down_funk;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (up_down_funk) {
            //Debug.Log("Flag 1 : UP");

            if (i < 10)
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
    }
}
