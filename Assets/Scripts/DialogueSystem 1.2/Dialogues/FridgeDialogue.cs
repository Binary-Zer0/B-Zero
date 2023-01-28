using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeDialogue : Dialogue, InterfaceQuestEventHandler
{
     bool isActivated = false;

    DialogueNode d1;
     DialogueNode d2;
    
    void Awake()
    {

        this.d1 = new DialogueNode("Sami", "The Fridge is pomping like new.", null , null,11);
        this.d2 = new DialogueNode("Sami", "Sorry fridge you may be fixed next time.", null , null, 12);
        base.mainNode = new DialogueNode("Sami", "An aged frayer.", this.d1 , this.d2);

        this.mainNode.Populate_Dialogue("This Fridge does not look beautiful.");
    
        this.d1.Populate_Dialogue("MMm.. Lets fix this.");
        this.d1.Populate_Dialogue("....");
        this.d1.Populate_Dialogue("Done.");


        this.d2.Populate_Dialogue("No money, no fix.");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && this.isActivated)
        {
            this.Preprocess_Quest();
            base.Switch_DialogueNode();
            base.Read_Dialogue();
            if(base.get_Dialogueend()) this.Postprocess_Quest();
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            this.isActivated = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
         if(other.tag == "Player")
        {
            this.isActivated = false;
        }
    }


    public void Preprocess_Quest()
    {
        if(GameMaster.Instance.get_Player().Contain_Achievement(10) && !GameMaster.Instance.get_Player().Contain_Goal(0) || GameMaster.Instance.get_Player().Contain_DialogueCoupon(11))
        {
            GameMaster.Instance.get_Player().Add_Achievement(new Achievement (11, "Fridge Prodige."));
            GameMaster.Instance.get_Player().Add_Goal(new Goal (0, "Quest 1 Completed"));
            //GameMaster.Instance.get_Player().Add_DialogueCoupon(new Coupon (11, "Fridge Dialogue Fixed"));
        }
    }

    public void Postprocess_Quest()
    {
          if(GameMaster.Instance.get_Player().Contain_DialogueCoupon(11))
            {
                
            }


    }
}
