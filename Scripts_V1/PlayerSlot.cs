using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerSlot : MonoBehaviour
{
    public GameObject Card = null;

    public GameObject GameMan = null;
    public BattleSystem thisBattleSystem = null;
    public bool CanSelectCards = false;



    public bool Selected;
    //[SerializeField] GameObject Player = null;

    public Vector3 StartPosition = Vector3.zero;
    public Vector3 ZoomPosition = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        StartPosition = this.transform.position;
        ZoomPosition = this.transform.position;
        ZoomPosition.y = .7f;

        GameMan = GameObject.FindGameObjectWithTag("Manager");
        thisBattleSystem = GameMan.GetComponent<BattleSystem>();

    }

    // Update is called once per frame
    void Update()
    {
        if (thisBattleSystem.PlayerSelect)
        {
            CanSelectCards = true;
        }
        else
        {
            CanSelectCards = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        GameObject OtherObject = other.gameObject;

        Cards aCard;
        aCard = OtherObject.GetComponent<Cards>();

        if (aCard != null)
        {
            Card = OtherObject;
            print("Colliding");
        }

        if (aCard == null)
        {
            Card = null;
            print("Null");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        GameObject OtherObject = collision.gameObject;

        Cards aCard;
        aCard = OtherObject.GetComponent<Cards>();

        if(aCard != null)
        {
            Card = OtherObject;
            print("Colliding");
        }

        if(aCard == null)
        {
            Card = null;
            print("Null");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        GameObject OtherObject = collision.gameObject;

        Cards aCard;
        aCard = OtherObject.GetComponent<Cards>();

        if (aCard == null)
        {
            Card = null;
            print("Null");
        }
    }



    private void OnMouseOver()
    {
        ZoomIN();
    }

    private void OnMouseExit()
    {
        ZoomOUT();
    }

    
    public void ZoomIN()
    {
        if (CanSelectCards)
        {
            this.transform.position = ZoomPosition;
        }

    }

    public void ZoomOUT()
    {

        this.transform.position = StartPosition;


    }
}
