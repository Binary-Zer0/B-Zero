using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapteNoderMember : MonoBehaviour
{
    public int ID;
    // Start is called before the first frame update
    void Start()
    {
        GameMaster.Instance.chapters[this.ID].Registre(this.gameObject);
        this.gameObject.SetActive(false);
    
    }

   

}
