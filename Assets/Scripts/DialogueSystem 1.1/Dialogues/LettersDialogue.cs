using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LettersDialogue : Dialogue
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
                Debug.Log("ENTER 2");

            base.Read_Dialogue();
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            Debug.Log("ENTER");
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
