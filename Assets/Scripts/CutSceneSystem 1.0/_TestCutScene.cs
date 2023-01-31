using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _TestCutScene : CutScene
{
    public GameObject Actor;
    void Start()
    {
        GameMaster.Instance.CutSceneRegistre.Add(">10", this);
    }

    private void Update() {
        base.Move_North(Actor);
        base.Move_East(Actor);
    }

    public override IEnumerator Body()
    {
        if(!Watched) 
       {
        base.Start_CutScene(); 
        base.Disable_Dialogue();
        base.Look_East(Actor);

        // Moving Action.
        base.authorize_Move_East(3.5f);
        yield return new WaitUntil(()=> !base.canMoveEast); 
        yield return new WaitForSeconds(0.5f);

        base.Look_West(Actor);
        yield return new WaitForSeconds(1f);
        base.Look_East(Actor);
        yield return new WaitForSeconds(0.5f);

        base.authorize_Move_North(1);
        yield return new WaitUntil(()=> !base.canMoveNorth); 

        yield return new WaitForSeconds(2);
        base.Look_West(Actor);
        yield return new WaitForSeconds(0.5f);
        base.Enable_Dialogue();
        base.End_cutScene();}
    }

}
