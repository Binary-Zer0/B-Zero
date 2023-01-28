using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coupon 
{
    string Name;
    int Id;

    bool Lock;
    public Coupon(int Id, string Name){
        this.Id = Id;
        this.Name = Name;
        this.Lock = false;
    }

    public int Get_Id()
    {
        return this.Id;
    }

    public string Get_Name()
    {
        return this.Name;
    }

    public bool get_Lock()
    {
        return this.Lock;
    }

    public void set_Lock(bool Value)
    {
        this.Lock = Value;
    }
}
