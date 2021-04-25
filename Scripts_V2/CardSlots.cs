using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardSlots : MonoBehaviour
{
    //Card in this position
    public GameObject Card;

    // empty
    public bool Empty = false;

    //Card Prefab 
    [SerializeField] GameObject CardPrefab;

    // Who's Cards
    public bool player;
    public bool Enemy;
    public bool Table;

    //what game state 
    [SerializeField] BattlePhase thisBattlePHase;

    // can cards be selected
    public bool Selectable = false;

    public bool Selected = false;

    //Zoom 
    public Vector3 StartPosition = Vector3.zero;
    public Vector3 ZoomPosition = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {

        Instantiate(CardPrefab, this.transform.position, this.transform.rotation, this.transform);
        StartPosition = this.transform.position;
        ZoomPosition = this.transform.position;
        ZoomPosition.y = .7f;
    }

    // Update is called once per frame
    void Update()
    {
        if(thisBattlePHase.GameState == Battle.START)
        {
            Selectable = false;
        }

        if(thisBattlePHase.GameState == Battle.PLAYERTURN)
        {
            if (player)
            {
                Selectable = true;
            }
            else
            {
                Selectable = false;
            }
        }

        if(thisBattlePHase.GameState == Battle.PLAYERDRAW)
        {
            if (Table)
            {
                Selectable = true;
            }
            else
            {
                Selectable = false;
            }
        }

        if(thisBattlePHase.GameState == Battle.ENEMYTURN)
        {
            if(Table || player)
            {
                Selectable = false;
            }
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
            Empty = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject OtherObject = collision.gameObject;

        Cards aCard;
        aCard = OtherObject.GetComponent<Cards>();

        if (aCard != null)
        {

            Card = OtherObject;
            Empty = false;
        }
    }

    public void Select()
    {
        Selected = true;
    }

    public void Erase()
    {
        if (Selected)
        {
            Card.SetActive(false);
            Empty = true;
            Card = null;
            Selected = false;
            ZoomOUT();
        }
    }

    public void SpawnNewCards()
    {
        if (Card == null)
        {
            Instantiate(CardPrefab, this.transform.position, this.transform.rotation, this.transform);
            Empty = false;
            ZoomOUT();
            Selected = false;
        }

    }

    //Zooming in and zooming out;

    private void OnMouseOver()
    {
        if (Selectable)
        {
            ZoomIN();
        }

    }

    private void OnMouseExit()
    {
        ZoomOUT();
    }

    public void ZoomIN()
    {
        this.transform.position = ZoomPosition;
    }

    public void ZoomOUT()
    {
        this.transform.position = StartPosition;
    }
}

