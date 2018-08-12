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
		// Set the axis names based on the player number.
		m_RotateAxisName = "Horizontal" + m_PlayerNumber;
		m_ColorAxisName = "Vertical" + m_PlayerNumber;

		// Get all of the renderers of the tank.
		m_Renderers = GetComponentsInChildren<MeshRenderer> ();
	}
	void Start () 
	{
		// Change the default hue of player 1 to ensure the default colors of the tanks are different.
		if (m_PlayerNumber == 1)
		{
			m_TankColorHue = 0.6f; // Changed tank color to blue.
		}
	}

	void FixedUpdate () 
	{
		/////   TANK ROTATION    //////

		// Get the value from the axis
		float rotateAxisValue = Input.GetAxis (m_RotateAxisName);

		// If the player is holding down either axis button, spin the tank around the y axis.
		if (rotateAxisValue != 0)
		{
			gameObject.transform.Rotate(new Vector3(0,1,0), rotateAxisValue*3);  // *3 added for faster rotation
		}

		// Set screen buffers for positioning the tanks on the screen
		float screenWidthBuffer = 4.25f;
		float screenHeightBuffer = 2.5f;

		// Set the world position of the tanks based on screen positions that take into account the buffer above and the screen dimensions.
		if (m_PlayerNumber == 1)
		{
			gameObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / screenWidthBuffer,Screen.height / screenHeightBuffer,5));
		}
		else // Player 2
		{
			gameObject.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width - (Screen.width / screenWidthBuffer),Screen.height / screenHeightBuffer,5));
		}

		/////   TANK COLOR    //////

		// Get the value of the color axis - determines whether the player is pressing up or down.
		float colorAxisValue = Input.GetAxis (m_ColorAxisName);

		// If the player is pressing down, decrease the hue.
		if (colorAxisValue < 0)
		{
			m_TankColorHue -= 0.005f;
		}
		// If the player is pressing up, increase the hue.
		else if (colorAxisValue > 0)
		{
			m_TankColorHue += 0.005f;
		}

		// Clamp the hue at a value between 0 and 1.
		m_TankColorHue = Mathf.Clamp(m_TankColorHue, 0.0f, 1.0f);

		// If the hue reaches 0 or 1, reset back to 0 or 1 to allow looping through the colors by holding down a key.
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

        // Go through all the renderers...
        for (int i = 0; i < m_Renderers.Length; i++)
        {
            // ... set their material color to the color specific to this tank.
            m_Renderers[i].material.color = m_PlayerColor;
        }
	}
}
