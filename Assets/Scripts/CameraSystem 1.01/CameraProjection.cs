using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraProjection : MonoBehaviour
{
    [SerializeField]
    private Transform MainCamera;

    [SerializeField]
    private Transform Target;

    [SerializeField]
    private GameObject ShadowLayer;

    private SpriteRenderer ShadowLayerRender;

    private Color AlphaColor;
    private Vector3 LerpVector;
    private float Distace;
    private bool isSwitched;
    private bool isRoomActive;

    // Movement speed in units per second.
    public float CameraSpeed = 1.0F;
    public float ShadowLayerSpeed = .01f;

    public GameObject Contain;


    // Start is called before the first frame update
    protected void Awake() 
    {
        this.isSwitched = false;
        this.isRoomActive = false;
    }
    void Start()
    {
        this.ShadowLayer.gameObject.SetActive(true);
        this.ShadowLayer.transform.position = new Vector3( this.transform.position.x , this.transform.position.y+1.5f, -4);
        this.ShadowLayerRender = this.ShadowLayer.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void LateUpdate() 
    {
        if(isRoomActive && !GameMaster.Instance.PauseGame)this.MoveCamera();
        this.HideRoom();
        this.ShowRoom();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") 
        {
            this.isRoomActive = true;
        }
    }

    private  void OnTriggerExit2D(Collider2D other) {
        this.isRoomActive = false;
    }

    private void MoveCamera()
    {

        if( (Mathf.Round(Vector2.Distance(MainCamera.position, Target.position )))  <= -1f ) return;

        this.LerpVector = Vector3.Lerp(this.MainCamera.position, this.Target.position, Time.smoothDeltaTime * this.CameraSpeed);
        this.LerpVector.z = -10 ;
        this.MainCamera.position =  this.LerpVector;
        Debug.Log("MoveCamera Running.");
    }
    private void HideRoom()
    {
        if(this.ShadowLayerRender.color.a >= 1) 
        {
            this.Contain.SetActive(false);
            return;
        }


        if(!isRoomActive)
        {
            this.AlphaColor = this.ShadowLayerRender.color;
            this.AlphaColor.a += 0.5f * Time.deltaTime *  this.ShadowLayerSpeed;
            this.ShadowLayerRender.color = this.AlphaColor;
        }
    }

    private void ShowRoom()
    {
        if(this.ShadowLayerRender.color.a <= 0) return;

        this.AlphaColor= this.ShadowLayerRender.color;
        if(isRoomActive )
        {
            this.Contain.SetActive(true);
            this.AlphaColor.a -= 0.5f * Time.deltaTime * this.ShadowLayerSpeed;
            this.ShadowLayerRender.color = this.AlphaColor;
        }
    }
}
