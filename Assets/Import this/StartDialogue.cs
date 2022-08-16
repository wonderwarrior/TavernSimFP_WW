using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;

public class StartDialogue : MonoBehaviour
{
    [SerializeField] private TextAsset inkJson;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if( DialogueManager.GetInstance().dialogueisPlaying == false)
         {
            DialogueManager.GetInstance().EnterDialogueMode(inkJson);


        }
    }
}
