using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, PLAYERDRAW, ENEMYTURN, ENEMYDRAW, WIN, LOSE}

public class BattleSystem : MonoBehaviour
{
    //BATTLE STATE
    public BattleState thisState;

    //HOW LONG TO WAIT
    public float Wait = 1.0f;

    //Player Information
    public GameObject thisPlayer = null;
    public Player Player = null;
    public Unit PlayerUnit = null;
    public BattleHUD PlayerHUD = null;
    public Image PlayerStats = null;
    public int PlayerEffectDamage = 0;
    public int PlayerEffectturns = 0;
    public int SkipPlayerTurns = 0;

    //Enemy Information
    public GameObject thisEnemy = null;
    public Enemy Enemy= null;
    public Unit EnemyUnit = null;
    public BattleHUD EnemyHUD = null;
    public Image EnemyStats = null;
    public int EnemyEffectDamage = 0;
    public int EnemyEffectTurns = 0;
    public int SkipEnemyTurns = 0;
    public int Luck = 0;
    public int RandomNumber(int range)
    {
        int Luck = Random.Range(1, range);
        return Luck;
    }

    //Intro
    public Text Introduction;
    public Image StartupUI;

    //PlayerUI
    public Button PlayerAttackButton = null;
    public Button PlayerFullHand = null;


    // What State are we Currently in??
    public bool GameStart       =false;
    public bool PlayerSelect    =false;
    public bool PlayerAttacking =false;
    public bool PlayerDraw      =false;
    public bool EnemyTurn       =false;
    public bool EnemyAttack     =false;
    public bool EnemyDraw       =false;
    public bool Win             =false;
    public bool Loose           =false;


    // Start is called before the first frame update
    void Start()
    {

        thisState = BattleState.START;
        StartCoroutine(SetUpBattle());

        Color aColor;
        aColor = PlayerStats.color;
        aColor.a = 217;

        PlayerStats.color = aColor;

        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerAttacking)
        {
            StartCoroutine(PlayerAttack());
        }

        if (EnemyTurn && EnemyAttack)
        {
            StartCoroutine(EnemyAttacking());
        }

        if (PlayerSelect)
        {
            PlayerAttackButton.gameObject.SetActive(true);
            EnemyDraw = false;
        }
    }

    public IEnumerator SetUpBattle()
    {
        //Set up player 
        thisPlayer = GameObject.FindGameObjectWithTag("Player");
        PlayerUnit = thisPlayer.GetComponent<Unit>();
        PlayerHUD = thisPlayer.GetComponent<BattleHUD>();
        Player = thisPlayer.GetComponent<Player>();
        PlayerHUD.SetHUD(PlayerUnit);

        //Set Up Enemy
        thisEnemy = GameObject.FindGameObjectWithTag("Enemy");
        EnemyUnit = thisEnemy.GetComponent<Unit>();
        EnemyHUD = thisEnemy.GetComponent<BattleHUD>();
        Enemy = thisEnemy.GetComponent<Enemy>();
        EnemyHUD.SetHUD(EnemyUnit);


        yield return new WaitForSeconds(.1f);
        StartupUI.gameObject.SetActive(true);
        Intro();
    }

    public void Intro()
    {
        string Text = "Mage " + EnemyUnit.thisUnitName + " Has Challanged you to a battle, with no intention of letting you escape.";

        Introduction.text = Text;

    }

    public void EnterName()
    {
        string Text = "Before you begin your battle, you must state your name.";

        Introduction.text = Text;
    }

    public void PlayerTurn()
    {
        EnemyDraw = false;
        thisState = BattleState.PLAYERTURN;
        Color aColor;
        aColor = PlayerStats.color;
        aColor.a = 245;

        PlayerStats.color = aColor;

        if (PlayerEffectturns > 0)
        {
        
            if (PlayerUnit.Burned)
            {
                PlayerUnit.TakeDamage(PlayerEffectDamage);
                PlayerEffectturns--;

                if(PlayerUnit.thisCurrentHP > 0)
                {
                    PlayerSelect = true;
                }
            }
            else
            if (PlayerUnit.poisoned)
            {
                PlayerUnit.TakeDamage(PlayerEffectDamage);
                PlayerEffectturns--;

                if (PlayerUnit.thisCurrentHP > 0)
                {
                    PlayerSelect = true;
                }
            }
            else
            if (PlayerUnit.Stunned)
            {
                PlayerEffectturns--;
                PlayerTurnSkipped();
            }
            else
            if (PlayerUnit.Confused)
            {
                PlayerEffectturns--;
            }

        }

        PlayerSelect = true;


    }

    public void PlayerTurnSkipped()
    {
        Enemyturn();
    }

    public IEnumerator PlayerAttack()
    {
        PlayerSelect = false;

        //get card
        Cards attackCard = Player.CardStats;

        //get the damage 
        int Damage = attackCard.CardDamage;
        Damage = Damage * Player.CardsSelected;

        // Card cost
        int Cost = attackCard.CardCost;
        Cost = Cost * Player.CardsSelected;
        Cost = Cost / 2;

        //Card Heal
        int Heal = attackCard.CardHeal;
        Heal = Heal * Player.CardsSelected;

        //card Magic
        int Magic = attackCard.CardMagic;
        Magic = Magic * Player.CardsSelected;

        //card Defence
        int Defence = attackCard.CardDefence;
        Defence = Defence * Player.CardsSelected;

       // if (attackCard.CardEffect != null)
       // {
       //     int EffectTime = attackCard.CardEffectTime;
       //     EnemyEffectTurns = EffectTime;
       //
       //     EnemyEffectDamage = Damage / 2;
       //
       //     string EffectName = attackCard.CardEffect;
       //     EnemyUnit.setStatus(EffectName);
       //
       // }

        if (PlayerUnit.thisArmorClass < EnemyUnit.thisArmorClass)
        {
            int luck = Random.Range(1, 5);
            if (luck == 1)
            {
                Damage = Damage / 4;
            }
            else
            if (luck == 2)
            {
                Damage = Damage / 2;
            }
            else
            if (luck == 3)
            {
                Damage = Damage / 1;
            }
            else
            if (luck == 4)
            {
                Damage = 0;
            }
        }

        // deal damage 
        EnemyUnit.TakeDamage(Damage);
        EnemyHUD.SetHP(EnemyUnit.thisCurrentHP);

        // take cost from player
        PlayerUnit.setAP(Cost);
        PlayerUnit.addMP(Magic);
        PlayerHUD.SetAP(PlayerUnit.thisCurrentAP);

        PlayerUnit.onHeal(Heal);
        PlayerHUD.SetHP(PlayerUnit.thisCurrentHP);


        PlayerUnit.Defend(Defence);
        PlayerHUD.SetDP(PlayerUnit.thisArmorClass);

        print("Damage Issued");
        yield return new WaitForSeconds(Wait);
        PlayerAttacking = false;
        Player.EraseCards();
        

    }

    public void PlayerDrawCard()
    {
        thisState = BattleState.PLAYERDRAW;
        
        
    }

    public void Enemyturn()
    {
        PlayerDraw = false;
        thisState = BattleState.ENEMYTURN;
        EnemyTurn = true;
        Color aColor;
        aColor = EnemyStats.color;
        aColor.a = 245;

        EnemyStats.color = aColor;
        if (EnemyEffectTurns > 0)
        {

            if (EnemyUnit.Burned)
            {
                EnemyUnit.TakeDamage(EnemyEffectDamage);
                EnemyEffectTurns--;

                if (EnemyUnit.thisCurrentHP > 0)
                {

                }
            }
            else
            if (EnemyUnit.poisoned)
            {
                EnemyUnit.TakeDamage(EnemyEffectDamage);
                EnemyEffectTurns--;

                if (EnemyUnit.thisCurrentHP > 0)
                {
   
                }
            }
            else
            if (EnemyUnit.Stunned)
            {
                EnemyEffectTurns--;
                EnemyTurnSkip();
            }
            else
            if (PlayerUnit.Confused)
            {
                EnemyEffectTurns--;
            }

        }

    }

    public void EnemyTurnSkip()
    {
        thisState = BattleState.PLAYERTURN;
    }

    public IEnumerator EnemyAttacking()
    {

        Cards attackCard = Enemy.CardStats;

        //get the damage 
        int Damage = attackCard.CardDamage;
        Damage = Damage * Enemy.CardsSelected;

        // Card cost
        int Cost = attackCard.CardCost;
        Cost = Enemy.CardsSelected;

        //Card Heal
        int Heal = attackCard.CardHeal;
        Heal = Heal * Enemy.CardsSelected;

        //card Magic
        int Magic = attackCard.CardMagic;
        Magic = Magic * Enemy.CardsSelected;

        //card Defence
        int Defence = attackCard.CardDefence;
        Defence = Defence * Enemy.CardsSelected;

        //if (attackCard.CardEffect != null)
        //{
        //    int EffectTime = attackCard.CardEffectTime;
        //    PlayerEffectturns = EffectTime;
        //
        //    PlayerEffectDamage = Damage / 2;
        //
        //    string EffectName = attackCard.CardEffect;
        //    PlayerUnit.setStatus(EffectName);
        //    
        //}

        yield return new WaitForSeconds(Wait);

        if(PlayerUnit.thisArmorClass > EnemyUnit.thisArmorClass)
        {
            int luck = Random.Range(1, 5);
            if(luck == 1)
            {
                Damage = Damage / 4;
            }
            else
            if(luck == 2)
            {
                Damage = Damage / 2;
            }
            else
            if (luck == 3)
            {
                Damage = Damage / 1;
            }
            else
            if (luck == 4)
            {
                Damage = 0;
            }
        }


        PlayerUnit.TakeDamage(Damage);
        PlayerHUD.SetHP(PlayerUnit.thisCurrentHP);

        EnemyUnit.setAP(Cost);    
        EnemyUnit.onHeal(Heal);
        EnemyUnit.addMP(Magic);
        EnemyUnit.Defend(Defence);

        EnemyHUD.SetAP(EnemyUnit.thisCurrentAP);
        EnemyHUD.SetHP(EnemyUnit.thisCurrentHP);
        EnemyHUD.SetDP(EnemyUnit.thisArmorClass);

        yield return new WaitForSeconds(Wait);
        EnemyAttack = false;

        Enemy.EraseCards();

        yield return new WaitForSeconds(1);
        EnemyAttack = false;

        Luck = RandomNumber(6);

        EnemyDraw = true;

    }
}
