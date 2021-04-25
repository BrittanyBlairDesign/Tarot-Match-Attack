using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Card Positions
    [SerializeField] private GameObject[] CardPositions = null;
    [SerializeField] private GameObject cardPrefab = null;
    private GameObject[] allSelected = null;

    //BattleState
    public GameObject GameMan = null;
    public BattleSystem thisBattleSystem = null;

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

    bool SelectedSlot1 = false;
    bool SelectedSlot2 = false;
    bool SelectedSlot3 = false;
    bool SelectedSlot4 = false;
    bool SelectedSlot5 = false;

    // Empty Card Slots
    public GameObject CardSlot1 = null;
    public GameObject CardSlot2 = null;
    public GameObject CardSlot3 = null;
    public GameObject Cardslot4 = null;
    public GameObject Cardslot5 = null;


    // Start is called before the first frame update
    void Start()
    {
        //set up the game manager
        GameMan = GameObject.FindGameObjectWithTag("Manager");
        thisBattleSystem = GameMan.GetComponent<BattleSystem>();

        //prepare the selection list

        allSelected = new GameObject[3];

        //spawn player cards
        foreach (GameObject CardSlot in CardPositions)
        {
            if (CardSlot1 == null)
            {
               CardSlot1 = CardSlot;

            }
            else
            if (CardSlot2 == null)
            {
                CardSlot2 = CardSlot;

            }
            else
            if (CardSlot3 == null)
            {
                CardSlot3 = CardSlot;


            }
            else
            if (Cardslot4 == null)
            {
                Cardslot4 = CardSlot;

            }
            else
            {
                Cardslot5 = CardSlot;

            }
            Instantiate(cardPrefab, CardSlot.transform.position, CardSlot.transform.rotation, CardSlot.transform);
        }
    }

    //updates every frame
    private void Update()
    {


    }

    // IF card in slot 1 Selected
    public void Slot1(GameObject Card)
    {
        //check if this card has already been selected, and check if theres room to select more cards
        if (!SelectedSlot1 && CardsSelected<3)
        {
            //grab the slot script
            PlayerSlot SlotCard = Card.GetComponent<PlayerSlot>();
            //get the card in that slot
            GameObject CardInSlot = SlotCard.Card;
            //find the card script
            Cards theCard = CardInSlot.GetComponent<Cards>();
            //get the player Unit
            Unit PlayerUnit = GetComponent<Unit>();
            //set the cardslot
            CardSlot1 = Card;

            // check if the cost to play the card is less than what the players attack points are
            if (theCard.CardCost < PlayerUnit.thisCurrentAP)
            {
                //when this is the first card picked
                if (CardsSelected == 0)
                {
                    //set this first card selection to the main card
                    thisCard = CardInSlot;
                    //get the cards stats
                    CardStats = thisCard.GetComponent<Cards>();
                    //los the card slot as selected
                    FirstCardSelected = CardSlot1;
                    SelectedSlot1 = true;

                    //set number of selected cards
                    CardsSelected = 1;
                    SlotCard.Selected = true;

                    //add card to the listthi
                    allSelected[0] = Card;
                }
                else
                if (CardsSelected == 1)
                {
                    if (thisCard.tag == CardInSlot.tag)
                    {
                        SecondCardSelected = CardSlot1;
                        SelectedSlot1 = true;
                        CardsSelected = 2;
                        SlotCard.ZoomIN();
                        SlotCard.Selected = true;
                        allSelected[1] = Card;
                    }
                }
                else
                if (CardsSelected == 2)
                {
                    if (thisCard.tag == CardInSlot.tag)
                    {
                        ThirdCardSelected = CardSlot1;
                        SelectedSlot1 = true;
                        CardsSelected = 3;
                        SlotCard.ZoomIN();
                        SlotCard.Selected = true;
                        allSelected[2] = Card;
                    }
                }
            }

            SelectedSlot1 = true;
        }
    }

    // If Card in Slot2 selected
    public void Slot2(GameObject Card)
    {
        if (!SelectedSlot2 && CardsSelected < 3)
        {


            PlayerSlot SlotCard = Card.GetComponent<PlayerSlot>();
            GameObject CardInSlot = SlotCard.Card;
            Cards theCard = CardInSlot.GetComponent<Cards>();
            Unit PlayerUnit = GetComponent<Unit>();
            CardSlot2 = Card;

            if (theCard.CardCost < PlayerUnit.thisCurrentAP)
            {

                if (CardsSelected == 0)
                {
                    thisCard = CardInSlot;
                    CardStats = thisCard.GetComponent<Cards>();
                    FirstCardSelected = CardSlot2;
                    SelectedSlot2 = true;
                    CardsSelected = 1;
                    SlotCard.ZoomIN();
                    SlotCard.Selected = true;
                    allSelected[0] = Card;
                }
                else
                if (CardsSelected == 1)
                {
                    if (thisCard.tag == CardInSlot.tag)
                    {
                        SecondCardSelected = CardSlot2;
                        CardsSelected = 2;
                        SelectedSlot2 = true;
                        SlotCard.ZoomIN();
                        SlotCard.Selected = true;
                        allSelected[1] = Card;
                    }
                }
                else
                if (CardsSelected == 2)
                {
                    if (thisCard.tag == CardInSlot.tag)
                    {
                        ThirdCardSelected = CardSlot2;
                        CardsSelected = 3;
                        allSelected[2] = Card;
                        SlotCard.ZoomIN();
                        SlotCard.Selected = true;
                    }
                }
            }

            SelectedSlot2 = true;
        }
    }

    // if Card in Slot3 Selected
    public void Slot3(GameObject Card)
    {
        if (!SelectedSlot3 && CardsSelected < 3)
        {


            PlayerSlot SlotCard = Card.GetComponent<PlayerSlot>();
            GameObject CardInSlot = SlotCard.Card;
            Cards theCard = CardInSlot.GetComponent<Cards>();
            Unit PlayerUnit = GetComponent<Unit>();
            CardSlot3 = Card;

            if (theCard.CardCost < PlayerUnit.thisCurrentAP)
            {

                if (CardsSelected == 0)
                {
                    thisCard = CardInSlot;
                    CardStats = thisCard.GetComponent<Cards>();
                    FirstCardSelected = CardSlot3;
                    CardsSelected = 1;
                    SlotCard.ZoomIN();
                    allSelected[0] = Card;
                    SlotCard.Selected = true;
                }
                else
                if (CardsSelected == 1)
                {
                    if (thisCard.tag == CardInSlot.tag)
                    {
                        SecondCardSelected = CardSlot3;
                        CardsSelected = 2;
                        SlotCard.ZoomIN();
                        allSelected[1] = Card;
                        SlotCard.Selected = true;
                    }
                }
                else
                if (CardsSelected == 2)
                {
                    if (thisCard.tag == CardInSlot.tag)
                    {
                        ThirdCardSelected = CardSlot3;
                        CardsSelected = 3;
                        SlotCard.ZoomIN();
                        allSelected[2] = Card;
                        SlotCard.Selected = true;
                    }
                }
            }
            SelectedSlot3 = true;
        }
    }

    //if Card in Slot4 Selected
    public void Slot4(GameObject Card)
    {
        if (!SelectedSlot4 && CardsSelected < 3)
        {
            PlayerSlot SlotCard = Card.GetComponent<PlayerSlot>();
            GameObject CardInSlot = SlotCard.Card;
            Cards theCard = CardInSlot.GetComponent<Cards>();
            Unit PlayerUnit = GetComponent<Unit>();
            Cardslot4 = Card;

            if (theCard.CardCost < PlayerUnit.thisCurrentAP)
            {

                if (CardsSelected == 0)
                {
                    thisCard = CardInSlot;
                    CardStats = thisCard.GetComponent<Cards>();
                    FirstCardSelected = Cardslot4;
                    CardsSelected = 1;
                    SlotCard.ZoomIN();
                    allSelected[0] = Card;
                    SlotCard.Selected = true;
                }
                else
                if (CardsSelected == 1)
                {
                    if (thisCard.tag == CardInSlot.tag)
                    {
                        SecondCardSelected = Cardslot4;
                        CardsSelected = 2;
                        SlotCard.ZoomIN();
                        allSelected[1] = Card;
                        SlotCard.Selected = true;
                    }
                }
                else
                if (CardsSelected == 2)
                {
                    if (thisCard.tag == CardInSlot.tag)
                    {
                        ThirdCardSelected = Cardslot4;
                        CardsSelected = 3;
                        SlotCard.ZoomIN();
                        allSelected[2] = Card;
                        SlotCard.Selected = true;
                    }
                }
            }
            SelectedSlot4 = true;
        }
    }

    //if Card in Slot 5 Selected
    public void Slot5(GameObject Card)
    {
        if (!SelectedSlot5 && CardsSelected < 3)
        {


            PlayerSlot SlotCard = Card.GetComponent<PlayerSlot>();
            GameObject CardInSlot = SlotCard.Card;
            Cards theCard = CardInSlot.GetComponent<Cards>();
            Unit PlayerUnit = GetComponent<Unit>();
            Cardslot5 = Card;

            if (theCard.CardCost < PlayerUnit.thisCurrentAP)
            {

                if (CardsSelected == 0)
                {
                    thisCard = CardInSlot;
                    CardStats = thisCard.GetComponent<Cards>();
                    FirstCardSelected = Cardslot5;
                    CardsSelected = 1;
                    SlotCard.ZoomIN();
                    allSelected[0] = Card;
                    SlotCard.Selected = true;
                }
                else
                if (CardsSelected == 1)
                {
                    if (thisCard.tag == CardInSlot.tag)
                    {
                        SecondCardSelected = Cardslot5;
                        CardsSelected = 2;
                        SlotCard.ZoomIN();
                        allSelected[1] = Card;
                        SlotCard.Selected = true;
                    }
                }
                else
                if (CardsSelected == 2)
                {
                    if (thisCard.tag == CardInSlot.tag)
                    {
                        ThirdCardSelected = Cardslot5;
                        CardsSelected = 3;
                        SlotCard.ZoomIN();
                        allSelected[2] = Card;
                        SlotCard.Selected = true;
                    }
                }
            }

            SelectedSlot5 = true;
        }
    }


    public void Reset()
    {
        thisCard = null;
        FirstCardSelected = null;
        SecondCardSelected = null;
        ThirdCardSelected = null;
        CardsSelected = 0;

        SelectedSlot1 = false;
        SelectedSlot2 = false;
        SelectedSlot3 = false;
        SelectedSlot4 = false;
        SelectedSlot5 = false;

    } 


    public void EraseCards()
    {

        if(CardsSelected == 1)
        {
            PlayerSlot SlotScript = allSelected[0].GetComponent<PlayerSlot>();
            SlotScript.Card.SetActive(false);
            SlotScript.Card = null;
            
        }
        else
        if(CardsSelected == 2)
        {
            PlayerSlot SlotScript = allSelected[0].GetComponent<PlayerSlot>();
            SlotScript.Card.SetActive(false);
            SlotScript.Card = null;

            SlotScript = allSelected[1].GetComponent<PlayerSlot>();
            SlotScript.Card.SetActive(false);
            SlotScript.Card = null;
        }
        if(CardsSelected == 3)
        {
            PlayerSlot SlotScript = allSelected[0].GetComponent<PlayerSlot>();
            SlotScript.Card.SetActive(false);
            SlotScript.Card = null;

            SlotScript = allSelected[1].GetComponent<PlayerSlot>();
            SlotScript.Card.SetActive(false);
            SlotScript.Card = null;

            SlotScript = allSelected[2].GetComponent<PlayerSlot>();
            SlotScript.Card.SetActive(false);
            SlotScript.Card = null;
        }

        allSelected = new GameObject[3];

        Reset();
        thisBattleSystem.PlayerDraw = true;
        thisBattleSystem.PlayerDrawCard();
    }
    
    public void SelectionComplete()
    {
        thisBattleSystem.PlayerAttacking = true;
        thisBattleSystem.PlayerSelect = false;
    }

    public void AllCardsSelected()
    {
        thisBattleSystem.PlayerDraw = false;
        thisBattleSystem.Enemyturn();
    }
}
