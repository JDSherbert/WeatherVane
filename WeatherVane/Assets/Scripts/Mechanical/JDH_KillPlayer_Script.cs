using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JDH_KillPlayer_Script : MonoBehaviour
{
    /// <summary>
    /// Script created by Joshua "JDSherbert" Herbert 18/09/19
    /// Generic kill script for any object
    /// Make sure to define clips and attach an audiosource.
    /// </summary>

    [System.Serializable]
    public class KillHandler
    {
        public Collider collider;
        public AudioSource audioSource;
        public AudioClip killSound;
        public ParticleSystem particleFX;
        public float particleFXTimer = 0;
        public float particleFXTimerMax = 10;
        public bool particleOn;

        public float killTimer = 0.05f;
    }

    public KillHandler killHandler = new KillHandler();

    public void Start()
    {
        killHandler.collider = GetComponent<Collider>();
        killHandler.audioSource = GetComponent<AudioSource>();
        killHandler.particleFX = GetComponent<ParticleSystem>();
        killHandler.particleFX.Stop();

    }

    public void FixedUpdate()
    {
        while(killHandler.particleOn == true)
        {
            if (killHandler.particleFXTimer <= killHandler.particleFXTimerMax)
            {
                killHandler.particleFX.Play();
                killHandler.particleFXTimer += 1;

            }
            else if (killHandler.particleFXTimer > killHandler.particleFXTimerMax)
            {
                killHandler.particleFX.Stop();
                killHandler.particleFXTimer = 0;
                killHandler.particleOn = false;
            }
        }
       
    }

    public void OnTriggerEnter(Collider collision)
    {
        killHandler.audioSource.PlayOneShot(killHandler.killSound);
        killHandler.particleOn = true;

        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject, killHandler.killTimer);
        }
    }
}
