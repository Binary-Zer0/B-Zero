using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _TestObserver : MonoBehaviour
{
    Achievement B;
    void Start()
    {
        B = new Achievement (3, "Chapter 1 Completed");
        GameMaster.Instance.AchievementObj.Add(B.Get_Id(), this.gameObject);
    }
    private void Update() {

        if(GameMaster.Instance.get_Player()._Achievements.ContainsKey(2))
        {
            GameMaster.Instance.get_Player().Add_Achievement(B);
            Debug.Log("Achievement: "+ B.Get_Name());
            this.gameObject.SetActive(false);
        }
    }

  
}
