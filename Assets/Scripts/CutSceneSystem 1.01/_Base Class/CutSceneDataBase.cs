using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneDataBase : MonoBehaviour
{
    Dictionary<int, CutScene> CutSceneRegistre;
    void Awake()
    {
        this.CutSceneRegistre = new Dictionary<int, CutScene>();
    }

}
