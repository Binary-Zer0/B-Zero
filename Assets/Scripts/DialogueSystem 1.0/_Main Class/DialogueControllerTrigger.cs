using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueControllerTrigger : DialogueController
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player")
        {
            base.Switch_Dialogue_Node();
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Player")
        {
            this.gameObject.SetActive(false);
        }
    }
  
}
