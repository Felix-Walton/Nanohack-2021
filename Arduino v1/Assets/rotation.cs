using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;


public class rotation : MonoBehaviour
{
    SerialPort stream = new SerialPort("COM6", 9600);

    private rotation theRotation;
    public float fromAudinoX;
    public float fromAudinoY;
    public bool orinetationX = true;
    public string x;
    public string y;

    public Transform maze; 

    // Start is called before the first frame update
    void Start()
    {


        stream.Open();

        stream.ReadTimeout = 50;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(transform.rotation);
        if (stream.IsOpen)
        {
            try
            {
                if (orinetationX)
                {
                    fromAudinoX = float.Parse(stream.ReadLine());
                    orinetationX = false;
                }
                else
                {
                                    
                    fromAudinoY = float.Parse(stream.ReadLine());
                    orinetationX = true;
                }

                maze.transform.eulerAngles = new Vector3(
                    fromAudinoY * -10,
                    maze.transform.eulerAngles.y,
                    fromAudinoX * 10);
            }
            catch (System.Exception)
            {

                
            }
        }
    }
}