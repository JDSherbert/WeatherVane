using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JDH_WeatherSun_Script : MonoBehaviour
{

    /// <summary>
    /// Script created by Joshua "JDSherbert" Herbert 02/10/19
    /// Handles the sun weather condition.
    /// </summary>
    /// 
    [System.Serializable]
    public class Weather_Sun
    {
        public Collider collider;
        public AudioSource audioSource;
        public AudioClip audioClip;
        public AudioClip meltAudioClip;
        public float meltTime = 0.1f;

        public AudioClip powerupAudioClip;
        public JDH_SolarPanel_Script spscript;
    }

    public Weather_Sun sun = new Weather_Sun();

    public void Start()
    {
        sun.collider = GetComponent<Collider>();
        sun.audioSource = GetComponent<AudioSource>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "IceCube")
        {
            other.gameObject.GetComponent<AudioSource>().PlayOneShot(sun.meltAudioClip, 1);
            other.gameObject.GetComponent<Renderer>().enabled = false;
            other.gameObject.GetComponent<Light>().enabled = false;
            other.gameObject.GetComponent<ParticleSystem>().Stop();
            Destroy(other, sun.meltTime);
        }

        if (other.gameObject.tag == "SolarPanelCube")
        {
            sun.spscript = gameObject.GetComponent<JDH_SolarPanel_Script>();
            other.gameObject.GetComponent<AudioSource>().PlayOneShot(sun.powerupAudioClip, 1);
            other.gameObject.GetComponent<Light>().enabled = true;
            sun.spscript.solarcube.isON = true;
        }
    }
}
