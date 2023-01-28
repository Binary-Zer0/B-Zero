using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueNode 
{
    private Queue<string> Dialogue;
    public string Resume;
    private DialogueNode LeftNode;
    private DialogueNode RightNode;
    private string Speaker;
    int RequiredAchievementID;



    public DialogueNode(string Speaker, string Resume, DialogueNode LeftNode, DialogueNode RightNode,  int RequiredAchievementID = 0)
    {
        this.Dialogue = new Queue<string>();
        this.Speaker = Speaker;
        this.Resume = Resume;
        this.LeftNode = LeftNode;
        this.RightNode = RightNode;
        this.RequiredAchievementID = RequiredAchievementID;
    }

    public void Populate_Resume()
    {
        this.Dialogue.Enqueue(this.Get_Speaker()+':');
        this.Dialogue.Enqueue(this.Resume);
    }

    public void Populate_Dialogue(string Dialogue)
    {
        this.Dialogue.Enqueue(Dialogue);
    }

    public string Depopulate_Dialogue()
    {
        if(this.Dialogue.Count == 0)  this.Populate_Resume();
        return this.Dialogue.Dequeue();
    }


public int get_RequiredAchievementID()
{
    return this.RequiredAchievementID;
}

    public DialogueNode GetLeftNode()
    {
        return this.LeftNode;
    }

     public DialogueNode GetRightNode()
    {
        return this.RightNode;
    }

    public int GetDialogueCount()
    {
        return this.Dialogue.Count;
    }
    public string Get_Speaker()
    {
        return this.Speaker;
    }
 
   
}
