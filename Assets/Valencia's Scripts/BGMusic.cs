using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMusic : MonoBehaviour
{
    public static BGMusic instance;
    void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        //else if (SceneManager.GetActiveScene().name == "TravernSimulatorTutorial" && SceneManager.GetActiveScene().name == "TavernSimulatorFP Level 1" && SceneManager.GetActiveScene().name == "TavernSimulatorFP Level 2")
        //{
        //    Destroy(gameObject);
        //}
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
