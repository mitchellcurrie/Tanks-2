using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColour : MonoBehaviour {
	public int m_PlayerNumber;
	private float m_hue;
	private string m_AxisName;
	private MeshRenderer[] m_Renderers;
	private Color m_TankColor;

	// Use this for initialization
	
	void Awake() 
	{
		// Get all of the renderers of the tank.
		m_Renderers = GetComponentsInChildren<MeshRenderer> ();
	}
	void Start () 
	{
		m_AxisName = "Horizontal" + m_PlayerNumber;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		float value = Input.GetAxis (m_AxisName);

		if (value < 0)
		{
			m_hue -= 0.005f;
		}
		else if (value > 0)
		{
			m_hue += 0.005f;
		}

		m_hue = Mathf.Clamp(m_hue, 0.0f, 1.0f);

		if (m_hue == 1.0f)
		{
			m_hue = 0;
		}
		else if (m_hue == 0.0f)
		{
			m_hue = 1;
		}

		m_TankColor = Color.HSVToRGB(m_hue,1,1);

        // Go through all the renderers...
        for (int i = 0; i < m_Renderers.Length; i++)
        {
            // ... set their material color to the color specific to this tank.
            m_Renderers[i].material.color = m_TankColor;
        }
	}
}
