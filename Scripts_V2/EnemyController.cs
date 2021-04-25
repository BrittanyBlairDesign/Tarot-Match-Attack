using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //Get Enemy Cards
    [SerializeField] GameObject CardPose1;
    [SerializeField] GameObject CardPose2;
    [SerializeField] GameObject CardPose3;
    [SerializeField] GameObject CardPose4;
    [SerializeField] GameObject CardPose5;

    public Cards Card1;
    public Cards Card2;
    public Cards Card3;
    public Cards Card4;
    public Cards Card5;

    [SerializeField] Unit EnemyUnit;
    [SerializeField] BattleHUD EnemyHUD;

    //timer
    float timer;
    float durr = 2;

    // main card
    private Cards MainCard;
    //Selection
    public int CardsSelected = 0;
    public int MaxSelection = 3;

    //Battle Phase
    [SerializeField] BattlePhase thisBattlePHase;

    //started
    public bool started = false;
    public bool erased = false;

    // Start is called before the first frame update
    void Start()
    {
        timer = durr;
    }

    // Update is called once per frame
    void Update()
    {
        if (thisBattlePHase.GameState == Battle.START)
        {
            Hand();
        }

        if(thisBattlePHase.GameState == Battle.ENEMYTURN)
        {
            if (!started)
            {
                Hand();
                StartCoroutine(SelectCards());
            }


        }

        if (erased)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                thisBattlePHase.EnemyDraw();
                erased = false;
                started = false;
                timer = durr;

            }
        }

        if (thisBattlePHase.GameState == Battle.ENEMYDRAW)
        {
            if(timer > 0)
            {
                timer -= Time.deltaTime;

            }
            else
            {
                timer = durr;
                Respawn();
            }
        }
    }

    protected void Hand()
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

    }

    public IEnumerator SelectCards()
    {
        started = true;

        int RandomNumber =  thisBattlePHase.RandomNumber(6);

        if(RandomNumber == 1)
        {
            if(Card1.CardCost < EnemyUnit.thisCurrentAP)
            {
                CardSlots slot1 = CardPose1.GetComponent<CardSlots>();
                slot1.Select();
                MainCard = Card1;
                CardsSelected = 1;
                Check2();
                Check3();
                Check4();
                Check5();

            }
            else
            {
                StartCoroutine(SelectCards());

            }
            
        }
        else
        if(RandomNumber == 2)
        {
            if (Card2.CardCost < EnemyUnit.thisCurrentAP)
            {
                MainCard = Card2;
                CardsSelected = 1;
                CardSlots slot2 = CardPose2.GetComponent<CardSlots>();
                slot2.Select();
                Check1();
                Check3();
                Check4();
                Check5();

            }
            else
            {
                StartCoroutine(SelectCards());
            }
        }
        else
        if(RandomNumber == 3)
        {
            if (Card3.CardCost < EnemyUnit.thisCurrentAP)
            {
                MainCard = Card3;
                CardsSelected = 1;
                CardSlots slot3 = CardPose3.GetComponent<CardSlots>();
                slot3.Select();
                Check1();
                Check2();
                Check4();
                Check5();
            }
            else
            {
                StartCoroutine(SelectCards());
            }
        }
        else
        if(RandomNumber == 4)
        {
            if (Card4.CardCost < EnemyUnit.thisCurrentAP)
            {
                MainCard = Card4;
                CardsSelected = 1;
                CardSlots slot4 = CardPose4.GetComponent<CardSlots>();
                slot4.Select();
                Check1();
                Check2();
                Check3();
                Check5();
            }
            else
            {
                StartCoroutine(SelectCards());
            }
        }
        else
        if(RandomNumber == 5)
        {
            if (Card5.CardCost < EnemyUnit.thisCurrentAP)
            {
                MainCard = Card5;
                CardsSelected = 1;
                CardSlots slot5 = CardPose5.GetComponent<CardSlots>();
                slot5.Select();
                Check1();
                Check2();
                Check3();
                Check4();
            }
            else
            {
                StartCoroutine(SelectCards());
            }
        }



        yield return new WaitForSeconds(2);

        if(CardsSelected >= 1)
        {
            StartCoroutine( thisBattlePHase.EnemyAttack(MainCard));
            
        }

    }

    //MATCH CHECKING
    private void Check1()
    {
        if(Card1.tag == MainCard.tag && CardsSelected < 3)
        {
            CardSlots slot1 = CardPose1.GetComponent<CardSlots>();
            slot1.Select();
            CardsSelected++;
        }
    }

    private void Check2()
    {
        if (Card2.tag == MainCard.tag && CardsSelected < 3)
        {
            CardSlots slot2 = CardPose2.GetComponent<CardSlots>();
            slot2.Select();
            CardsSelected++;
        }
    }

    private void Check3()
    {
        if (Card3.tag == MainCard.tag && CardsSelected < 3)
        {
            CardSlots slot3 = CardPose3.GetComponent<CardSlots>();
            slot3.Select();
            CardsSelected++;
        }
    }

    private void Check4()
    {
        if (Card4.tag == MainCard.tag && CardsSelected < 3)
        {
            CardSlots slot4 = CardPose4.GetComponent<CardSlots>();
            slot4.Select();
            CardsSelected++;
        }
    }

    private void Check5()
    {
        if (Card5.tag == MainCard.tag && CardsSelected < 3)
        {
            CardSlots slot5 = CardPose5.GetComponent<CardSlots>();
            slot5.Select();
            CardsSelected++;
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

        

        erased = true;
        
    }

    public void Respawn()
    {
        if(Card1 == null)
        {
            CardSlots slot1 = CardPose1.GetComponent<CardSlots>();
            slot1.SpawnNewCards();
            
        }

        if(Card2 == null)
        {
            CardSlots slot2 = CardPose2.GetComponent<CardSlots>();
            slot2.SpawnNewCards();
            
        }

        if(Card3 == null)
        {
            CardSlots slot3 = CardPose3.GetComponent<CardSlots>();
            slot3.SpawnNewCards();
            
        }

        if(Card4 == null)
        {
            CardSlots slot4 = CardPose4.GetComponent<CardSlots>();
            slot4.SpawnNewCards();
           
        }

        if(Card5 == null)
        {
            CardSlots slot5 = CardPose5.GetComponent<CardSlots>();
            slot5.SpawnNewCards();
            
        }

        thisBattlePHase.PlayerTurn();
    }
}
