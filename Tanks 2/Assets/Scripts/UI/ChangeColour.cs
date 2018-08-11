using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColour : MonoBehaviour {
	public int m_PlayerNumber;
	
	[HideInInspector] public Color m_TankColor;
	private float m_Hue;
	private string m_AxisName;
	private MeshRenderer[] m_Renderers;

	void Awake() 
	{
		// Get all of the renderers of the tank.
		m_Renderers = GetComponentsInChildren<MeshRenderer> ();
	}
	void Start () 
	{
		m_AxisName = "Horizontal" + m_PlayerNumber;
		if (m_PlayerNumber == 1)
		{
			m_Hue = 0.6f;
		}
	}
	void FixedUpdate () 
	{
		float value = Input.GetAxis (m_AxisName);

		if (value < 0)
		{
			m_Hue -= 0.005f;
		}
		else if (value > 0)
		{
			m_Hue += 0.005f;
		}

		m_Hue = Mathf.Clamp(m_Hue, 0.0f, 1.0f);

		if (m_Hue == 1.0f)
		{
			m_Hue = 0;
		}
		else if (m_Hue == 0.0f)
		{
			m_Hue = 1;
		}

		m_TankColor = Color.HSVToRGB(m_Hue,1,1);

        // Go through all the renderers...
        for (int i = 0; i < m_Renderers.Length; i++)
        {
            // ... set their material color to the color specific to this tank.
            m_Renderers[i].material.color = m_TankColor;
        }
	}
}
