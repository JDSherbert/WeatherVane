using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JDH_SideScrollCamera_Script : MonoBehaviour
{
    /// <summary>
    /// Script created by Joshua "JDSherbert" Herbert 08/08/2019
    /// Camera script for a 2.5d game.
    /// </summary>


    [System.Serializable]
    public class CameraSettings
    {
        public float cameraMoveSpeed = 5.0f;
        public float cameraHoldPosition = -10.0f; //held z axis
        public float cameraMaxHoldPosition = -30.0f;
        public float cameraHeight = 1.5f;
        public float cameraMaxHeight = 5f;
        public float cameraZoomSpeed = 1.0f; //zoom speed
        public float cameraRotationSpeed = 1.0f; //rotation speed
        public float cameraSensitivity = 10.0f; //multiplier
        public float cameraCurrentPositionX, cameraCurrentPositionY; //co-ordinates (for debug)

        public float PlayerSpeed;
    }

    [System.Serializable]
    public class CameraData
    {
        public Camera MainCamera;
        public GameObject PlayerObject;
        public JDH_TwoHalfDController_Script PlayerScript;

    }

    public CameraSettings cameraSetting = new CameraSettings();
    public CameraData camData = new CameraData();

    public void Start()
    {
        camData.MainCamera = GetComponent<Camera>();
        camData.PlayerObject = GameObject.FindWithTag("Player");
        camData.PlayerScript = GameObject.FindWithTag("Player").GetComponent<JDH_TwoHalfDController_Script>();
    }

    public void FixedUpdate()
    {
        PanToPlayer();
        DynamicZoom();
    }

    public void PanToPlayer()
    {

        //Quick solution - camera's position is assigned based on player position
        //Slerp is for smoother pan transitions
        camData.MainCamera.transform.position = Vector3.Slerp(
            new Vector3(
            camData.MainCamera.transform.position.x,
            camData.MainCamera.transform.position.y,
            camData.MainCamera.transform.position.z),
            new Vector3(
            camData.PlayerObject.transform.position.x,
            camData.PlayerObject.transform.position.y + cameraSetting.cameraHeight,
            camData.MainCamera.transform.position.z),
            cameraSetting.cameraMoveSpeed * Time.deltaTime);
    }

    public void DynamicZoom()
    {
        if (camData.PlayerScript.inputSetting.horizontalInput > 
            camData.PlayerScript.inputSetting.inputDelay
            || camData.PlayerScript.inputSetting.horizontalInput < 
            (camData.PlayerScript.inputSetting.inputDelay * -1))
        {
            camData.MainCamera.transform.position = Vector3.Slerp(
                new Vector3(
                    camData.MainCamera.transform.position.x,
                    camData.MainCamera.transform.position.y,
                    camData.MainCamera.transform.position.z),
                new Vector3(
                    camData.PlayerObject.transform.position.x,
                    cameraSetting.cameraMaxHeight,
                    cameraSetting.cameraMaxHoldPosition),
                    cameraSetting.cameraZoomSpeed * Time.deltaTime);
        }
        else
        {
            camData.MainCamera.transform.position = Vector3.Slerp(
                new Vector3(
                    camData.MainCamera.transform.position.x,
                    camData.MainCamera.transform.position.y,
                    camData.MainCamera.transform.position.z),
                new Vector3(
                    camData.PlayerObject.transform.position.x,
                    cameraSetting.cameraHeight,
                    cameraSetting.cameraHoldPosition),
                    cameraSetting.cameraZoomSpeed * Time.deltaTime);
        }
    }
}
