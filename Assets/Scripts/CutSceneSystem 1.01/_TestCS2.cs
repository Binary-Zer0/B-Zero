using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _TestCS2 : CutScene
{
    public GameObject[] Target;
    private GameObject currTarget;
     void Start()
    {
        GameMaster.Instance.CutSceneRegistre.Add(">20", this);
    }

    private void Update() {
        base.Camera_Focus(currTarget);
    }

public override IEnumerator Body()
{
    if(!Watched) 
    { 
        base.Start_CutScene();
        base.Disable_Dialogue();
        base.Camera_Projection();
        this.currTarget = Target[0];
        yield return new WaitForSeconds(2);
        this.currTarget = Target[1];
        yield return new WaitForSeconds(2);
        base.Enable_Dialogue();
        base.End_cutScene();     
    }
       
    }

 
}
