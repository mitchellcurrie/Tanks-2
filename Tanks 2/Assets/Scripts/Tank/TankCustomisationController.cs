using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankCustomisationController : MonoBehaviour {

	// Use this for initialization
	private string m_AxisName;
	private int m_PlayerNumber;
	
	private void Awake() 
	{
		m_PlayerNumber = GetComponent<ColorChanger>().m_PlayerNumber;
		m_AxisName = "Horizontal" + m_PlayerNumber;
	}
	void Start () 
	{
	
		// Position the tank gameobjects on the screen.
		//Vector3 worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(m_PlayerNumber*800 - m_PlayerNumber*100 ,400,5));
 		//gameObject.transform.position = worldPoint;

	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		// Get the value from the axis
		float value = Input.GetAxis (m_AxisName);

		// If the player is holding down the button on the axis, spin the tank around the y axis.
		if (value != 0)
		{
			gameObject.transform.Rotate(new Vector3(0,1,0), value*3);

		}

		float screenWidthBuffer = 4.7f;
		float screenHeightBuffer = 2.5f;

		if (m_PlayerNumber == 1)
		{
			gameObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / screenWidthBuffer,Screen.height / screenHeightBuffer,5));
		}
		else 
		{
			gameObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - (Screen.width / screenWidthBuffer),Screen.height / screenHeightBuffer,5));
		}
	}
}
