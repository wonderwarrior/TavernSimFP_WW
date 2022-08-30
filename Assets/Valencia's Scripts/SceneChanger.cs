using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneChanger : MonoBehaviour
{
    public TextMeshProUGUI  scoreNumber;
    public string displayScoreNumber;
    public GameObject inGameUI;
    public GameObject endGameUI;
    public bool endGame;
    private void Start()
    {
        Cursor.visible = true;

        if (scoreNumber != null)
        {
            displayScoreNumber = PlayerPrefs.GetInt("PlayerScore").ToString();
            scoreNumber.text = displayScoreNumber;
        }
 
       
    }
    public void FPScene()
    {
        Cursor.lockState = CursorLockMode.Confined;
        SceneManager.LoadScene("TavernSimulatorFP Level 1");
    }
    public void LoadTutorial()
    {
        Cursor.lockState = CursorLockMode.Confined;
        SceneManager.LoadScene("TravernSimulatorTutorial");
    }
    public void LoadLevel1()
    {
        Cursor.lockState = CursorLockMode.Confined;
        SceneManager.LoadScene("TavernSimulatorFP Level 1");
    }
    
    public void LoadLevel2()
    {
        Cursor.lockState = CursorLockMode.Confined;
        SceneManager.LoadScene("TavernSimulatorFP Level 2");
    }

    public void EndRound1Passed()
    {
        Cursor.lockState = CursorLockMode.Confined;

        endGame = true;
        SceneManager.LoadScene("EndRound1Passed");

    }
    public void EndRound1Failed()
    {
        Cursor.lockState = CursorLockMode.Confined;
        endGame = true;
        SceneManager.LoadScene("EndRound1Failed");

    }

    public void NextCutscene()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Prologue":
                LoadTutorial();
                break;
            case "S2P1":
                SceneManager.LoadScene("S2P2");
                break;
            case "S2P2":
                SceneManager.LoadScene("S2P3");
                break;
            case "S2P3":
                SceneManager.LoadScene("S2P4");
                break;
            case "S2P4":
                SceneManager.LoadScene("S2P5");
                break;
            case "S2P5":
                SceneManager.LoadScene("S2P6");
                break;
            case "S2P6":
                SceneManager.LoadScene("S2P7");
                break;
            case "S2P7":
                SceneManager.LoadScene("S2P8");
                break;
            case "S2P8":
                SceneManager.LoadScene("S2P9");
                break;
            case "S2P9":
                LoadLevel1();
                break;
            case "S3P1":
                SceneManager.LoadScene("S3P2");
                break;
            case "S3P2":
                SceneManager.LoadScene("S3P3");
                break;
            case "S3P3":
                LoadLevel2();
                break;


            //case "Cutscene-Round 1":
            //    LoadLevel2();
            //    break;
            //case "Cutscene - Round 2":
            //    EndChapter1();
            //    break;
            //case "Cutscene - End Ch. 1":
            //    EndBeta();
            //    break;
            default:
                break;
        }
        
    }
    public void Prologue()
    {
        Cursor.lockState = CursorLockMode.Confined;
        SceneManager.LoadScene("Prologue");
    }
    
    public void S2P1()
    {
        Cursor.lockState = CursorLockMode.Confined;
        SceneManager.LoadScene("S2P1");
    }

    public void S3P1()
    {
        Cursor.lockState = CursorLockMode.Confined;
        SceneManager.LoadScene("S3P1");
    }
    public void S4P1()
    {
        Cursor.lockState = CursorLockMode.Confined;
        SceneManager.LoadScene("S4P1");
    }

    public void Menu()
    {
        Cursor.lockState = CursorLockMode.Confined;
        SceneManager.LoadScene("Main Menu");
    }
    public void Credits()
    {
        Cursor.lockState = CursorLockMode.Confined;
        SceneManager.LoadScene("Credits");
    }
    public void Controls()
    {
        Cursor.lockState = CursorLockMode.Confined;
        SceneManager.LoadScene("Controls");
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Game Quit");
    }

}
