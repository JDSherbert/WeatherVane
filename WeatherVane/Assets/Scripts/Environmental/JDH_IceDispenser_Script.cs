using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JDH_IceDispenser_Script : MonoBehaviour
{
    /// <summary>
    /// Script created by Joshua "JDSherbert" Herbert 18/10/19
    /// Handles ice dispenser segment.
    /// </summary>
    /// 
    [System.Serializable]
    public class IceDispenserProperties
    {
        public AudioSource audioSource;
        public AudioClip audioClipPowerOn;
        public AudioClip audioClipDispense;
        public GameObject lightRed;
        public GameObject lightGreen;
        public GameObject IceCube;
        public float cubelifetime = 20;
        public float dispenseRateTimer = 0;
        public float dispenseRateTimerMax = 10;
        public JDH_SolarPanel_Script onSource;

        public ParticleSystem mainSystem;
        public ParticleSystem pipe1;
        public ParticleSystem pipe2;
        public ParticleSystem pipe3;

        public bool isON = false;
        public bool run = false;
    }

    public IceDispenserProperties icedisp = new IceDispenserProperties();

    public void Start()
    {
        icedisp.audioSource = GetComponent<AudioSource>();
        icedisp.mainSystem = GetComponent<ParticleSystem>();
        icedisp.mainSystem.Stop();
        icedisp.lightGreen.SetActive(false);


    }

    public void FixedUpdate()
    {
        if (icedisp.isON == false)
        {
            icedisp.isON = icedisp.onSource.solarcube.isON;
            

        }
        else
        {
            if (icedisp.run == false)
            {
                icedisp.audioSource.PlayOneShot(icedisp.audioClipPowerOn, 1f);
                icedisp.lightGreen.SetActive(true);
                icedisp.lightRed.SetActive(false);
                icedisp.mainSystem.Play();
                icedisp.pipe1.Play();
                icedisp.pipe2.Play();
                icedisp.pipe3.Play();
                icedisp.run = true;

            }

            DispenseIce();
        }
    }

    public void DispenseIce()
    {

        icedisp.dispenseRateTimer += .1f;
        
        if(icedisp.dispenseRateTimer >= icedisp.dispenseRateTimerMax)
        {
            icedisp.audioSource.PlayOneShot(icedisp.audioClipDispense, 1f);
            Instantiate(icedisp.IceCube, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), new Quaternion(0,0,0,0));
            icedisp.dispenseRateTimer = 0;


        }


    }


}
