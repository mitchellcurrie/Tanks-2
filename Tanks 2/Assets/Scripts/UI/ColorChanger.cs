using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChanger : MonoBehaviour {
	public int m_PlayerNumber;						// Keeps track of the player number
	
	[HideInInspector] public Color m_TankColor;		// The tank color that the player will change and is then used to set the tank colors in the game manager.
	private float m_TankColorHue;					// The hue of the tank color that the player changes.
	private string m_AxisName;						// The axis used by the player, to determine which keys change the color of which tank.
	private MeshRenderer[] m_Renderers;				// The renderers on each of the tanks used in the customisation screen.

	void Awake() 
	{
		// Get all of the renderers of the tank.
		m_Renderers = GetComponentsInChildren<MeshRenderer> ();
	}
	void Start () 
	{	
		// Set the axis name based on the player number.
		m_AxisName = "Horizontal" + m_PlayerNumber;

		// Change the default hue of player 1 to ensure the default colors of the tanks are different.
		if (m_PlayerNumber == 1)
		{
			m_TankColorHue = 0.6f; // Changed tank color to blue.
		}
	}
	void FixedUpdate () 
	{
		// Get the value of the axis - determines whether the player is pressing left or right
		float value = Input.GetAxis (m_AxisName);

		// If the player is pressing left, decrease the hue.
		if (value < 0)
		{
			m_TankColorHue -= 0.005f;
		}
		// If the player is pressing right, increase the hue.
		else if (value > 0)
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

		// Convert the HSV color to RGB and store in the tank color member variable.
		m_TankColor = Color.HSVToRGB(m_TankColorHue,1,1);

        // Go through all the renderers...
        for (int i = 0; i < m_Renderers.Length; i++)
        {
            // ... set their material color to the color specific to this tank.
            m_Renderers[i].material.color = m_TankColor;
        }
	}
}
