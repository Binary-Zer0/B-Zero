using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class Dialogue : MonoBehaviour
{
    private TMP_Text DialogueSpeakerText;
    private TMP_Text DialogueText;
    protected DialogueNode mainNode;
    private bool goNext;
    private bool skip;
    private bool EndDialogue = false;
    protected bool startDialogue = false;
    [SerializeField]
    protected float DialogueSpeed;
    
    void Start()
    {
        this.DialogueSpeakerText = GameMaster.Instance.get_DialogueBox().GetComponentsInChildren<TMP_Text>()[0]; //Dependance.
        this.DialogueText = GameMaster.Instance.get_DialogueBox().GetComponentsInChildren<TMP_Text>()[1]; //Dependance.
        GameMaster.Instance.get_DialogueBox().gameObject.SetActive(false); //Dependance.
        this.DialogueSpeed = 0.05f;
        this.goNext = true;
        this.skip = false;
    }

    public abstract void Execute();

    protected void Add_Self_Dialogue()
    {
        GameMaster.Instance.get_Player().DialogueStack.Push(this);
    }
    protected void Remove_Self_Dialogue()
    {
        GameMaster.Instance.get_Player().DialogueStack.Pop();
    }



    public  void Read_Dialogue()
    {  
            if(this.Empty()) return;

            this.startDialogue = true;
            GameMaster.Instance.get_Player().onDiscussion = true; //Dependance.

            if(!skip) this.skip = true;

            if(goNext)
            {
                StopAllCoroutines();
                this.StartCoroutine(this.Talk_Animation( this.mainNode.Depopulate_Dialogue() ) ) ;
            }
    }

    public void Switch_DialogueNode() //Dependance.
    {
         if( this.mainNode.GetLeftNode() != null &&  GameMaster.Instance._AchievementManager.Contain_Achievement(this.mainNode.GetLeftNode().get_RequiredAchievementID()) )
        {  
            this.Set_mainNode(this.mainNode.GetLeftNode());
        }
        else if ( this.mainNode.GetRightNode() != null &&  GameMaster.Instance._AchievementManager.Contain_Achievement(this.mainNode.GetRightNode().get_RequiredAchievementID()) )
        {
            this.Set_mainNode(this.mainNode.GetRightNode());
        }
    }

    private bool Empty() //Dependance.
    {
             if(this.mainNode.GetDialogueCount() == 0 && goNext) 
            {
                GameMaster.Instance.get_DialogueBox().SetActive(false);
                GameMaster.Instance.get_Player().onDiscussion = false;
                this.mainNode.Populate_Resume();
                this.startDialogue = false;
                this.EndDialogue = true;
                return true;
            }
            else return false;

    }

    private IEnumerator Talk_Animation( string Word)
    {
        this.goNext = false;
        this.EndDialogue = false;

        yield return this.Choice_Controller(Word);
        yield return this.CutScene_Controller(Word);

        this.skip = false;
        this.DialogueText.text = "";

        Word = this.Dialogue_Filter(Word);
        GameMaster.Instance.get_DialogueBox().gameObject.SetActive(true); //Dependance.

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
    
    IEnumerator CutScene_Controller( string word) //Dependance.
    {   if(word[0] == '>')
    {
        yield return GameMaster.Instance.CutSceneRegistre[word].Body();
    }
    }
    IEnumerator Choice_Controller( string word) //Dependance.
    {   if(word[0] == '*')
    {   GameMaster.Instance.ChoicesRegistre[word[word.Length-1]].Execute();
        yield return new WaitUntil( () => GameMaster.Instance.ChoicesRegistre[word[word.Length-1]].isChoiceDone );
        this.Switch_DialogueNode();
    }
    }

    private string Dialogue_Filter( string word)
    {   
        if(word[0] == '>')
         {
            word = this.mainNode.Depopulate_Dialogue();
         }
        if(word[0] == '*')
         {
            word = this.mainNode.Depopulate_Dialogue();
         }
        if(word[word.Length-1] == ':')
        {
            this.DialogueSpeakerText.text = word;
            word = this.mainNode.Depopulate_Dialogue();
        }
        
         return word;
    }
    
    public bool get_Dialogueend()
    {
        return this.EndDialogue;
    }
  
}
