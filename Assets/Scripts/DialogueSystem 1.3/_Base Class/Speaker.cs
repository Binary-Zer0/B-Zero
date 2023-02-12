using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speaker {

    private string Name;
    private string Speech;

    public Speaker(string Name, string Speech)
    {
        this.Name = Name;
        this.Speech = Speech;
    }

    public string Get_Name()
    {
        return this.Name;
    }
    public string Get_Speech()
    {
        return this.Speech;
    }

    public Speaker Set_Speech(string speech)
    {
        this.Speech = speech;
        return this;
    }
}
