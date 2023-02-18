using UnityEngine.UI;

public class Test_Decision : Decision
{
     private void Start() {
        base.registre('1', this);
    }
    
   public override void Execute()
    {
        base.Add_Decision(GameMaster.Instance.ButtonChoices.GetComponentsInChildren<Button>(true)[0], "Happy", base.RightDecision);
        base.Add_Decision(GameMaster.Instance.ButtonChoices.GetComponentsInChildren<Button>(true)[1], "Sad", base.LeftDecision);
    }
}
