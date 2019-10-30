using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JDH_FanBlade_Script : MonoBehaviour
{
    public class FanSettings
    {
        public float fanSpeed = 1.0f;
        public bool enableFan = true;
        public Transform thisFan;


    }

    public FanSettings fanSetting = new FanSettings();

    public void Start()
    {
        fanSetting.thisFan = gameObject.transform;

    }

    public void FixedUpdate()
    {
        if (fanSetting.enableFan == true)
        {
            Rotate();

        }

    }

    public void Rotate()
    {
        fanSetting.thisFan.rotation = new Quaternion(fanSetting.fanSpeed, 0, 0, 0);

    }
}
