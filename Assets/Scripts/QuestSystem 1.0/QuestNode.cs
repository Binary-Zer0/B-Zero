using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestNode
{
    string Name;
    string Description;
    Queue<Item> Rewards;
    bool isCompleted;
    bool isActivated;
    QuestNode LeftQuest;
    QuestNode RightQuest;

    int RequiredAchievementID;
    int RequireGoalID;
    int ObjectEventHandlerID;

    public QuestNode(string Name, string Description, QuestNode LeftQuest, QuestNode RightQuest, int ID = 0, int ObjectEventHandlerID = 0)
    {
        this.Name = Name;
        this.Description = Description;
        
        this.LeftQuest = LeftQuest;
        this.RightQuest = RightQuest;
        this.Rewards = new Queue<Item>();
        this.isActivated = false;
        this.isCompleted = false;

        this.RequiredAchievementID = ID;
        this.RequireGoalID = ID;
        this.ObjectEventHandlerID = ObjectEventHandlerID;
    }

    public void Add_Rward(Item _Item)
    {
        this.Rewards.Enqueue(_Item);
    }   

    public void Receive_Rewards(List<Item> Inventory)
    {
        while(this.Rewards.Count !=0)
        {
            Inventory.Add(this.Rewards.Dequeue());
        }
    }

    public string get_Name()
    {
        return this.Name;
    }

    public int get_RequireGoalID()
    {
        return this.RequireGoalID;
    }

     public int get_RequiredAchievementID()
    {
        return this.RequiredAchievementID;
    }

    public int get_ObjeventHandler()
    {
        return this.ObjectEventHandlerID;
    }

    public QuestNode get_LeftQuest()
    {
        return this.LeftQuest;
    }
    public QuestNode get_RightQuest()
    {
        return this.RightQuest;
    }

    public bool get_isActivated()
    {
      
        return this.isActivated;
    }

    public bool get_isCompleted()
    {
        return this.isCompleted;
    }

    public void set_isCompleted(bool Value)
    {
        this.isCompleted = Value;
    }
     public void set_isActivated(bool Value)
    {
        if(Value && GameMaster.Instance.AchievementObj.ContainsKey(this.ObjectEventHandlerID))
        {
            GameMaster.Instance.AchievementObj[this.ObjectEventHandlerID].SetActive(true);
        } 
        this.isActivated = Value;
    }

   

}
