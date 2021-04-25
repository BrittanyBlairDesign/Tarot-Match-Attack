using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlot : MonoBehaviour
{
    public GameObject Card = null;

    public GameObject GameMan = null;
    public BattleSystem thisBattleSystem = null;
    public bool CanSelectCards = false;

    //[SerializeField] GameObject Player = null;

    public bool selected = false;
    public bool tried = false;
    
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
        if (thisBattleSystem.EnemyTurn)
        {
            CanSelectCards = true;
        }
        else
        {
            CanSelectCards = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject aCard = collision.gameObject;

        if (aCard != null)
        {
            Card = aCard;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject aCard = other.gameObject;

        if (aCard != null)
        {
            Card = aCard;
        }
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
