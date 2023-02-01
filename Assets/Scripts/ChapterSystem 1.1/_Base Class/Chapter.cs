using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Chapter : MonoBehaviour
{
    protected ChapterNode mainNode;


    protected abstract void Observer();

    public ChapterNode get_mainNode()
    {
        return this.mainNode;
    }

    public void set_mainNode(ChapterNode Node)
    {
        if(Node is null) return;
        this.mainNode.Disable_Story();
        this.mainNode = Node;
        this.mainNode.Enable_Story();
    }

    public void Go_Next()
    {
        if( this.mainNode.get_Leftchapter() != null &&  GameMaster.Instance._AchievementManager.Contain_Achievement(this.mainNode.get_Leftchapter().get_RequiredAchievementID()) )
        {
            
            this.set_mainNode(this.mainNode.get_Leftchapter());
        }
        else if ( this.mainNode.get_Rightchapter() != null &&  GameMaster.Instance._AchievementManager.Contain_Achievement(this.mainNode.get_Rightchapter().get_RequiredAchievementID()) )
        {
             this.set_mainNode(this.mainNode.get_Rightchapter());

        }
    }
}
