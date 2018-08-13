using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtonController : MonoBehaviour {

	private AudioSource m_AudioSource;					// Reference to the audio source component attached to the object.

	void Start () 
	{
		// Get the audio source component.
		m_AudioSource = GetComponent<AudioSource>();	
	}
	

	public void PlaySound()
	{
		// If the audio source component has been stored in the member variable...
		if (m_AudioSource)
		{
			// Play the clip
			m_AudioSource.Play();
		}
		else
		{
			Debug.LogError("Audio source component not found by start button controller.");
		}
	}
}
