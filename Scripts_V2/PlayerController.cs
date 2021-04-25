using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //PlayerCard Positions
    [SerializeField] public GameObject CardPose1;
    [SerializeField] public GameObject CardPose2;
    [SerializeField] public GameObject CardPose3;
    [SerializeField] public GameObject CardPose4;
    [SerializeField] public GameObject CardPose5;

    public Cards Card1;
    public Cards Card2;
    public Cards Card3;
    public Cards Card4;
    public Cards Card5;

    [SerializeField] GameObject VFX1;
    [SerializeField] GameObject VFX2;
    [SerializeField] GameObject VFX3;
    [SerializeField] GameObject VFX4;
    [SerializeField] GameObject VFX5;


    // Player Unit and HUD
    [SerializeField] private Unit PlayerUnit;
    [SerializeField] private BattleHUD PlayerHUd;


    //Selection
    public int CardsSelected = 0;
    public int MaxSelection = 3;

    private Cards MainCard;

    //Battle Phase
    [SerializeField] BattlePhase thisBattlePHase;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(thisBattlePHase.GameState == Battle.START)
       {
            Hand();
       }

       if(thisBattlePHase.GameState == Battle.PLAYERTURN)
       {
            if(CardsSelected >= 1 && Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(thisBattlePHase.PlayerAttack(MainCard));
            }
       }

       if(thisBattlePHase.GameState == Battle.PLAYERDRAW)
        {
            VFX1.SetActive(false);
            VFX2.SetActive(false);
            VFX3.SetActive(false);
            VFX4.SetActive(false);
            VFX5.SetActive(false);
        }
    }

    public void Hand()
    {

        CardSlots slot1 = CardPose1.GetComponent<CardSlots>();
        Card1 = slot1.Card.GetComponent<Cards>();

        CardSlots slot2 = CardPose2.GetComponent<CardSlots>();
        Card2 = slot2.Card.GetComponent<Cards>();

        CardSlots slot3 = CardPose3.GetComponent<CardSlots>();
        Card3 = slot3.Card.GetComponent<Cards>();

        CardSlots slot4 = CardPose4.GetComponent<CardSlots>();
        Card4 = slot4.Card.GetComponent<Cards>();

        CardSlots slot5 = CardPose5.GetComponent<CardSlots>();
        Card5 = slot5.Card.GetComponent<Cards>();



        //thisBattlePHase.EnemyTurn();

    }


    // CARD SLOT SELECTION

    public void Select1(CardSlots Cardslot1)
    {
        // check if the its the players turn
        if(thisBattlePHase.GameState == Battle.PLAYERTURN)
        {
            // check if this card has already been selected
            if(!Cardslot1.Selected && CardsSelected < 3)
            {
                //check if the player can afford the card
                if(Card1.CardCost < PlayerUnit.thisCurrentAP || CardsSelected < 0)
                {

                    // find the players current number of selected cards
                    if(CardsSelected == 0)
                    {
                        // select that card
                        Cardslot1.Select();

                        //make this the first selected card
                        MainCard = Card1;

                        //add to the number of cards selected
                        CardsSelected = 1;

                        // zoom in on the card
                        Cardslot1.ZoomIN();

                        //visual effect
                        VFX1.SetActive(true);

                    }
                    else
                    if(CardsSelected == 1 && Card1.tag == MainCard.tag)
                    {
                        Cardslot1.Select();

                        CardsSelected = 2;
                        VFX1.SetActive(true);
                    }
                    else
                    if(CardsSelected == 2 && Card1.tag == MainCard.tag)
                    {
                        Cardslot1.Select();
                        CardsSelected = 3;
                        VFX1.SetActive(true);
                    }
                }
            }
            else
            if (Cardslot1.Selected)
            {
                Cardslot1.Selected = false;
                Cardslot1.ZoomOUT();
                CardsSelected--;
                VFX1.SetActive(false);

                if (CardsSelected >= 0)
                {
                    MainCard = null;
                }
            }

        }
    }


    public void Select2(CardSlots Cardslot2)
    {
        // check if the its the players turn
        if (thisBattlePHase.GameState == Battle.PLAYERTURN)
        {
            // check if this card has already been selected
            if (!Cardslot2.Selected && CardsSelected < 3)
            {
                //check if the player can afford the card
                if (Card2.CardCost < PlayerUnit.thisCurrentAP || CardsSelected < 0)
                {

                    // find the players current number of selected cards
                    if (CardsSelected == 0)
                    {
                        // select that card
                        Cardslot2.Select();

                        //make this the first selected card
                        MainCard = Card2;

                        //add to the number of cards selected
                        CardsSelected = 1;

                        // zoom in on the card
                        Cardslot2.ZoomIN();

                        //visual effect
                        VFX2.SetActive(true);
                    }
                    else
                    if (CardsSelected == 1 && Card2.tag == MainCard.tag)
                    {
                        Cardslot2.Select();

                        CardsSelected = 2;
                        VFX2.SetActive(true);
                    }
                    else
                    if (CardsSelected == 2 && Card2.tag == MainCard.tag)
                    {
                        Cardslot2.Select();
                        CardsSelected = 3;
                        VFX2.SetActive(true);
                    }
                }
            }
            else
            if (Cardslot2.Selected)
            {
                Cardslot2.Selected = false;
                Cardslot2.ZoomOUT();
                CardsSelected--;
                VFX2.SetActive(false);

                if (CardsSelected >= 0)
                {
                    MainCard = null;
                }
            }

        }
    }

    public void Select3(CardSlots Cardslot3)
    {
        // check if the its the players turn
        if (thisBattlePHase.GameState == Battle.PLAYERTURN)
        {
            // check if this card has already been selected
            if (!Cardslot3.Selected && CardsSelected < 3)
            {
                //check if the player can afford the card
                if (Card3.CardCost < PlayerUnit.thisCurrentAP || CardsSelected < 0)
                {

                    // find the players current number of selected cards
                    if (CardsSelected == 0)
                    {
                        // select that card
                        Cardslot3.Select();

                        //make this the first selected card
                        MainCard = Card3;

                        //add to the number of cards selected
                        CardsSelected = 1;

                        // zoom in on the card
                        Cardslot3.ZoomIN();

                        //visual effect
                        VFX3.SetActive(true);
                    }
                    else
                    if (CardsSelected == 1 && Card3.tag == MainCard.tag)
                    {
                        Cardslot3.Select();

                        CardsSelected = 2;
                        VFX3.SetActive(true);
                    }
                    else
                    if (CardsSelected == 2 && Card3.tag == MainCard.tag)
                    {
                        Cardslot3.Select();
                        CardsSelected = 3;
                        VFX3.SetActive(true);
                    }
                }
            }
            else
            if (Cardslot3.Selected)
            {
                Cardslot3.Selected = false;
                Cardslot3.ZoomOUT();
                CardsSelected--;
                VFX3.SetActive(false);

                if (CardsSelected >= 0)
                {
                    MainCard = null;
                }
            }

        }
    }


    public void Select4(CardSlots Cardslot4)
    {
        // check if the its the players turn
        if (thisBattlePHase.GameState == Battle.PLAYERTURN)
        {
            print("propper state");
            // check if this card has already been selected
            if (!Cardslot4.Selected && CardsSelected < 3)
            {
                print("not selected and less than 3");
                //check if the player can afford the card
                if (Card4.CardCost < PlayerUnit.thisCurrentAP || CardsSelected < 0)
                {
                    print("CanAfford");
                    // find the players current number of selected cards
                    if (CardsSelected == 0)
                    {
                        print("Selected");
                        // select that card
                        Cardslot4.Select();

                        //make this the first selected card
                        MainCard = Card4;

                        //add to the number of cards selected
                        CardsSelected = 1;

                        // zoom in on the card
                        Cardslot4.ZoomIN();


                        //visual effect
                        VFX4.SetActive(true);
                    }
                    else
                    if (CardsSelected == 1 && Card4.tag == MainCard.tag)
                    {
                        Cardslot4.Select();

                        CardsSelected = 2;
                        VFX4.SetActive(true);
                    }
                    else
                    if (CardsSelected == 2 && Card4.tag == MainCard.tag)
                    {
                        Cardslot4.Select();
                        CardsSelected = 3;
                        VFX4.SetActive(true);
                    }
                }
            }
            else
            if (Cardslot4.Selected)
            {
                Cardslot4.Selected = false;
                Cardslot4.ZoomOUT();
                CardsSelected--;
                VFX4.SetActive(false);

                if (CardsSelected >= 0)
                {
                    MainCard = null;
                }
            }

        }
    }



    public void Select5(CardSlots Cardslot5)
    {
        // check if the its the players turn
        if (thisBattlePHase.GameState == Battle.PLAYERTURN)
        {
            // check if this card has already been selected
            if (!Cardslot5.Selected && CardsSelected < 3)
            {
                //check if the player can afford the card
                if (Card5.CardCost < PlayerUnit.thisCurrentAP || CardsSelected < 0)
                {

                    // find the players current number of selected cards
                    if (CardsSelected == 0)
                    {
                        // select that card
                        Cardslot5.Select();

                        //make this the first selected card
                        MainCard = Card5;

                        //add to the number of cards selected
                        CardsSelected = 1;

                        // zoom in on the card
                        Cardslot5.ZoomIN();

                        //visual effect
                        VFX5.SetActive(true);
                    }
                    else
                    if (CardsSelected == 1 && Card5.tag == MainCard.tag)
                    {
                        Cardslot5.Select();

                        CardsSelected = 2;
                        VFX5.SetActive(true);
                    }
                    else
                    if (CardsSelected == 2 && Card5.tag == MainCard.tag)
                    {
                        Cardslot5.Select();
                        CardsSelected = 3;
                        VFX5.SetActive(true);
                    }
                }
            }
            else
            if (Cardslot5.Selected)
            {
                Cardslot5.Selected = false;
                Cardslot5.ZoomOUT();
                CardsSelected--;

                VFX5.SetActive(false);


                if (CardsSelected >= 0)
                {
                    MainCard = null;
                }
            }

        }
    }



    //ERASE

    public void Erase()
    {
        CardSlots slot1 = CardPose1.GetComponent<CardSlots>();
        if (slot1.Selected)
        {
            Card1 = null;
        }
        slot1.Erase();

        CardSlots slot2 = CardPose2.GetComponent<CardSlots>();
        if (slot2.Selected)
        {
            Card2 = null;
        }
        slot2.Erase();

        CardSlots slot3 = CardPose3.GetComponent<CardSlots>();
        if (slot3.Selected)
        {
            Card3 = null;
        }
        slot3.Erase();

        CardSlots slot4 = CardPose4.GetComponent<CardSlots>();
        if (slot4.Selected)
        {
            Card4 = null;
        }
        slot4.Erase();

        CardSlots slot5 = CardPose5.GetComponent<CardSlots>();
        if (slot5.Selected)
        {
            Card5 = null;
        }
        slot5.Erase();

        MainCard = null;
        CardsSelected = 0;
        print("erased");
        thisBattlePHase.PlayerDrawCard();
    }
}
