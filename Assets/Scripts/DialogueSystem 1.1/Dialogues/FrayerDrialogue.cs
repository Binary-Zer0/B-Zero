using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrayerDrialogue : Dialogue, InterfaceQuestEventHandler
{
     bool isTrigged = false;

     DialogueNode d1;
     DialogueNode d2;
    
    void Awake()
    {
        this.d1 = new DialogueNode("Sami", "The Frayer is working.", null , null, 0);
        this.d2 = new DialogueNode("Sami", "She dont have enougth money to fix it.", null , null, 2);
        base.mainNode = new DialogueNode("Sami", "Broken frayer.", this.d1 , this.d2);

        this.mainNode.Populate_Dialogue("The Frayer displays 1000c");
    

        this.d1.Populate_Dialogue("Was out of fuel engine.");

        this.d2.Populate_Dialogue("Can do nothing about this.");

        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Space) && this.isTrigged)
        {
            this.Preprocess_Quest();
            base.Read_Dialogue();
            if(this.get_Dialogueend())this.Postprocess_Quest();
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

    public void Preprocess_Quest()
    {
        base.Switch_DialogueNode();
    }

    public void Postprocess_Quest()
    {
        if(GameMaster.Instance.get_Player().Unlocked_Achievement(0))
        {
             GameMaster.Instance.get_Player().Add_Achievement(new Achievement (1, "Frayer Achiev"));
             GameMaster.Instance.get_Player().Add_Achievement(new Achievement (2, "Frayer coupon"));
             GameMaster.Instance.get_Player().Add_Achievement(new Achievement (7, "Frayer diag"));
        }
    }
}
