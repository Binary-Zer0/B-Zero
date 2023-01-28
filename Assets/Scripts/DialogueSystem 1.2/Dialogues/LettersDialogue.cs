using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LettersDialogue : Dialogue, InterfaceQuestEventHandler
{
    bool isActivated = false;
    
    void Awake()
    {
        base.mainNode = new DialogueNode("Sami", "why keeping 10 years old letters here?", null , null);
        base.mainNode.Populate_Dialogue("Some Old latters...");
        base.mainNode.Populate_Dialogue("but outdated since 10 years!");
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && this.isActivated)
        {
            base.Read_Dialogue();
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
        throw new System.NotImplementedException();
    }

    public void Postprocess_Quest()
    {
            if(!GameMaster.Instance.get_Player().Contain_Achievement(11) )
        {
             //GameMaster.Instance.get_Player().Add_Achievement(new Achievement (11, "Fridge Fixed"));
            //GameMaster.Instance.get_Player().Add_Coupon(new Coupon (111, "Cat Quest Coupon"));
            GameMaster.Instance.get_Player().Add_Goal(new Goal(11, "Fixed fridge"));

        }
    }
}
