using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Prefer : MonoBehaviour
{
    public Toggle autoplay;
    public List<Toggle> inputs;
    public List<Toggle> outputs;
    public List<string> input_keys;
    public List<string> output_keys;

    [SerializeField]
    private TMP_InputField inputName;
    [SerializeField]
    private TMP_InputField inputType;
    [SerializeField]
    private TMP_InputField inputID;

    private const string ToggleKey = "AutoPlay";
    public static bool autoplay_on = false;

    // Start is called before the first frame update
    void Awake()
    {
        LoadPreferences();
    }

    // Update is called once per frame
    void Update()
    {
        SavePreferences();
        autoplay_on = autoplay.isOn;
    }

    public void SavePreferences()
    {

        PlayerPrefs.SetString("StreamName", inputName.text);
        PlayerPrefs.SetString("StreamType", inputType.text);
        PlayerPrefs.SetString("StreamID", inputID.text);
        PlayerPrefs.SetInt(ToggleKey, autoplay.isOn ? 1 : 0);
        

        int i = 0;

        foreach (string key in input_keys)
        {
            //Debug.Log(key+"->"+ (inputs[i].isOn ? 1 : 0));
            PlayerPrefs.SetInt(key, inputs[i].isOn ? 1 : 0);
            i++;
        }

        i = 0;

        foreach (string key in output_keys)
        {
            PlayerPrefs.SetInt(key, outputs[i].isOn ? 1 : 0);
            i++;
        }

        PlayerPrefs.Save();

    }

    public void LoadPreferences()
    {
        if (PlayerPrefs.HasKey("StreamName"))
        {
            inputName.text = PlayerPrefs.GetString("StreamName");
        }
        if (PlayerPrefs.HasKey("StreamType"))
        {
            inputType.text = PlayerPrefs.GetString("StreamType");
        }
        if (PlayerPrefs.HasKey("StreamID"))
        {
            inputID.text = PlayerPrefs.GetString("StreamID");
        }

        // Load the saved toggle value
        if (PlayerPrefs.HasKey(ToggleKey))
        {
            autoplay.isOn = PlayerPrefs.GetInt(ToggleKey) == 1;
            autoplay_on = PlayerPrefs.GetInt(ToggleKey) == 1;
        }

        int i = 0;

        foreach (string key in input_keys)
        {
            if(PlayerPrefs.HasKey(key))
                inputs[i].isOn = PlayerPrefs.GetInt(key) == 1;
            i++;
        }
        i = 0;
        foreach (string key in output_keys)
        {
            if (PlayerPrefs.HasKey(key))
                outputs[i].isOn = PlayerPrefs.GetInt(key) == 1;
            i++;
        }


        // Use the toggleValue as needed
       // Debug.Log("Toggle value: " + autoplay.isOn);

    }
}
