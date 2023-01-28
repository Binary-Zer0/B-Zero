using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _TestTrigger : MonoBehaviour
{
    Achievement A;
    // Start is called before the first frame update
    void Start()
    {
        
        A = new Achievement(0, "Room Discovery");
        GameMaster.Instance.AchievementObj.Add(A.Get_Id(), this.gameObject);
        this.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        GameMaster.Instance.get_Player().Add_Achievement( A);
        Debug.Log("Achievement: "+ A.Get_Name());
        this.gameObject.SetActive(false);

    }

  
}
