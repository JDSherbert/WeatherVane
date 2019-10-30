using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JDH_SceneManagerPrime_Script : MonoBehaviour
{
    [System.Serializable]
    public class SceneData
    {

    }

    public SceneData sceneData = new SceneData();

    public void Start()
    {
        
    }

    public void FixedUpdate()
    {
        
    }

    public void QuitApplication()
    {
        Debug.Log("Application terminated");
        Application.Quit();
    }
}
