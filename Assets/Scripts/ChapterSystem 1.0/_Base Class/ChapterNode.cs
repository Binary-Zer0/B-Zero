using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterNode 
{
    int Id;
    string Name;
    string Description;
    List<GameObject> Story;
    ChapterNode LeftChapter;
    ChapterNode RightChapter;

    public ChapterNode(int Id, string Name, string Description, ChapterNode LeftChapter, ChapterNode RightChapter)
    {
        this.Id = Id;
        this.Name = Name;
        this.Description = Description;
        this.LeftChapter = LeftChapter;
        this.RightChapter = RightChapter;

        this.Story = new List<GameObject>();
        GameMaster.Instance.chapters.Add(this.Id, this);
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

    public int get_ID()
    {
        return this.Id;
    }

    public ChapterNode get_Leftchapter()
    {
        return this.LeftChapter;
    }
    public ChapterNode get_Rightchapter()
    {
        return this.RightChapter;
    }

}
