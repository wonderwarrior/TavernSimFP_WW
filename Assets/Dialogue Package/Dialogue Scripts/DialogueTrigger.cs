using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private GameObject visualCue;
    [SerializeField] private TextAsset inkJson;
    public StarterAssetsInputs starterAssets;
    public bool playerInRange;
    public InputValue inputValue;

    private void Awake()
    {
        playerInRange = false;
        visualCue.SetActive(false);
  


    }
    private void Update()
    {
        if (playerInRange)
        {

            visualCue.SetActive(true);
            if (starterAssets.interact == true && DialogueManager.GetInstance().dialogueisPlaying == false)
            {
                DialogueManager.GetInstance().EnterDialogueMode(inkJson);
                starterAssets.interact = false;

            }

            if (DialogueManager.GetInstance().dialogueisPlaying == true)
            {
                visualCue.SetActive(false);
            }
            else
            {
                visualCue.SetActive(true);
            }
  
        }
        else
        {
            DialogueManager.GetInstance().ExitDialogueMode();
            visualCue.SetActive(false);
        }
    }



    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }
}
