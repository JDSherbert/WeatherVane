using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JDH_MaterialFader_Script : MonoBehaviour
{
    /// <summary>
    /// Script created by Joshua "JDSherbert" Herbert 01/10/19
    /// Fades a material based on Camera triggering a collider.
    /// Make sure to use a "Fade" shader, collider, and stick this script on it.
    /// </summary>
    /// 

    [System.Serializable]
    public class FaderProperties
    {
        public GameObject thisObject;
        public Renderer renderer;
        public Collider collider;

        public float alphaFade = 0.1f;

        //Cached Material for hotswap
        public Material _cachedMaterial;

    }

    public FaderProperties faderProperties = new FaderProperties();

    public void Start()
    {
        GetStuff();
        

    }

    public void FixedUpdate()
    {
    }


    public void GetStuff()
    {
        faderProperties.thisObject = gameObject;
        faderProperties.renderer = GetComponent<Renderer>();
        faderProperties.collider = GetComponent<Collider>();
        faderProperties._cachedMaterial = faderProperties.renderer.material;

    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            faderProperties.renderer.material.color =
                new Color32
                (255, 255, 255, 50);
                
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            faderProperties.renderer.material.color =
                new Color32
                (255, 255, 255, 255);

        }
    }

}
