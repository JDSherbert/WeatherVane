using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JDH_IceCube_Script : MonoBehaviour
{
    /// <summary>
    /// Script created by Joshua "JDSherbert" Herbert 02/10/19
    /// Handles ice cubes.
    /// </summary>
    /// 

    [System.Serializable]
    public class IceCubeProperties
    {
        public AudioSource audioSource;
        public AudioClip audioClip;
        public float meltVolume = 0.7f;
    }

    public IceCubeProperties icecube = new IceCubeProperties();

    public void Start()
    {
        icecube.audioSource = GetComponent<AudioSource>();

    }

    public void OnDestroy()
    {
        icecube.audioSource.PlayOneShot(icecube.audioClip, icecube.meltVolume);
    }
}
