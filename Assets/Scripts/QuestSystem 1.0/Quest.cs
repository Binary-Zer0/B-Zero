using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Quest : MonoBehaviour
{
    protected QuestNode mainNode;
    public abstract void Observer();

    public QuestNode get_mainNode()
    {
        return this.mainNode;
    }
    public void set_mainNode(QuestNode Node)
    {
        if (Node is null) return;
        this.mainNode = Node;
    }

    public void State_Quest()
    {
           if(!this.mainNode.get_isActivated() && !this.mainNode.get_isCompleted()) 
        {
            this.mainNode.set_isActivated(true);
            Debug.Log("Start Quest: "+this.mainNode.get_Name());

            
        }
        else if(this.mainNode.get_isCompleted())
        {
            this.mainNode.Receive_Rewards(GameMaster.Instance.get_Player().Invetory);
            Debug.Log("Quest done");
            this.Go_Next();
        }
    }
      
    public void End_Quest()
    {
        
      
    }

       public void Go_Next()
    {
        if( this.mainNode.get_LeftQuest() != null &&  GameMaster.Instance.get_Player().Contain_Achievement(this.mainNode.get_LeftQuest().get_RequiredAchievementID()) )
        {
            
            this.set_mainNode(this.mainNode.get_LeftQuest());
        }
        else if ( this.mainNode.get_RightQuest() != null &&  GameMaster.Instance.get_Player().Contain_Achievement(this.mainNode.get_RightQuest().get_RequiredAchievementID()) )
        {
             this.set_mainNode(this.mainNode.get_RightQuest());

        }
    }
}
