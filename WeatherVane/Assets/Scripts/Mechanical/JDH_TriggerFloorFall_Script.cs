using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JDH_TriggerFloorFall_Script : MonoBehaviour
{
    /// <summary>
    /// Script created by Joshua "JDSherbert" Herbert 08/08/2019
    /// Used for starting a trigger event from collisions that will enable rigidbodies on objects, making them fall.
    /// Can be used with up to 5 objects at once.
    /// </summary>

    [System.Serializable]
    public class TriggerData
    {
        public BoxCollider collider;
        public GameObject thisObject;

        public Rigidbody object1;
        public Rigidbody object2;
        public Rigidbody object3;
        public Rigidbody object4;

        public AudioSource audioSource;
        public AudioClip audioClip;

    }

    public TriggerData triggerData = new TriggerData();

    public void Start()
    {
        triggerData.collider = GetComponent<BoxCollider>();
        triggerData.audioSource = GetComponent<AudioSource>();
        triggerData.thisObject = GameObject.Find("FallingFloor");

        triggerData.object1.constraints = RigidbodyConstraints.FreezeAll;
        triggerData.object2.constraints = RigidbodyConstraints.FreezeAll;
        triggerData.object3.constraints = RigidbodyConstraints.FreezeAll;
        triggerData.object4.constraints = RigidbodyConstraints.FreezeAll;

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FallingFloor();

        }
    }

    public void FallingFloor()
    {
            triggerData.audioSource.PlayOneShot(triggerData.audioClip, 0.7f);
            triggerData.object1.constraints = RigidbodyConstraints.None;
            triggerData.object2.constraints = RigidbodyConstraints.None;
            triggerData.object3.constraints = RigidbodyConstraints.None;
            triggerData.object4.constraints = RigidbodyConstraints.None;


        Destroy(triggerData.thisObject);


    }

}
