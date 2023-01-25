using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeDialogue : Dialogue
{
     bool isActivated = false;
    
    void Awake()
    {
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
}
