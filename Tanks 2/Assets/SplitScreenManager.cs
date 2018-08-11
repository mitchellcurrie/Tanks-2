using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitScreenManager : MonoBehaviour {

	public CameraControl [] m_CameraControls;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
	}

	private void CheckDistanceBetweenTargets()
        { 
            Debug.Log("Function called");

			if (m_CameraControls.Length < 2)
			{
				Debug.LogError("Less than 2 cameras set in split screen manager");
			}
            /* 
            // Check there are 2 targets / tanks
            else if (m_CameraControls[0].m_Targets.Length == 2)
            {
                // Find the distance between the tanks 
                float Distance = Vector3.Magnitude(m_CameraControls[0].m_Targets[1].position - m_CameraControls[0].m_Targets[0].position);

                Debug.Log(Distance);

				m_CameraControls[0].m_

                if (Distance > m_CameraControls[0].m_SplitScreenDistance)
                {
                    m_CameraControls[1].gameObject.SetActive(true);

                    m_CameraControls[0].m_SplitScreenEnabled = true;
                    m_CameraControl2.m_SplitScreenEnabled = true;
                }
                else
                {
                    m_CameraControl1.m_SplitScreenEnabled = false;
                    m_CameraControl2.m_SplitScreenEnabled = false;
                    
                    m_CameraControl2.gameObject.SetActive(false);                   
                }
*/
                // Enable split screen mode if the distance is greater than the defined distance, otherwise disable split screen mode.
                
            }    
}
