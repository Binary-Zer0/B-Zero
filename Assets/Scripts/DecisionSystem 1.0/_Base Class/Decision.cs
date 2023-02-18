using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class Decision : MonoBehaviour
{
   [SerializeField]
    private Dialogue _Dialogue;

    protected enum Decisions{Left, Right};

    protected Decisions LeftDecision = Decisions.Left;
    protected Decisions RightDecision = Decisions.Right;

    public bool isDecisionDone = false;
    
   protected void Add_Decision(Button Bt, string Choice, Decisions _Decision, int AchievementID= 0)
    {
        this.isDecisionDone = false;
        Bt.GetComponentInChildren<TMP_Text>().text = Choice;
        Bt.onClick.AddListener(delegate{Activate_Decision(_Decision, AchievementID);});
        GameMaster.Instance.ButtonChoices.SetActive(true);
    }
    private void Activate_Decision(Decisions _Decision, int AchievementID = 0)
    {
        if(_Decision == Decisions.Left)
        {
            this._Dialogue.Set_mainNode(this._Dialogue.Get_mainNode().GetLeftNode());
            // You can add an Achievement here. 
        }
        else if(_Decision == Decisions.Right)
        {
            this._Dialogue.Set_mainNode(this._Dialogue.Get_mainNode().GetRightNode());
            // You can add an Achievement here. 
        }
        this.isDecisionDone = true;
        GameMaster.Instance.ButtonChoices.SetActive(false);
    }
    protected void registre(char Id, Decision _Decision)
    {
        GameMaster.Instance.DecisionRegistre.Add(Id, _Decision);
    }
    public abstract void Execute();
}
