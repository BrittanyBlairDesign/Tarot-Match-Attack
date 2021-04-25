using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableController : MonoBehaviour
{
    // get the cards on the table
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

    // timer

    float Timer;
    float TimerDurration = 1.5f;
    //Player
    [SerializeField] PlayerController Player;
    bool playerHandFull = false;

    //Enemy
    [SerializeField] EnemyController Enemy;

    //Battle Phase
    [SerializeField] BattlePhase thisBattlePHase;

    // Start is called before the first frame update
    void Start()
    {
        Timer = TimerDurration;
    }

    // Update is called once per frame
    void Update()
    {
        if (thisBattlePHase.GameState == Battle.START)
        {
            Hand();
        }

        if(thisBattlePHase.GameState == Battle.PLAYERDRAW)
        {


            if (playerHandFull)
            {

                if (Timer > 0)
                {
                    Timer -= Time.deltaTime;
                }
                else
                {

                    CardSlots slot1 = CardPose1.GetComponent<CardSlots>();
                    slot1.SpawnNewCards();

                    CardSlots slot2 = CardPose2.GetComponent<CardSlots>();
                    slot2.SpawnNewCards();

                    CardSlots slot3 = CardPose3.GetComponent<CardSlots>();
                    slot3.SpawnNewCards();

                    CardSlots slot4 = CardPose4.GetComponent<CardSlots>();
                    slot4.SpawnNewCards();

                    CardSlots slot5 = CardPose5.GetComponent<CardSlots>();
                    slot5.SpawnNewCards();

                    thisBattlePHase.EnemyTurn();
                    playerHandFull = false;

                    Timer = TimerDurration;

                }
            }
        }

        if(thisBattlePHase.GameState == Battle.ENEMYDRAW)
        {
            Hand();
            
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

    //  PLAYER DRAW
    public void Selected1( CardSlots Slot1)
    {
        if (Slot1.Selectable)
        {

            //if player card 1 empty
            if (Player.Card1 == null)
            {
                //Move card
                Card1.transform.position = Player.CardPose1.transform.position;
                Card1.transform.rotation = Player.CardPose1.transform.rotation;
                Card1.transform.parent = Player.CardPose1.transform;
                Slot1.Card = null;
                Player.Card1 = Card1;
                Card1 = null;
            }
            else
            if (Player.Card2 == null)
            {
                Card1.transform.position = Player.CardPose2.transform.position;
                Card1.transform.rotation = Player.CardPose2.transform.rotation;
                Card1.transform.parent = Player.CardPose2.transform;
                Slot1.Card = null;
                Player.Card2 = Card1;
                Card1 = null;
            }
            else
            if (Player.Card3 == null)
            {
                Card1.transform.position = Player.CardPose3.transform.position;
                Card1.transform.rotation = Player.CardPose3.transform.rotation;
                Card1.transform.parent = Player.CardPose3.transform;
                Slot1.Card = null;
                Player.Card3 = Card1;
                Card1 = null;
            }
            else
            if (Player.Card4 == null)
            {
                Card1.transform.position = Player.CardPose4.transform.position;
                Card1.transform.rotation = Player.CardPose4.transform.rotation;
                Card1.transform.parent = Player.CardPose4.transform;
                Slot1.Card = null;
                Player.Card4 = Card1;
                Card1 = null;
            }
            else
            if (Player.Card5 == null)
            {
                Card1.transform.position = Player.CardPose5.transform.position;
                Card1.transform.rotation = Player.CardPose5.transform.rotation;
                Card1.transform.parent = Player.CardPose5.transform;
                Slot1.Card = null;
                Player.Card5 = Card1;
                Card1 = null;
            }
            CheckHand(Player);

        }
    }

    public void Selected2( CardSlots Slot2)
    {
        if (Slot2.Selectable)
        {


            //if player card 1 empty
            if (Player.Card1 == null)
            {
                //Move card
                Card2.transform.position = Player.CardPose1.transform.position;
                Card2.transform.rotation = Player.CardPose1.transform.rotation;
                Card2.transform.parent = Player.CardPose1.transform;
                Slot2.Card = null;
                Player.Card1 = Card2;
                Card2 = null;
            }
            else
            if (Player.Card2 == null)
            {
                Card2.transform.position = Player.CardPose2.transform.position;
                Card2.transform.rotation = Player.CardPose2.transform.rotation;
                Card2.transform.parent = Player.CardPose2.transform;
                Slot2.Card = null;
                Player.Card2 = Card2;
                Card2 = null;
            }
            else
            if (Player.Card3 == null)
            {
                Card2.transform.position = Player.CardPose3.transform.position;
                Card2.transform.rotation = Player.CardPose3.transform.rotation;
                Card2.transform.parent = Player.CardPose3.transform;
                Slot2.Card = null;
                Player.Card3 = Card2;
                Card2 = null;
            }
            else
            if (Player.Card4 == null)
            {
                Card2.transform.position = Player.CardPose4.transform.position;
                Card2.transform.rotation = Player.CardPose4.transform.rotation;
                Card2.transform.parent = Player.CardPose4.transform;
                Slot2.Card = null;
                Player.Card4 = Card2;
                Card2 = null;
            }
            else
            if (Player.Card5 == null)
            {
                Card2.transform.position = Player.CardPose5.transform.position;
                Card2.transform.rotation = Player.CardPose5.transform.rotation;
                Card2.transform.parent = Player.CardPose5.transform;
                Slot2.Card = null;
                Player.Card5 = Card2;
                Card2 = null;
            }
            CheckHand(Player);
        }
    }

    public void Selected3(CardSlots Slot3)
    {
        if (Slot3.Selectable)
        {


            //if player card 1 empty
            if (Player.Card1 == null)
            {
                //Move card
                Card3.transform.position = Player.CardPose1.transform.position;
                Card3.transform.rotation = Player.CardPose1.transform.rotation;
                Card3.transform.parent = Player.CardPose1.transform;
                Slot3.Card = null;
                Player.Card1 = Card3;
                Card3 = null;
            }
            else
            if (Player.Card2 == null)
            {
                Card3.transform.position = Player.CardPose2.transform.position;
                Card3.transform.rotation = Player.CardPose2.transform.rotation;
                Card3.transform.parent = Player.CardPose2.transform;
                Slot3.Card = null;
                Player.Card2 = Card3;
                Card3 = null;
            }
            else
            if (Player.Card3 == null)
            {
                Card3.transform.position = Player.CardPose3.transform.position;
                Card3.transform.rotation = Player.CardPose3.transform.rotation;
                Card3.transform.parent = Player.CardPose3.transform;
                Slot3.Card = null;
                Player.Card3 = Card3;
                Card3 = null;
            }
            else
            if (Player.Card4 == null)
            {
                Card3.transform.position = Player.CardPose4.transform.position;
                Card3.transform.rotation = Player.CardPose4.transform.rotation;
                Card3.transform.parent = Player.CardPose4.transform;
                Slot3.Card = null;
                Player.Card4 = Card3;
                Card3 = null;
            }
            else
            if (Player.Card5 == null)
            {
                Card3.transform.position = Player.CardPose5.transform.position;
                Card3.transform.rotation = Player.CardPose5.transform.rotation;
                Card3.transform.parent = Player.CardPose5.transform;
                Slot3.Card = null;
                Player.Card5 = Card3;
                Card3 = null;
            }
            CheckHand(Player);
        }
    }

    public void Selected4(CardSlots Slot4)
    {
        if (Slot4.Selectable)
        {


            //if player card 1 empty
            if (Player.Card1 == null)
            {
                //Move card
                Card4.transform.position = Player.CardPose1.transform.position;
                Card4.transform.rotation = Player.CardPose1.transform.rotation;
                Card4.transform.parent = Player.CardPose1.transform;
                Slot4.Card = null;
                Player.Card1 = Card4;
                Card4 = null;
            }
            else
            if (Player.Card2 == null)
            {
                Card4.transform.position = Player.CardPose2.transform.position;
                Card4.transform.rotation = Player.CardPose2.transform.rotation;
                Card4.transform.parent = Player.CardPose2.transform;
                Slot4.Card = null;
                Player.Card2 = Card4;
                Card4 = null;
            }
            else
            if (Player.Card3 == null)
            {
                Card4.transform.position = Player.CardPose3.transform.position;
                Card4.transform.rotation = Player.CardPose3.transform.rotation;
                Card4.transform.parent = Player.CardPose3.transform;
                Slot4.Card = null;
                Player.Card3 = Card4;
                Card4 = null;
            }
            else
            if (Player.Card4 == null)
            {
                Card4.transform.position = Player.CardPose4.transform.position;
                Card4.transform.rotation = Player.CardPose4.transform.rotation;
                Card4.transform.parent = Player.CardPose4.transform;
                Slot4.Card = null;
                Player.Card4 = Card3;
                Card4 = null;
            }
            else
            if (Player.Card5 == null)
            {
                Card4.transform.position = Player.CardPose5.transform.position;
                Card4.transform.rotation = Player.CardPose5.transform.rotation;
                Card4.transform.parent = Player.CardPose5.transform;
                Slot4.Card = null;
                Player.Card5 = Card4;
                Card4 = null;
            }
            CheckHand(Player);
        }
    }

    public void Selected5( CardSlots Slot5)
    {
        if (Slot5.Selectable)
        {


            //if player card 1 empty
            if (Player.Card1 == null)
            {
                //Move card
                Card5.transform.position = Player.CardPose1.transform.position;
                Card5.transform.rotation = Player.CardPose1.transform.rotation;
                Card5.transform.parent = Player.CardPose1.transform;
                Slot5.Card = null;
                Player.Card1 = Card5;
                Card5 = null;
            }
            else
            if (Player.Card2 == null)
            {
                Card5.transform.position = Player.CardPose2.transform.position;
                Card5.transform.rotation = Player.CardPose2.transform.rotation;
                Card5.transform.parent = Player.CardPose2.transform;
                Slot5.Card = null;
                Player.Card2 = Card5;
                Card5 = null;
            }
            else
            if (Player.Card3 == null)
            {
                Card5.transform.position = Player.CardPose3.transform.position;
                Card5.transform.rotation = Player.CardPose3.transform.rotation;
                Card5.transform.parent = Player.CardPose3.transform;
                Slot5.Card = null;
                Player.Card3 = Card5;
                Card5 = null;
            }
            else
            if (Player.Card4 == null)
            {
                Card5.transform.position = Player.CardPose4.transform.position;
                Card5.transform.rotation = Player.CardPose4.transform.rotation;
                Card5.transform.parent = Player.CardPose4.transform;
                Slot5.Card = null;
                Player.Card4 = Card5;
                Card2 = null;
            }
            else
            if (Player.Card5 == null)
            {
                Card5.transform.position = Player.CardPose5.transform.position;
                Card5.transform.rotation = Player.CardPose5.transform.rotation;
                Card5.transform.parent = Player.CardPose5.transform;
                Slot5.Card = null;
                Player.Card5 = Card5;
                Card5 = null;
            }

            CheckHand(Player);
        }
    }

    void CheckHand(PlayerController ThePlayer)
    {
        if (ThePlayer.Card1 == null)
        {
            playerHandFull = false;
        }
        else
        if (ThePlayer.Card2 == null)
        {
            playerHandFull = false;
        }
        else
        if(ThePlayer.Card3 == null)
        {
            playerHandFull = false;
        }
        else
        if(ThePlayer.Card4 == null)
        {
            playerHandFull = false;
        }
        else
        if(ThePlayer.Card5 == null)
        {
            playerHandFull = false;
        }
        else
        {
            playerHandFull = true;
        }

        
    }

}
