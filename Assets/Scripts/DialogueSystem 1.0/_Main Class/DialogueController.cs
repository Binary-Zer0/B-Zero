using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    [SerializeField]
    private Dialogue _Dialogue;

    private enum Direction {Left, Right}

    [SerializeField]
    private Direction _Direction;


    protected void Switch_Dialogue_Node()
    {
        if(this._Direction == Direction.Left)
        {
            this._Dialogue.Set_mainNode(this._Dialogue.Get_mainNode().GetLeftNode());

        }
        else if(this._Direction == Direction.Right)
        {
            this._Dialogue.Set_mainNode(this._Dialogue.Get_mainNode().GetRightNode());

        }
    }

}
