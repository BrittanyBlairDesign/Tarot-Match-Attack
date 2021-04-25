using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    //Card Positions
    [SerializeField] private GameObject[] CardPositions = null;
    [SerializeField] private GameObject cardPrefab = null;

    //Cards
    private GameObject Slot1 = null;
    private GameObject Slot2 = null;
    private GameObject Slot3 = null;
    private GameObject slot4 = null;
    private GameObject slot5 = null;

    //slots
    public EnemySlot Card1 = null;
    public EnemySlot Card2 = null;
    public EnemySlot Card3 = null;
    public EnemySlot Card4 = null;
    public EnemySlot Card5 = null;


    //Enemy turn
    private GameObject BattleManager;
    private BattleSystem BattleSys;

    public bool EnemyTurn = false;
    public Unit EnemyUnit;

    //Selection
    public int CardsSelected = 0;
    public int MaxSelection = 3;

    //SelectionPositions
    GameObject FirstCardSelected = null;
    GameObject SecondCardSelected = null;
    GameObject ThirdCardSelected = null;

    //SelectedCard 
    public GameObject thisCard = null;
    public Cards CardStats = null;

    bool CardPicked = false;
    public int tried = 0;

    //Player Unit
    GameObject ThePlayer = null;
    Unit PlayerUnit = null;
    // Start is called before the first frame update
    void Start()
    {
        BattleManager = GameObject.FindGameObjectWithTag("Manager");
        BattleSys = BattleManager.GetComponent<BattleSystem>();

        ThePlayer = GameObject.FindGameObjectWithTag("Player");
        PlayerUnit = ThePlayer.GetComponent<Unit>();
        EnemyUnit = GetComponent<Unit>();

        foreach (GameObject CardSlot in CardPositions)
        {
            if (Slot1 = null)
            {
                Slot1 = CardSlot;

            }
            else
            if (Slot2 = null)
            {
                Slot2 = CardSlot;

            }
            else
            if (Slot3 = null)
            {
                Slot3 = CardSlot;


            }
            else
            if (slot4 = null)
            {
                slot4 = CardSlot;

            }
            else
            {
                slot5 = CardSlot;

            }
            Instantiate(cardPrefab, CardSlot.transform.position, CardSlot.transform.rotation,CardSlot.transform);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (BattleSys.EnemyTurn)
        {
            EnemyTurn = true;

            if (!CardPicked)
            {
                int ChooseCard = Random.Range(0, 5);
                MaxSelection = Random.Range(1, 4);

                if (ChooseCard == 0)
                {
                    CardSlot1(Card1.Card);
                }
                else
                if (ChooseCard == 1)
                {
                    CardSlot2(Card2.Card);
                }
                else
                if (ChooseCard == 2)
                {
                    CardSlot3(Card3.Card);
                }
                else
                if (ChooseCard == 3)
                {
                    CardSlot4(Card4.Card);
                }
                else
                if (ChooseCard == 4)
                {
                    CardSlot5(Card5.Card);
                }

            }

        }
        else
        {
            EnemyTurn = false;
        }

        if (thisCard != null)
        {
            if (tried < 5)
            {

                if (!Card1.tried)
                {
                    CardSlot1(Card1.Card);
                }
                if (!Card2.tried)
                {
                    CardSlot2(Card2.Card);
                }
                if (!Card3.tried)
                {
                    CardSlot3(Card3.Card);
                }
                if (!Card4.tried)
                {
                    CardSlot4(Card4.Card);
                }
                if (!Card5.tried)
                {
                    CardSlot5(Card5.Card);
                }

            }
        }

        if(tried == 5)
        {
            print("ATTACK PLAYER");
            BattleSys.EnemyAttack = true ;
        }
    }

     public void CardSlot1(GameObject Card)
     {
        
        GameObject CardInSlot = Card;
        Cards theCard = CardInSlot.GetComponent<Cards>();
        Card1.tried = true;
        tried++;

        if (theCard.CardCost < EnemyUnit.thisCurrentAP)
        {

            if (CardsSelected == 0)
            {
                thisCard = Card;
                CardStats = thisCard.GetComponent<Cards>();
                FirstCardSelected = Slot1;
                Card1.ZoomIN();
                CardsSelected = 1;
                Card1.selected = true;
                CardPicked = true;
                
            }
            else
            if (CardsSelected == 1)
            {
                if (thisCard.tag == CardInSlot.tag)
                {
                    SecondCardSelected = Slot1;
                    CardsSelected = 2;
                    Card1.ZoomIN();
                    Card1.selected = true;
                }
            }
            else
            if (CardsSelected == 2)
            {
                if (thisCard.tag == CardInSlot.tag)
                {
                    ThirdCardSelected = Slot1;
                    CardsSelected = 3;
                    Card1.ZoomIN();
                    Card1.selected = true;
                }
            }

        }
    }

    // If Card in Slot2 selected
    public void CardSlot2(GameObject Card)
    {
        GameObject CardInSlot = Card;
        Cards theCard = CardInSlot.GetComponent<Cards>();
        Card2.tried = true;
        tried++;

        if (theCard.CardCost < EnemyUnit.thisCurrentAP)
        {

            if (CardsSelected == 0)
            {
                thisCard = CardInSlot;
                CardStats = thisCard.GetComponent<Cards>();
                FirstCardSelected = Slot2;
                CardsSelected = 1;
                Card2.ZoomIN();
                Card2.selected = true;
                CardPicked = true;
            }
            else
            if (CardsSelected == 1)
            {
                if (thisCard.tag == CardInSlot.tag)
                {
                    SecondCardSelected = Slot2;
                    CardsSelected = 2;
                    Card2.ZoomIN();
                    Card2.selected = true;
                }
            }
            else
            if (CardsSelected == 2)
            {
                if (thisCard.tag == CardInSlot.tag)
                {
                    ThirdCardSelected = Slot2;
                    CardsSelected = 3;
                    Card2.ZoomIN();
                    Card2.selected = true;
                }
            }
        }
    }

    // if Card in Slot3 Selected
    public void CardSlot3(GameObject Card)
    {
        GameObject CardInSlot = Card;
        Cards theCard = CardInSlot.GetComponent<Cards>();
        Card3.tried = true;
        tried++;

        if (theCard.CardCost < EnemyUnit.thisCurrentAP)
        {

            if (CardsSelected == 0)
            {
                thisCard = CardInSlot;
                CardStats = thisCard.GetComponent<Cards>();
                FirstCardSelected = Slot3;
                CardsSelected = 1;
                Card3.ZoomIN();
                Card3.selected = true;
                CardPicked = true;
            }
            else
            if (CardsSelected == 1)
            {
                if (thisCard.tag == CardInSlot.tag)
                {
                    SecondCardSelected = Slot3;
                    CardsSelected = 2;
                    Card3.ZoomIN();
                    Card3.selected = true;
                }
            }
            else
            if (CardsSelected == 2)
            {
                if (thisCard.tag == CardInSlot.tag)
                {
                    ThirdCardSelected = Slot3;
                    CardsSelected = 3;
                    Card3.ZoomIN();
                    Card3.selected = true;
                }
            }
        }
    }

    //if Card in Slot4 Selected
    public void CardSlot4(GameObject Card)
    {
        GameObject CardInSlot = Card;
        Cards theCard = CardInSlot.GetComponent<Cards>();
        Card4.tried = true;
        tried++;

        if (theCard.CardCost < EnemyUnit.thisCurrentAP)
        {

            if (CardsSelected == 0)
            {
                thisCard = CardInSlot;
                CardStats = thisCard.GetComponent<Cards>();
                FirstCardSelected = slot4;
                CardsSelected = 1;
                Card4.ZoomIN();
                Card4.selected = true;
                CardPicked = true;
            }
            else
            if (CardsSelected == 1)
            {
                if (thisCard.tag == CardInSlot.tag)
                {
                    SecondCardSelected = slot4;
                    CardsSelected = 2;
                    Card4.ZoomIN();
                    Card4.selected = true;
                }
            }
            else
            if (CardsSelected == 2)
            {
                if (thisCard.tag == CardInSlot.tag)
                {
                    ThirdCardSelected = slot4;
                    CardsSelected = 3;
                    Card4.ZoomIN();
                    Card4.selected = true;
                }
            }
        }
    }

    //if Card in Slot 5 Selected
    public void CardSlot5(GameObject Card)
    {
        GameObject CardInSlot = Card;
        Cards theCard = CardInSlot.GetComponent<Cards>();
        Card5.tried = true;
        tried++;

        if (theCard.CardCost < EnemyUnit.thisCurrentAP)
        {
       
            if (CardsSelected == 0)
            {
                thisCard = CardInSlot;
                CardStats = thisCard.GetComponent<Cards>();
                FirstCardSelected = slot5;
                CardsSelected = 1;
                Card5.ZoomIN();
                Card5.selected = true;
                CardPicked = true;
            }
            else
            if (CardsSelected == 1)
            {
                if (thisCard.tag == CardInSlot.tag)
                {
                    SecondCardSelected = slot5;
                    CardsSelected = 2;
                    Card5.ZoomIN();
                    Card5.selected = true;
                }
            }
            else
            if (CardsSelected == 2)
            {
                if (thisCard.tag == CardInSlot.tag)
                {
                    ThirdCardSelected = slot5;
                    CardsSelected = 3;
                    Card5.ZoomIN();
                    Card5.selected = true;
                }
            }

        }
    }


    public void EraseCards()
    {

        if (Card1.tried)
        {
            Card1.tried = false;
            tried--;
            if (Card1.selected)
            {
                Card1.Card.SetActive(false);
            }
        }
        if (Card2.tried)
        {
            Card2.tried = false;
            tried--; 
            if (Card2.selected)
            {
                Card2.Card.SetActive(false);
            }
        }
        if (Card3.tried)
        {
            Card3.tried = false;
            tried--;
            if (Card3.selected)
            {
                Card3.Card.SetActive(false);
            }

        }
        if (Card4.tried)
        {

            Card4.tried = false;
            tried--;
            if (Card4.selected)
            {
                Card4.Card.SetActive(false);
            }
        }
        if (Card5.tried)
        {
            Card5.tried = false;
            tried--;
            if (Card5.selected)
            {
                Card5.Card.SetActive(false);
            }
        }

        thisCard = null;
        CardsSelected = 0;
        FirstCardSelected = null;
        SecondCardSelected = null;
        ThirdCardSelected = null;

        CardPicked = false;
    }

    public void FullHand()
    {
        if (Card1.Card == null)
        {
            return;
        }
        else
        if (Card2.Card == null)
        {
            return;
        }
        else
        if (Card3.Card == null)
        {
            return;
        }
        else
        if (Card4.Card == null)
        {
            return;
        }
        else
        if (Card5.Card == null)
        {
            return;
        }
        else
        {
            
            BattleSys.PlayerTurn();
        }
    }

}
