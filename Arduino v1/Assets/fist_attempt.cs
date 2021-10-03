using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;


public class fist_attempt : MonoBehaviour
{
    SerialPort stream = new SerialPort("COM7", 9600);

    new string word;

    // Start is called before the first frame update
    void Start()
    {


        stream.Open();

        stream.ReadTimeout = 50;
    }

    // Update is called once per frame
    void Update()
    {
        if (stream.IsOpen)
        {
            try
            {
                Debug.Log(stream.ReadLine());
            }
            catch ( System.Exception)
            {

            }

        }

    }
    public static void v()
    {
        SerialPort stream = new SerialPort("COM7", 9600);

    }      
        
    

}