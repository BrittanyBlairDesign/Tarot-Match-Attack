using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableCards : MonoBehaviour
{
    //CardPrefab
    [SerializeField] private GameObject CardPrefab = null;
    public GameObject CurrentCard = null;
    //BattleState
    private GameObject BattleManager;
    private BattleSystem BattleSys;

    //Timer
    [SerializeField] private float ThisTimer = 0.0f;
    [SerializeField] private float thisDurration = 1.0f;
    private bool thisReset = false;

    //is card empty
    public bool Empty = false;

    //Clicked
    public bool Clicked = false;

    //what table slot is this 
    public bool table1 = false;
    public bool table2 = false;
    public bool table3 = false;
    public bool table4 = false;
    public bool table5 = false;
    public bool table6 = false;

    //can cards be selected?
    public bool CanSelectCards = false;

    //Zoom positions;
    public Vector3 StartPosition = Vector3.zero;
    public Vector3 ZoomPosition = Vector3.zero;

    //Poof Ojbect
    [SerializeField] private GameObject PoofPrefab = null;

    // Player
    Player thisPlayer = null;
    GameObject Player = null;
    public GameObject[] PlayerSlots = null;
    PlayerSlot Player1 = null;
    PlayerSlot Player2 = null;
    PlayerSlot Player3 = null;
    PlayerSlot Player4 = null;
    PlayerSlot Player5 = null;


    //enemy
    GameObject Enemy = null;
    public Enemy ThisEnemy = null;
    public GameObject[] enemySlots;
    EnemySlot Enemy1 = null;
    EnemySlot Enemy2 = null;
    EnemySlot Enemy3 = null;
    EnemySlot Enemy4 = null;
    EnemySlot Enemy5 = null;

    bool EnemyDraw = false;


    int FullSlots;

    private void Start()
    {
        Instantiate(CardPrefab, this.transform.position, this.transform.rotation, this.transform);
        BattleManager = GameObject.FindGameObjectWithTag("Manager");
        BattleSys = BattleManager.GetComponent<BattleSystem>();

        Player = GameObject.FindGameObjectWithTag("Player");
        thisPlayer = Player.GetComponent<Player>();

        ThisTimer = thisDurration;
        StartPosition = this.transform.position;
        ZoomPosition = this.transform.position;
        ZoomPosition.y = .2f;

        Player1 = PlayerSlots[0].GetComponent<PlayerSlot>();
        Player2 = PlayerSlots[1].GetComponent<PlayerSlot>();
        Player3 = PlayerSlots[2].GetComponent<PlayerSlot>();
        Player4 = PlayerSlots[3].GetComponent<PlayerSlot>();
        Player5 = PlayerSlots[4].GetComponent<PlayerSlot>();

        Enemy = GameObject.FindGameObjectWithTag("Enemy");
        ThisEnemy = Enemy.GetComponent<Enemy>();
        Enemy1 = enemySlots[0].GetComponent<EnemySlot>();
        Enemy2 = enemySlots[1].GetComponent<EnemySlot>();
        Enemy3 = enemySlots[2].GetComponent<EnemySlot>();
        Enemy4 = enemySlots[3].GetComponent<EnemySlot>();
        Enemy5 = enemySlots[4].GetComponent<EnemySlot>();
                  
    }

    private void Update()
    {

        // if its the enemy's turn to draw
        if (BattleSys.EnemyDraw)
        {
            EnemyDraw = true;
        }

        if (EnemyDraw)
        {
            //if this cardslot is filled
            if(CurrentCard != null)
            {
                
                //enemy will choose a random card
                StartCoroutine(EnemySelection());
                EnemyDraw = false;
            }

        }


        // if its the players turn to draw
        if (BattleSys.PlayerDraw)
        {
            CanSelectCards = true;

        }
        else
        {
            CanSelectCards = false;
        }

    }


    //put cards in players hand
    IEnumerator ChangePosition()
    {
        Clicked = false;

        if (Player1.Selected)
        {

            GameObject slot = PlayerSlots[0];
            CurrentCard.transform.position = slot.transform.position;
            CurrentCard.transform.rotation = slot.transform.rotation;
            CurrentCard.transform.parent = slot.transform;

            Player1.Selected = false;
            FullSlots++;
            CurrentCard = null;
        }
        else
        if (Player2.Selected)
        {
            GameObject slot = PlayerSlots[1];
            CurrentCard.transform.position = slot.transform.position;
            CurrentCard.transform.rotation = slot.transform.rotation;
            CurrentCard.transform.parent = slot.transform;

            Player2.Selected = false;
            FullSlots++;
            CurrentCard = null;
        }
        else
        if (Player3.Selected)
        {
            GameObject slot = PlayerSlots[2];
            CurrentCard.transform.position = slot.transform.position;
            CurrentCard.transform.rotation = slot.transform.rotation;
            CurrentCard.transform.parent = slot.transform;

            Player3.Selected = false;
            FullSlots++;
            CurrentCard = null;
        }
        else
        if (Player4.Selected)
        {
            GameObject slot = PlayerSlots[3];
            CurrentCard.transform.position = slot.transform.position;
            CurrentCard.transform.rotation = slot.transform.rotation;
            CurrentCard.transform.parent = slot.transform;

            Player4.Selected = false;
            FullSlots++;
            CurrentCard = null;
        }
        else
        {
            FullSlots++;
        }
        if (Player5.Selected)
        {
            GameObject slot = PlayerSlots[4];
            CurrentCard.transform.position = slot.transform.position;
            CurrentCard.transform.rotation = slot.transform.rotation;
            CurrentCard.transform.parent = slot.transform;

            Player5.Selected = false;
            FullSlots++;
            CurrentCard = null;
        }

        yield return new WaitForSeconds(2);

    }

    //fill cards in enemies hand
    IEnumerator EnemySelection()
    {

        int randomCard = BattleSys.Luck;

        if (randomCard == 1 && table1)
        {
            FillSlot1();
        }
        else
        if (randomCard == 2 && table2)
        {
            FillSlot1();
        }
        else
        if (randomCard == 3 && table3)
        {
            FillSlot1();
        }
        else
        if (randomCard == 4 && table4)
        {
            FillSlot1();
        }
        else
        if (randomCard == 5 && table5)
        {
            FillSlot1();
        }


        yield return new WaitForSeconds(2);
        if (CurrentCard == null)
        {
            ResetEnemy();
        }
 


    }

    private void FillSlot1()
    {
        if (Enemy1.selected)
        {
            CurrentCard.transform.position = enemySlots[0].transform.position;
            CurrentCard.transform.rotation = enemySlots[0].transform.rotation;
            CurrentCard.transform.parent = enemySlots[0].transform;

            Enemy1.selected = false;

            CurrentCard = null;

        }
        else
        if (Enemy2.selected)
        {
            CurrentCard.transform.position = enemySlots[1].transform.position;
            CurrentCard.transform.rotation = enemySlots[1].transform.rotation;
            CurrentCard.transform.parent = enemySlots[1].transform;

            Enemy2.selected = false;

            CurrentCard = null;

        }
        else
        if (Enemy3.selected)
        {
            CurrentCard.transform.position = enemySlots[2].transform.position;
            CurrentCard.transform.rotation = enemySlots[2].transform.rotation;
            CurrentCard.transform.parent = enemySlots[2].transform;

            Enemy3.selected = false;

            CurrentCard = null;

        }
        else
        if (Enemy4.selected)
        {
            CurrentCard.transform.position = enemySlots[3].transform.position;
            CurrentCard.transform.rotation = enemySlots[3].transform.rotation;
            CurrentCard.transform.parent = enemySlots[3].transform;

            Enemy4.selected = false;

            CurrentCard = null;

        }
        else
        if (Enemy5.selected)
        {
            CurrentCard.transform.position = enemySlots[4].transform.position;
            CurrentCard.transform.rotation = enemySlots[4].transform.rotation;
            CurrentCard.transform.parent = enemySlots[4].transform;

            Enemy5.selected = false;
            CurrentCard = null;

        }


    }


    private void OnTriggerEnter(Collider other)
    {
        GameObject otherObject = other.gameObject;

        Cards aCard;
        aCard = otherObject.GetComponent<Cards>();

        if (aCard != null)
        {
            CurrentCard = otherObject.gameObject;
            Empty = false;

        }
        else
        {
            Empty = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        GameObject otherObject = other.gameObject;

        Cards aCard;
        aCard = otherObject.GetComponent<Cards>();

        if (aCard != null)
        {
            Empty = true;

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject otherObject = collision.gameObject;

        Cards aCard;
        aCard = otherObject.GetComponent<Cards>();

        if (aCard != null)
        {
            CurrentCard = otherObject;

            Empty = false;
        }
        else
        {
            Empty = true;
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

    private void OnMouseDown()
    {
        // if the player clicks on a card it will  flip over, and change its position;
        ZoomIN();
        if (CurrentCard != null && CanSelectCards)
        {
            Vector3 Rotate = this.transform.eulerAngles;
            Rotate.z = 0;
            this.transform.eulerAngles = Rotate;

            StartCoroutine(ChangePosition());


        }
    }

    public void Respawan()
    {
        if (Empty && EnemyDraw)
        {
            ResetEnemy();
        }

        if(Empty && CanSelectCards)
        {
            ResetPlayer();
        }
    }

    public void ResetPlayer()
    {
        //Reset Rotation
        Vector3 rotation = this.transform.eulerAngles;
        rotation.z = 180;
        this.transform.eulerAngles = rotation;
        Instantiate(CardPrefab, this.transform.position, this.transform.rotation, this.transform);
    }

    public void ResetEnemy()
    {
        if (Empty)
        {
            Instantiate(CardPrefab, this.transform.position, this.transform.rotation, this.transform);
        }

        FullSlots = 0;
        EnemyDraw = false;
        BattleSys.EnemyTurn = false;
        BattleSys.EnemyDraw = false;
        ThisEnemy.FullHand();
    }
}
