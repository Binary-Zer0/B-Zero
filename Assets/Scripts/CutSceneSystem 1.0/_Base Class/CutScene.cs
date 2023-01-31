using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CutScene : MonoBehaviour
{
    public GameObject Dialogue;
    public bool MoveCamera = false;
    string Description;
    Vector2 north = new Vector2(0,1);
    Vector2 south = new Vector2(0,-1);
    Vector2 east = new Vector2(1,0);
    Vector2 west = new Vector2(-1,0);
    Vector3 LerpVector;
    float Distance;
    public bool Watched = false;
    protected bool canMoveNorth = false;
    protected bool canMoveSouth = false;
    protected bool canMoveEast = false;
    protected bool canMoveWest = false;
  
    public  abstract IEnumerator Body();
    public void Disable_Dialogue()
    {
     
        this.GetComponent<Dialogue>().enabled = false;
        GameMaster.Instance.get_DialogueBox().SetActive(false);
        
    }
    public void Enable_Dialogue()
    {
        GameMaster.Instance.get_DialogueBox().SetActive(true);
        this.GetComponent<Dialogue>().enabled = true;
    }
    public void End_cutScene()
    {
        this.Watched = true;
        GameMaster.Instance.PauseGame = false;
        this.MoveCamera = false;

    }
    public void Start_CutScene()
    {
        GameMaster.Instance.PauseGame = true;
    }
    public void Camera_Focus(GameObject Target)
    {
        if(!MoveCamera) return;
        if( (Mathf.Round(Vector2.Distance(Camera.main.transform.position, Target.transform.position )))  <= 0.0f ) return;

        this.LerpVector = Vector3.Lerp(Camera.main.transform.position, Target.transform .position, Time.smoothDeltaTime * 3);
        this.LerpVector.z = -10 ;
        Camera.main.transform.position =  this.LerpVector;
    }
    public void Camera_Projection()
    {
        this.MoveCamera = true;
    }
    public void Move_North(GameObject Obj)
    {
        if(!this.canMoveNorth) return;
        if( Mathf.Round (this.Distance -Obj.transform.localPosition.y) <= 0 ) 
        {
            this.canMoveNorth = false;
            return;
        }
        Obj.GetComponent<Rigidbody2D>().velocity =  north * 3;
    }
    public void Move_South(GameObject Obj)
    {
        if(!this.canMoveSouth) return;
        if( Mathf.Round (this.Distance -Obj.transform.localPosition.y) == 0 ) 
        {
            this.canMoveSouth = false;
            return;
        }
        Obj.GetComponent<Rigidbody2D>().velocity =  south * 3;
    }
    public void Move_East(GameObject Obj)
    {
        if(!this.canMoveEast) return;
        if( Mathf.Round (this.Distance -Obj.transform.localPosition.x) == 0 ) 
        {
            this.canMoveEast = false;
            return;
        }
        Obj.GetComponent<Rigidbody2D>().velocity =  east * 3;
    }
    public void Move_West(GameObject Obj)
    {
        if(!this.canMoveWest) return;
        if( Mathf.Round (this.Distance -Obj.transform.localPosition.y) == 0 ) 
        {
            this.canMoveWest = false;
            return;
        }
        
        Obj.GetComponent<Rigidbody2D>().velocity =  west * 3;
    }
    public void authorize_Move_North(float Distance)
    {
        this.Distance = Distance;
        this.canMoveNorth = true;
     
    }
    public void authorize_Move_South(float Distance)
    {
        this.Distance = Distance;
        this.canMoveSouth = true;
     
    }
    public void authorize_Move_East(float Distance)
    {
        this.Distance = Distance;
        this.canMoveEast = true;
     
    }
    public void authorize_Move_West(float Distance)
    {
        this.Distance = Distance;
        this.canMoveWest = true;
     
    }
    
    public void Look_East(GameObject Obj)
    {  
        Obj.transform.localScale = new Vector3(-1f,1f, 1f);
    }
    public void Look_West(GameObject Obj)
    {
        Obj.transform.localScale = new Vector3(1f, 1f, 1f);
    }

   
}
