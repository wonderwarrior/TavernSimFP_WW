using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using StarterAssets;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue UI")]

    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI displayNameText;

    private Story currentStory;

    public bool dialogueisPlaying;

    public StarterAssetsInputs starterAssets;

    [Header("Choices UI")]

    [SerializeField] private GameObject[] choices;

    private TextMeshProUGUI[] choicesText;


    private static DialogueManager instance;

    private const string SPEAKER_TAG = "speaker";

    public SceneChanger changer;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Found more than one Dialogue Manager in the scene");
        }
        instance = this;
    }
    public static DialogueManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        dialogueisPlaying = false;
        dialoguePanel.SetActive(false);

        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        if (choices != null)
        {
            foreach (GameObject choice in choices)
            {
                choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
                index++;
            }
        }
      
    }

    private void Update()
    {
        if (!dialogueisPlaying)
        {
            starterAssets.submit = false;
            return;
        }
        if (dialogueisPlaying)
        {
            starterAssets.move = new Vector2(0f, 0f);
            starterAssets.look = new Vector2(0f, 0f);
            starterAssets.jump = false;

        }
        if (starterAssets.submit == true)
        {

            ContinueStory();
            starterAssets.submit = false;
        }
    }

    public void EnterDialogueMode(TextAsset inkJson)
    {
        currentStory = new Story(inkJson.text);
        dialogueisPlaying = true;
        dialoguePanel.SetActive(true);
        ContinueStory();
    }

    public void ExitDialogueMode()
    {
        changer.NextCutscene();
        dialogueisPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";


    }

    public void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();
      

            HandleTags(currentStory.currentTags);


        }
        else
        {
            ExitDialogueMode();
        }
    }

    private void HandleTags(List<string> currentTags)
    {
        foreach(string tag in currentTags)
        {
            string[] splitting = tag.Split(':');
            if(splitting.Length != 2)
            {
                Debug.LogError("Tage could not be appropriately parsed:" + tag);
            }
            string tagKey = splitting[0].Trim();
            string tagValue = splitting[1].Trim();

            switch (tagKey)
            {
                case SPEAKER_TAG:
                    displayNameText.text = tagValue;
                    break;
                default:
                    Debug.LogWarning("Tage came in but is not currently being handled" + tag);
                    break;
            }
        }
    }

    public void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        if(currentChoices.Count > choices.Length)
        {
            Debug.Log("More choices were given than the UI can support. Number of choices give:" + currentChoices.Count);
        }

        int index = 0;

        foreach(Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }

        for(int i = index; i< choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false); 

        }
        StartCoroutine(selectFirstChoice());
    }
    IEnumerator selectFirstChoice()
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }
    public void MakeChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);
    }


}
