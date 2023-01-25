using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrayerDrialogue : Dialogue
{
     bool isTrigged = false;
    
    void Awake()
    {
        base.mainNode = new DialogueNode("Sami", "i better stay far from this.", null , null);
        base.mainNode.Populate_Dialogue("This frayer diplays 1000c.");
        base.mainNode.Populate_Dialogue("must be an error.");

        
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
