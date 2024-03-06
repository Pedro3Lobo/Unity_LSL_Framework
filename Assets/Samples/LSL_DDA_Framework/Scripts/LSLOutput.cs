using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LSL;
using UnityEngine.UI;
using TMPro;

public class LSLOutput : MonoBehaviour
{
    private StreamOutlet outlet;
    private float[] currentSample;
    private bool Start_Stop = false;

    public Image Signal;
    public Sprite on;
    public Sprite off;
    public TextConsole Console;

    [SerializeField]
    private TMP_InputField inputName;
    [SerializeField]
    private TMP_InputField inputType;
    [SerializeField]
    private TMP_InputField inputID;

    public string StreamName = "Unity.ExampleStream";
    public string StreamType = "Unity.StreamType";
    public string StreamId = "MyStreamID-Unity1234";

    [SerializeField] public const float DesiredFrequency = 100f;
    private const float FixedDeltaTime = 1f / DesiredFrequency;

    // Start is called before the first frame update
    void Awake()
    {
        Time.fixedDeltaTime = FixedDeltaTime;
    }

    void Start()
    {
        ChangeStringBasedOnInput();
        if (Prefer.autoplay_on)
        {
            StartStream();
            Start_Stop = true;
            //Debug.Log("dsdad");
        }
        //InitStream();
    }

    public void ChangeStringBasedOnInput()
    {
        StreamName = inputName.text;
        StreamType = inputType.text;
        StreamId = inputID.text;
    }

    // FixedUpdate is a good hook for objects that are governed mostly by physics (gravity, momentum).
    // Update might be better for objects that are governed by code (stimulus, event).
    void FixedUpdate()
    {

        if (Start_Stop)
        {
            Vector3 pos = gameObject.transform.position;
            int i = 0, i2 = 0;

            foreach (float Variab in GetPublicVariables.FieldsValues)
            {
                if (GetPublicVariables.Input_On.Count != 0)
                {
                    if (GetPublicVariables.Input_On[i])
                    {
                        currentSample[i2] = Variab;
                        i2++;
                    }
                }
                else
                {

                    Start_Stop = false;
                    break;
                }
                i++;
            }

            if (GetPublicVariables.Input_On.Count != 0)
            {
                outlet.push_sample(currentSample);
            }
        }
        else
        {
            ChangeStringBasedOnInput();
        }
    }

    public void StartStream()
    {
        InitStream();
    }

    public void StopStream()
    {
        Start_Stop = false;
        Console.WriteInConsole("Stopping the stream...");
        Signal.sprite = off;
        outlet.Close();
        Console.WriteInConsole("Stream Stopped...");
    }

    private void InitStream()
    {
        Console.WriteInConsole("Intiliazing the stream...");
        if (GetPublicVariables.Number_Input != 0)
        {
            Start_Stop = true;
            int i = 0;
            Signal.sprite = on;
            StreamInfo streamInfo = new StreamInfo(StreamName, StreamType, GetPublicVariables.Number_Input, DesiredFrequency, LSL.channel_format_t.cf_float32);
            XMLElement chans = streamInfo.desc().append_child("channels");
            foreach (string Variab in GetPublicVariables.FieldsName)
            {
                if (PlayerPrefs.GetInt("In" + i) == 1)
                {
                    chans.append_child("channel").append_child_value("label", Variab);
                }
                i++;
            }
            Console.WriteInConsole("--------------------------------------------------------");
            Console.WriteInConsole("Stream Name: " + StreamName);
            Console.WriteInConsole("Stream Type: " + StreamType);
            Console.WriteInConsole("Channel Number: " + GetPublicVariables.Number_Input);
            Console.WriteInConsole("Data Rate: " + Time.fixedDeltaTime * 1000);
            Console.WriteInConsole("--------------------------------------------------------");
            outlet = new StreamOutlet(streamInfo);
            currentSample = new float[GetPublicVariables.FieldsName.Count];
            Console.WriteInConsole("Stream started...");
        }
        else
        {
            Start_Stop = false;
            Console.WriteInConsole("Intiliazation of the stream failed 0 channels");
        }
    }
}