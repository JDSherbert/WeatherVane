using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JDH_DNA_Script : MonoBehaviour
{
    /// <summary>
    /// Script created by Joshua "JDSherbert" Herbert 18/09/19
    /// Adds a Weather Gene DNA power based on the tag.
    /// Make sure to define clips, and attach an audiosource, and set a tag on the gameobject.
    /// </summary>
    /// 
    [System.Serializable]
    public class Properties
    {
        public GameObject thisObject;
        public GameObject playerObject;
        public JDH_WeatherAbilities_Script weatherScript;
        public AudioSource audioSource;
        public AudioClip audioClip;
        public float moveSpeed = 1;
        public float moveDistanceUp = 1;
        public float moveDistanceDown = -1;

        //Set tags for weatherGene blocks

        public Collider collider;
        public bool floatUp = false;

        public float timer;
        public float timerMax = 5f;
    }

    public Properties properties = new Properties();

    public void Start()
    {
        properties.thisObject = gameObject;
        properties.playerObject = GameObject.FindWithTag("Player");
        properties.weatherScript = GameObject.FindWithTag("Player").GetComponent<JDH_WeatherAbilities_Script>();
        properties.collider = GetComponent<Collider>();
        properties.audioSource = GetComponent<AudioSource>();



    }

    public void OnCollisionEnter(Collision collision)
    {
        bool collided = true;

        if(collided == true)
        {
            properties.audioSource.PlayOneShot(properties.audioClip, 1f);
            gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
            Destroy(properties.collider);
            Destroy(gameObject, 2f);
        }
        
    }

    public void FixedUpdate()
    {
        IdleHover();
    }

    //movement
    public void IdleHover()
    {

        properties.timer += 0.1f;

        if (properties.timer >= properties.timerMax)
        {
            properties.floatUp = !properties.floatUp;
            properties.timer = 0;
        }

        if (properties.floatUp == true)
        {
            properties.thisObject.transform.position = Vector3.Slerp(
            new Vector3(
            properties.thisObject.transform.position.x,
            properties.thisObject.transform.position.y,
            properties.thisObject.transform.position.z),
            new Vector3(
            properties.thisObject.transform.position.x,
            properties.thisObject.transform.position.y + properties.moveDistanceUp,
            properties.thisObject.transform.position.z),
            properties.moveSpeed * Time.deltaTime);
        }

        if (properties.floatUp == false)
        {
            properties.thisObject.transform.position = Vector3.Slerp(
            new Vector3(
            properties.thisObject.transform.position.x,
            properties.thisObject.transform.position.y,
            properties.thisObject.transform.position.z),
            new Vector3(
            properties.thisObject.transform.position.x,
            properties.thisObject.transform.position.y + properties.moveDistanceDown,
            properties.thisObject.transform.position.z),
            properties.moveSpeed * Time.deltaTime);
        }

    }
}
