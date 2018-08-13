using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankCustomisationController : MonoBehaviour {

	private string m_RotateAxisName;				// Keeps track of the axis name for rotating the tank
	private string m_ColorAxisName;					// The axis used by the player, to determine which keys change the color of which tank.
	public int m_PlayerNumber;						// Keeps track of the player number.
	[HideInInspector] public Color m_PlayerColor;	// the player's color chosen in the customisation screen and used for the tank and text colors in the game.
	private float m_TankColorHue;					// The hue of the tank color that the player changes.
	private MeshRenderer[] m_Renderers;				// The renderers on each of the tanks used in the customisation screen.
	
	private void Awake() 
	{
		// Get all of the renderers of the tank.
		m_Renderers = GetComponentsInChildren<MeshRenderer> ();
	}
	void Start () 
	{
		// Set the axis names based on the player number.
		m_RotateAxisName = "Horizontal" + m_PlayerNumber;
		m_ColorAxisName = "Vertical" + m_PlayerNumber;

		// Change the default hue of player 1 to ensure the default colors of the tanks are different.
		if (m_PlayerNumber == 1)
		{
			m_TankColorHue = 0.6f; // Changed player 1 tank color to blue.
		}
	}

	// Adjusts the rotation and colors of the tanks in the customisation screen based on the player's input.
	void FixedUpdate () 
	{
		/////   TANK ROTATION    //////

		// Get the value from the axis
		float rotateAxisValue = Input.GetAxis (m_RotateAxisName);

		// If the player is holding down either axis button, spin the tank around the y axis - direction is based on which axis button is pressed.
		if (rotateAxisValue != 0)
		{
			gameObject.transform.Rotate(new Vector3(0,1,0), rotateAxisValue*3);  // *3 added for faster rotation
		}

		// Set screen buffers for positioning the tanks on the screen
		float screenWidthBuffer = 4.25f;
		float screenHeightBuffer = 2.5f;

		// Set the world position of the tanks based on screen positions that take into account the buffer above and the screen dimensions.
		// Player 1 on the left side of the screen, and player 2 on the right - each the same distance from the edge of the screen.
		if (m_PlayerNumber == 1)
		{
			gameObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / screenWidthBuffer,Screen.height / screenHeightBuffer,5));
		}
		else // Player 2
		{
			gameObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - (Screen.width / screenWidthBuffer),Screen.height / screenHeightBuffer,5));
		}


		/////   TANK SCALE    //////

		// Scale the tank models based on the screen size.
		// Default scalar is 1.
		float scalar = 1.0f;

		// If large screen...
		if (Screen.width >= 1000)
		{
			// Change the scalar based on screen width
			float w = Screen.width;
			scalar = 900.0f / w;
		}

		// Scale the tank based on the scalar
		gameObject.transform.localScale = new Vector3(scalar,scalar,scalar);
		

		/////   TANK COLOR    //////

		// Get the value of the color axis - determines whether the player is pressing up or down.
		float colorAxisValue = Input.GetAxis (m_ColorAxisName);

		// If the player is pressing down (negative on the axis), decrease the hue.
		if (colorAxisValue < 0)
		{
			m_TankColorHue -= 0.005f;
		}
		// If the player is pressing up (positive on the axis), increase the hue.
		else if (colorAxisValue > 0)
		{
			m_TankColorHue += 0.005f;
		}

		// Clamp the hue at a value between 0 and 1.
		m_TankColorHue = Mathf.Clamp(m_TankColorHue, 0.0f, 1.0f);

		// If the hue reaches 0 or 1, reset back to 1 and 0 to allow looping through the colors by holding down a key.
		if (m_TankColorHue == 1.0f)
		{
			m_TankColorHue = 0;
		}
		else if (m_TankColorHue == 0.0f)
		{
			m_TankColorHue = 1;
		}

		// Convert the HSV color to RGB and store in the player color member variable.
		m_PlayerColor = Color.HSVToRGB(m_TankColorHue,1,1);

        // Go through all the tank renderers...
        for (int i = 0; i < m_Renderers.Length; i++)
        {
            // ... set their material color to the color specific to this tank.
            m_Renderers[i].material.color = m_PlayerColor;
        }
	}
}
