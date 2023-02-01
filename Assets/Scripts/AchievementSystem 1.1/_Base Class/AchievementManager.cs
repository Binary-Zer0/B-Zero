using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    public void Add_Achievement(Achievement A)
    {
        if(GameMaster.Instance.get_Player()._Achievements.ContainsKey(A.Get_Id())) return;
        GameMaster.Instance.get_Player()._Achievements.Add(A.Get_Id(), A);
        Debug.Log("<color=orange> Achievement Unlocked: "+ A.Get_Name()+"</color>");
    }
    public bool Contain_Achievement(int ID) 
    {
        if(GameMaster.Instance.get_Player()._Achievements.ContainsKey(ID)) return true;
        else return false;
    }
    public void Add_ChapterGoal(Goal A)
    {
        if(GameMaster.Instance.get_Player().ChapterGoal.ContainsKey(A.Get_Id())) return;
        GameMaster.Instance.get_Player().ChapterGoal.Add(A.Get_Id(), A);
    }
    public bool Contain_ChapterGoal(int ID) 
    {
        if(GameMaster.Instance.get_Player().ChapterGoal.ContainsKey(ID)) return true;
        else return false;
    }
    
    public void Add_QuestGoal(Goal A)
    {
        if(GameMaster.Instance.get_Player().QuestGoal.ContainsKey(A.Get_Id())) return;
        GameMaster.Instance.get_Player().QuestGoal.Add(A.Get_Id(), A);
    }
    public bool Contain_QuestGoal(int ID) 
    {
        if(GameMaster.Instance.get_Player().QuestGoal.ContainsKey(ID)) return true;
        else return false;
    }
    public void Add_Item(Item item)
    {
        if(!GameMaster.Instance.get_Player().Invetory.ContainsKey(item.get_Category())) GameMaster.Instance.get_Player().Invetory.Add (item.get_Category() , new List<Item>());
        GameMaster.Instance.get_Player().Invetory[item.get_Category()].Add(item);
        GameMaster.Instance.Manager.Update_UI(item.get_Category());
    }
    public bool Contain_Item(string Category, string Name)
    {
        foreach(Item i in GameMaster.Instance.get_Player().Invetory[Category])
        {
            if(i.get_Name() == Name)
            {
                return true;
            }
        }
        return false;
    }
    public void Add_ItemRegistre(int ID, string Name)
    {
        if(GameMaster.Instance.get_Player()._ItemRegistre.ContainsKey(ID))return;
        GameMaster.Instance.get_Player()._ItemRegistre.Add(ID, Name);
    }
    public bool Contain_ItemRegistre(int ID)
    {
        if(GameMaster.Instance.get_Player()._ItemRegistre.ContainsKey(ID)) return true;
        else return false;
    }
}
