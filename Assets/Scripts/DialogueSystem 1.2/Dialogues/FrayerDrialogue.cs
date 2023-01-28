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
        this.d1 = new DialogueNode("Sami", "The Frayer is working.", null , null,12);
        this.d2 = new DialogueNode("Sami", "She dont have enough money to fix it.", null , null, 11);
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
            base.Switch_DialogueNode();
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
        if(GameMaster.Instance.get_Player().Contain_Achievement(10) && !GameMaster.Instance.get_Player().Contain_Goal(0) || GameMaster.Instance.get_Player().Contain_Achievement(12) )
        {
            //GameMaster.Instance.get_Player().Add_DialogueCoupon(new Coupon (12, "Frayer Dialogue Working."));
            GameMaster.Instance.get_Player().Add_Achievement(new Achievement (12, "Frayer Prodige."));
            GameMaster.Instance.get_Player().Add_Goal(new Goal (0, "Quest 1 Completed"));
        }
    
   
    }

    public void Postprocess_Quest()
    {
            
            if(GameMaster.Instance.get_Player().Contain_DialogueCoupon(12))
            {
                
            }

       
    }
}
