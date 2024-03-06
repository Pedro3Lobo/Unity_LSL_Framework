using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestManager : MonoBehaviour
{
    public float SyncTest = 0, ConsistencyTest = 0, DelayTest = 0, Increase = 0, Random1 = 0, Random2 = 0, Random3 = 0;
    public float SyncTest2 = 0, ConsistencyTest2 = 0, DelayTest2 = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangeVariableEverySecond());
    }

    private void Update()
    {
       
        if (DelayTest2 != 0)
        {
            Debug.Log("Delay is "+(DelayTest2));
            DelayTest = 0;
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        //if(DelayTest != 0)
        /*{
            DelayTest = 0;
        }*/
        
        Random1 = Random.Range(0.0f, 3.0f);
        Random2 = Random.Range(0.0f, 3.0f);
        Random3 = Random.Range(0.0f, 3.0f);

    }

    public void press()
    {
        SyncTest = (SyncTest == 0) ? 1 : 0;
        DelayTest = Time.time;
        Debug.Log("Variable value changed to: " + SyncTest);
    }

    private System.Collections.IEnumerator ChangeVariableEverySecond()
    {
        while (true)
        {
            ConsistencyTest = (ConsistencyTest == 0) ? 1 : 0;
            //Debug.Log("Variable value changed to: " + ConsistencyTest);
            yield return new WaitForSeconds(1f);
            
            Increase++;
        }
    }
}
