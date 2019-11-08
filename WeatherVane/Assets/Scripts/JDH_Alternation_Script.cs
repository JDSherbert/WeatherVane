using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script created by Joshua "JDSherbert" Herbert 05/11/19
/// Timer that counts down, and then activates/deactivates a light
/// </summary>
/// 
public class JDH_Alternation_Script : MonoBehaviour
{
    [System.Serializable]
    public class LightData
    {
        public Light lightComponent;
        public Renderer renderComponent;
        public GameObject lightObject;
        public AudioSource audioSource;
        public AudioClip audioClip;

        public float timer = 0f;
        public float timeIncrement = 0.1f;
        public float timerMax = 10f;
        public bool SWITCH = false;
    }

    public LightData lightData = new LightData();

    public void Start()
    {
    }

    public void FixedUpdate()
    {
        lightData.timer += lightData.timeIncrement;
        if (lightData.timer >= lightData.timerMax)
        {
            lightData.timer = 0f;
            lightData.SWITCH = !lightData.SWITCH;

            if(lightData.audioSource != null)
            {
                lightData.audioSource.PlayOneShot(lightData.audioClip, 1f);
            }
            if (lightData.lightComponent != null)
            {
                lightData.lightComponent.enabled = lightData.SWITCH;
            }
            if (lightData.lightObject != null)
            {
                lightData.lightObject.SetActive(lightData.SWITCH);
            }
            if (lightData.renderComponent != null)
            {
                lightData.renderComponent.enabled = lightData.SWITCH;
            }
        }
    }
}
