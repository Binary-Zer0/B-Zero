using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _TemplateDialogue : Dialogue
{
     bool isTrigged = false;
    
    void Awake()
    {
        base.mainNode = new DialogueNode("Speaker", "Resume", null , null);
        base.mainNode.Populate_Dialogue("");
        base.mainNode.Populate_Dialogue("");
        base.mainNode.Populate_Dialogue("");
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && this.isTrigged)
        {
            base.Read_Dialogue();
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
}
