using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{

    [SerializeField]
    private GameObject DialogueBox;
    private TMP_Text DialogueSpeakerText;
    private TMP_Text DialogueText;

    protected DialogueNode mainNode;

    private bool goNext;
    private bool skip;
    private bool EndDialogue = false;

    [SerializeField]
    protected float DialogueSpeed;
    void Start()
    {
        this.DialogueSpeakerText = this.DialogueBox.GetComponentsInChildren<TMP_Text>()[0];
        this.DialogueText = this.DialogueBox.GetComponentsInChildren<TMP_Text>()[1];
        this.DialogueBox.gameObject.SetActive(false);
        this.DialogueSpeed = 0.05f;
        this.goNext = true;
        this.skip = false;
    }

    protected void Read_Dialogue()
    {       
            if(this.Empty()) return;

            if(!skip) this.skip = true;

            if(goNext)
            {
                this.DialogueBox.gameObject.SetActive(true);
                StopAllCoroutines();
                this.StartCoroutine(this.Talk_Animation( this.SpeakerController( this.mainNode.Depopulate_Dialogue() ) ) );
            }
        
    }

    private bool Empty()
    {
             if(this.mainNode.GetDialogueCount() == 0 && goNext) 
            {
                this.DialogueBox.gameObject.SetActive(false);
                this.mainNode.Populate_Resume();
                this.EndDialogue = true;
                return true;
            }
            else return false;

    }

    private IEnumerator Talk_Animation( string Word)
    {
        this.goNext = false;
        this.skip = false;
        this.EndDialogue = false;
        this.DialogueText.text = "";
        foreach(char c in Word)
        {
            if(skip)
            {
                this.DialogueText.text = Word;
                break;
            }
            this.DialogueText.text += c;
            yield return new WaitForSeconds(this.DialogueSpeed);
        }
        this.goNext = true;
    }

    public DialogueNode Get_mainNode()
    {
        return this.mainNode;
    }

    public void Set_mainNode(DialogueNode Node)
    {
        this.mainNode = Node;
    }

    private string SpeakerController( string word)
    {
        if(word[word.Length-1] == ':')
        {
            this.DialogueSpeakerText.text = word;
            return this.mainNode.Depopulate_Dialogue();
        }
    
        else return word;

    }
    public bool get_Dialogueend()
    {
        return this.EndDialogue;
    }
  
}
