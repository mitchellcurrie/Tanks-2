using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColour : MonoBehaviour {

	public GameObject Tank1;
	public GameObject Tank2;
	private float m_hue;

	// Use this for initialization
	
	void Awake() 
	{
		
	}
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
        float value = Input.GetAxis ("Horizontal1");

		if (value < 0)
		{
			m_hue -= 0.005f;
		}
		else if (value > 0)
		{
			m_hue += 0.005f;
		}

		m_hue = Mathf.Clamp(m_hue, 0.0f, 1.0f);

		if (m_hue == 1)
		{
			m_hue = 0;
		}
		else if (m_hue == 0)
		{
			m_hue = 1;
		}

		Debug.Log(m_hue);


		// Get all of the renderers of the tank.
        MeshRenderer[] renderers = Tank1.GetComponentsInChildren<MeshRenderer> ();

        // Go through all the renderers...
        for (int i = 0; i < renderers.Length; i++)
        {
            // ... set their material color to the color specific to this tank.
            renderers[i].material.color = Color.HSVToRGB(m_hue,1,1);
        }

	}
}
