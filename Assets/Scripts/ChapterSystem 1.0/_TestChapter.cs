using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _TestChapter : Chapter
{
    ChapterNode chapter2;

    bool isChapter1 = false;

  

    void Awake()
    {
        this.chapter2 = new ChapterNode(2,"Chapter 2", "Ghost Hunter",null,null );
        base.mainNode = new ChapterNode(1,"Chapter 1", "Fix Fridge", this.chapter2, null);

        //GameMaster.Instance.chapters.Add(1, base.mainNode);
        //GameMaster.Instance.chapters.Add(2, this.chapter2);
        

        
        
    }
    private void Update() {
        base.mainNode.Enable_Story();
        this.Observer();
    }

      protected override void Observer()
    {
        if(GameMaster.Instance.get_Player().Unlocked_Goal(1))
        {
            base.set_mainNode(base.mainNode.get_Leftchapter());
        }
       
    }

 
}
