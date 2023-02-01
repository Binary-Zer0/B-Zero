using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterNode 
{
    string Name;
    string Description;
    ChapterNode LeftChapter;
    ChapterNode RightChapter;
    int RequiredAchievementID;
    int RequireGoalID;
    int ObjectEventHandlerID;

    List<GameObject> Story;

    public ChapterNode(string Name, string Description,ChapterNode LeftChapter, ChapterNode RightChapter, int RequireGoalID = 0, int RequiredAchievementID = 0)
    {
        this.Name = Name;
        this.Description = Description;
        this.LeftChapter = LeftChapter;
        this.RightChapter = RightChapter;

        this.Story = new List<GameObject>();

        this.RequiredAchievementID = RequiredAchievementID;
        this.RequireGoalID = RequireGoalID;
        
        if(RequireGoalID != 0)GameMaster.Instance.chapters.Add(this.RequireGoalID, this);

    }

    public void Enable_Story()
    {         
        foreach(GameObject obj in Story)
        {
            obj.SetActive(true);
        }
    }
    public void Disable_Story()
    {
        foreach(GameObject obj in Story)
        {
            obj.SetActive(false);
        }
    }

    public void Registre(GameObject Obj)
    {
        this.Story.Add(Obj);
    }

    public ChapterNode get_Leftchapter()
    {
        return this.LeftChapter;
    }
    public ChapterNode get_Rightchapter()
    {
        return this.RightChapter;
    }

     public int get_RequireGoalID()
    {
        return this.RequireGoalID;
    }

     public int get_RequiredAchievementID()
    {
        return this.RequiredAchievementID;
    }


}
