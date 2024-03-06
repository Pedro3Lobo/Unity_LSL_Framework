using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextConsole : MonoBehaviour
{
    public Text Console;
    public List<string> Data;
    // Start is called before the first frame update
    void Start()
    {
        Console = this.GetComponent<Text>();
        WriteInConsole("Starting Program");
    }
    public void FixedUpdate()
    {
        Console.text = string.Join(", ", Data.ToArray());
    }

    // Update is called once per frame

    public void WriteInConsole(string newLine)
    {
        Data.Add(newLine+"\n");
       
        if (Data.Count==20)
        {
            Data.RemoveAt(0);
        }

    }
}
