using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SusieDialogue : Dialogue, InterfaceQuestEventHandler, InterfaceChapterEventHandler
{
    [SerializeField]
    private Quest quest;
    bool isTrigged = false;
    public DialogueNode n1;
    DialogueNode n2;
    DialogueNode n3;

    bool isChapterEnd = false;
    void Awake()
    {
        this.n3 = new DialogueNode ("Susie","Iam calling the police.", null, null);
        this.n2 = new DialogueNode ("Jack","Leave the house now.", null, this.n3);
        base.mainNode = new DialogueNode ("Susie","Can you Fix the Fridge please ? ", this.n2, null);

       
        base.mainNode .Populate_Dialogue("Sami:");
        base.mainNode .Populate_Dialogue("Hi");
        base.mainNode .Populate_Dialogue("Thanks for comming");

        base.mainNode .Populate_Dialogue("Susie:");
        base.mainNode .Populate_Dialogue("iam having issues with the fridge.");
        base.mainNode .Populate_Dialogue("Can't wait to see your skills");
  

        this.n2.Populate_Dialogue("Jack:");
        this.n2.Populate_Dialogue("What are you waiting for? ");
        this.n2.Populate_Dialogue("Fix fridge i dont have all the day.");
        this.n2.Populate_Dialogue("I will call your manager.");
        
        this.n3.Populate_Dialogue("Mark:");
        this.n3.Populate_Dialogue("Your freaking me out.");
        this.n3.Populate_Dialogue("Dont come closer.");
     
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && this.isTrigged)
        {
            base.Read_Dialogue();
          
            if(this.get_Dialogueend())this.Activate_Quest();
            if(this.get_Dialogueend())this.Chapter_End();
            
            
        }
        
    }
        private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            this.isTrigged = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
         if(other.tag == "Player")
        {
            this.isTrigged = false;
        }
    }

    public void Activate_Quest()
    {
      
        if(!this.quest.get_mainNode().get_isActivated() && !this.quest.get_mainNode().get_isCompleted()) 
        {
            this.quest.get_mainNode().set_isActivated(true);
        }
        else if (this.quest.get_mainNode().get_isCompleted()) 
        {
            this.quest.get_mainNode().Receive_Rewards(GameMaster.Instance.get_Player().Invetory);
            this.quest.set_mainNode(this.quest.get_mainNode().get_LeftQuest());
            
        }
        
    }

    public void Chapter_End()
    {
        if (GameMaster.Instance.get_Player()._Achievements.ContainsKey(0) && GameMaster.Instance.get_Player()._Achievements.ContainsKey(1))
        {
            GameMaster.Instance.get_Player()._Achievements.Add(2, "Chapter 1 Completed");
            Debug.Log("Chapter 1 Completed");
            //this.quest.enabled = false;
        }
 
    }
}
