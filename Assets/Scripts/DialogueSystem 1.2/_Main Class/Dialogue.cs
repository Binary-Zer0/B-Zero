using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
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
        this.DialogueSpeakerText = GameMaster.Instance.get_DialogueBox().GetComponentsInChildren<TMP_Text>()[0];
        this.DialogueText = GameMaster.Instance.get_DialogueBox().GetComponentsInChildren<TMP_Text>()[1];
        GameMaster.Instance.get_DialogueBox().gameObject.SetActive(false);
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
                GameMaster.Instance.get_DialogueBox().gameObject.SetActive(true);
                StopAllCoroutines();
                this.StartCoroutine(this.Talk_Animation( this.mainNode.Depopulate_Dialogue() ) ) ;
            }
    }

    public void Switch_DialogueNode()
    {
         if( this.mainNode.GetLeftNode() != null &&  GameMaster.Instance.get_Player().Contain_Achievement(this.mainNode.GetLeftNode().get_RequiredAchievementID()) )
        {  
            this.Set_mainNode(this.mainNode.GetLeftNode());
        }
        else if ( this.mainNode.GetRightNode() != null &&  GameMaster.Instance.get_Player().Contain_Achievement(this.mainNode.GetRightNode().get_RequiredAchievementID()) )
        {
            this.Set_mainNode(this.mainNode.GetRightNode());
        }
    }

    private bool Empty()
    {
             if(this.mainNode.GetDialogueCount() == 0 && goNext) 
            {
                GameMaster.Instance.get_DialogueBox().SetActive(false);
                this.mainNode.Populate_Resume();
                this.EndDialogue = true;
                return true;
            }
            else return false;

    }

    private IEnumerator Talk_Animation( string Word)
    {
        this.DialogueText.text = "";
        this.goNext = false;
        this.EndDialogue = false;

        yield return this.CutScene_Controller(Word);

        this.skip = false;
        Word = this.Dialogue_Filter(Word);
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
        if(Node is null) return;
        this.mainNode = Node;
    }
    
    IEnumerator CutScene_Controller( string word)
    {   if(word[0] == '>')
    {
        yield return GameMaster.Instance.CutSceneRegistre[word].Body();
    }
    }

    private string Dialogue_Filter( string word)
    {   
         if(word[0] == '>')
         {
            word = this.mainNode.Depopulate_Dialogue();
         }
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
