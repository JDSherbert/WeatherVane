using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JDH_SolarPanel_Script : MonoBehaviour
{
    /// <summary>
    /// Script created by Joshua "JDSherbert" Herbert 02/10/19
    /// Handles solarpanel cubes.
    /// </summary>
    /// 

    [System.Serializable]
    public class SolarPanelProperties
    {
        public AudioSource audioSource;
        public AudioClip audioClip;
        public Collider trigger;
        public Light light;
        public float powerupVolume = 0.7f;
        public bool isON = false;
    }

    public SolarPanelProperties solarcube = new SolarPanelProperties();

    public void Start()
    {
        solarcube.audioSource = GetComponent<AudioSource>();
        solarcube.light.enabled = false;
    }

    public void FixedUpdate()
    {
        if(solarcube.isON == true)
        {
            solarcube.audioSource.PlayOneShot(solarcube.audioClip, 1f);
            solarcube.light.enabled = true;
        }
        else
        {
            
        }
    }
    public void OnTriggerEnter(Collider triggerObj)
    {
        if(triggerObj.name == "Sun")
        {
            solarcube.isON = true;
        }
    }
}
