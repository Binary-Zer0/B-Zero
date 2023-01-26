using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeDialogue : Dialogue, InterfaceQuestEventHandler
{
     bool isActivated = false;
    
    void Awake()
    {

        GameMaster.Instance.AchievementObj.Add(1, this.gameObject);

        base.mainNode = new DialogueNode("Sami", "I wont open that again.", null , null);
        base.mainNode.Populate_Dialogue("Arghh!!!");
        base.mainNode.Populate_Dialogue("the smell is ... Awful.");
        base.mainNode.Populate_Dialogue("it Looks like it was abondonned for far long.");
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && this.isActivated)
        {
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
       
    }

    public void Postprocess_Quest()
    {
         if(GameMaster.Instance.get_Player().Unlocked_Achievement(0))
        {
             GameMaster.Instance.get_Player().Add_Achievement(new Achievement (1, "Fridge Coupon"));
            GameMaster.Instance.get_Player().Add_Achievement(new Achievement (4, "Fridge Achiev"));
            GameMaster.Instance.get_Player().Add_Achievement(new Achievement (6, "Fridge Dialog"));

        }
    }
}
