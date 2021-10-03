

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;


[System.Serializable]	//This class will appear in the Inspector
public class Boundary


{


	//Public Variables will appear in the Inspector
	public float xMin, xMax; //Screen Boundary dimentions (minimum x axis & maximum x axis)


}

public class Paddle_script : MonoBehaviour 
{

	SerialPort stream = new SerialPort("COM7", 9600);
	private float place;
	public Transform paddle;
	public float divider;




	//Public Variables will appear in the Inspector
	public Boundary boundary;		//Create an object from class
    public float paddleSpeed;		//Speed of the paddle

	//Private Variables
	private Rigidbody2D rb2D;		//Will Connect with the Ball Rigidbody 2D Component

	// Use this for initialization
	void Start () 
    {
		rb2D = GetComponent<Rigidbody2D>();     //Connect rb2D with the Ball Rigidbody 2D Component
		stream.Open();

		stream.ReadTimeout = 50;
	}
	
	// Update is called once per frame
	void Update () 
    {
		//float moveHorizontal = Input.GetAxis ("Horizontal");	//Get if Any Horizontal Keys pressed ((A or D) or (Left or Right) Buttons)
		//Vector2 movement = new Vector2 (moveHorizontal, 0f);	//Put moveHorizontal in a Vector2 Variable (x,y)...moveHorizontal will be the x axis
		//rb2D.velocity = movement * paddleSpeed;		//Add Velocity to the player ship rigidbody by multiplying the movement with paddleSpeed

		//      //Lock the position of the Paddle in the screen by putting a boundaries
		//      rb2D.position = new Vector2 (Mathf.Clamp (rb2D.position.x, boundary.xMin, boundary.xMax),-4f);

		if (stream.IsOpen)
		{
			try
			{
				place = float.Parse(stream.ReadLine());
				place = (place / divider) - 8;
				Debug.Log(place);


				paddle.transform.position = new Vector3(place, transform.position.y, transform.position.z);

			}
			catch (System.Exception)
			{

			}
		}




	}
}
