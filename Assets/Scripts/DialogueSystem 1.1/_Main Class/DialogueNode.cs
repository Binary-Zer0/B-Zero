using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueNode 
{
    private Queue<string> Dialogue;
    private string Resume;
    private DialogueNode LeftNode;
    private DialogueNode RightNode;
    private string Speaker;
    int RequireCouponID;



    public DialogueNode(string Speaker, string Resume, DialogueNode LeftNode, DialogueNode RightNode,  int RequireCouponID = 0)
    {
        this.Dialogue = new Queue<string>();
        this.Speaker = Speaker;
        this.Resume = Resume;
        this.LeftNode = LeftNode;
        this.RightNode = RightNode;
        this.RequireCouponID = RequireCouponID;
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


public int get_RequiredCouponID()
{
    return this.RequireCouponID;
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
