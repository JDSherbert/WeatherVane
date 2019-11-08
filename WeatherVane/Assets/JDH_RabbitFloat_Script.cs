using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JDH_RabbitFloat_Script : MonoBehaviour
{
    [System.SerializableAttribute]
    public class Properties
    {
        public GameObject thisObject;
        public float moveSpeed = 1;
        public float moveDistanceUp = 1;
        public float moveDistanceDown = -1;

        //Set tags for weatherGene blocks

        public bool floatUp = false;

        public float timer;
        public float timerMax = 5f;
    }

    public Properties properties = new Properties();

    public void Start()
    {
        properties.thisObject = gameObject;
    }

    public void FixedUpdate()
    {
        IdleHover();

    }
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
