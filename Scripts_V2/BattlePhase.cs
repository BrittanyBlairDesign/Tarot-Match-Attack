using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Battle { START, PLAYERTURN, PLAYERDRAW, ENEMYTURN, ENEMYDRAW, WIN, LOSE }

public class BattlePhase : MonoBehaviour
{

    //Battle Phase
    public Battle GameState;

    // How long to wait for 
    float Wait = 2.0f;
    float timer;

    //Player Information
    [SerializeField] public PlayerController Player = null;
    [SerializeField] public Unit PlayerUnit = null;
    [SerializeField] public BattleHUD PlayerHUD = null;
    [SerializeField] public Image PlayerStats = null;
    public int PlayerEffectDamage = 0;
    public int PlayerEffectturns = 0;
    public int SkipPlayerTurns = 0;

    //Enemy Information
    [SerializeField] public EnemyController Enemy = null;
    [SerializeField] public Unit EnemyUnit = null;
    [SerializeField] public BattleHUD EnemyHUD = null;
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

    //camera script
    [SerializeField] CameraShake thisCamera;

    //Durring game
    [SerializeField] public Image TurnResult;
    [SerializeField] public Text Event;
    [SerializeField] public Text PName;
    [SerializeField] public Text PHP;
    [SerializeField] public Text PMP;
    [SerializeField] public Text PDP;

    [SerializeField] public Text eName;
    [SerializeField] public Text eHP;
    [SerializeField] public Text eMP;
    [SerializeField] public Text eDP;

    [SerializeField] public Button PDraw;
    [SerializeField] public Button EDraw;


    //SPells
    [SerializeField] GameObject PlayerSpell;
    [SerializeField] GameObject EnemySpell;


    // Start is called before the first frame update
    void Start()
    {
        timer = Wait;
        GameState = Battle.START;
        StartCoroutine(SetUP());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator SetUP()
    {
        //Set up player 
        PlayerHUD.SetHUD(PlayerUnit);

        //Set Up Enemy
        EnemyHUD.SetHUD(EnemyUnit);

        print("setupgame");

        yield return new WaitForSeconds(.1f);
        StartupUI.gameObject.SetActive(true);
        Intro();
        
        GameState = Battle.START;
        
    }

    public void Intro()
    {
        string Text = "Mage " + EnemyUnit.thisUnitName + " Has Challanged you to a battle, with no intention of letting you escape.";

        Introduction.text = Text;
        GameState = Battle.START;
    }

    public void EnterName()
    {
        string Text = "Before you begin your battle, you must state your name.";

        Introduction.text = Text;
        GameState = Battle.START;
    }


    // PLAYER

    public void PlayerTurn()
    {
        

        if(PlayerUnit.thisCurrentHP > 0)
        {
            GameState = Battle.PLAYERTURN;
        }
        else
        {
            LostGame();
        }
    }

    public IEnumerator PlayerAttack(Cards AttackCard)
    {
        // Card Damage

        int Damage = AttackCard.CardDamage;

        int Cost = AttackCard.CardCost;

        int Heal = AttackCard.CardHeal;

        int Magic = AttackCard.CardMagic;

        int Defence = AttackCard.CardDefence;

        if(Player.CardsSelected == 1 || EnemyUnit.thisArmorClass > 70)
        {
            //enemy damage
            EnemyUnit.ReduceDefent(Damage);
            EnemyUnit.TakeDamage(Damage);
            EnemyHUD.SetHP(EnemyUnit.thisCurrentHP);


            PlayerUnit.setAP(Cost);
            PlayerUnit.addMP(Magic);
            PlayerHUD.SetAP(PlayerUnit.thisCurrentAP);

            PlayerUnit.onHeal(Heal);
            PlayerHUD.SetHP(PlayerUnit.thisCurrentHP);


            PlayerUnit.Defend(Defence);
            PlayerHUD.SetDP(PlayerUnit.thisArmorClass);
        }
        else
        if(Player.CardsSelected == 2 || EnemyUnit.thisArmorClass > 50)
        {
            EnemyUnit.ReduceDefent(Damage);
            Damage = Damage + Damage;
            EnemyUnit.TakeDamage(Damage);
            EnemyHUD.SetHP(EnemyUnit.thisCurrentHP);

            PlayerUnit.setAP(Cost);
            PlayerUnit.addMP(Magic);
            PlayerHUD.SetAP(PlayerUnit.thisCurrentAP);

            PlayerUnit.onHeal(Heal);
            PlayerHUD.SetHP(PlayerUnit.thisCurrentHP);


            PlayerUnit.Defend(Defence);
            PlayerHUD.SetDP(PlayerUnit.thisArmorClass);
        }
        else
        if(Player.CardsSelected == 3)
        {
            EnemyUnit.ReduceDefent(Damage);
            EnemyHUD.SetDP(EnemyUnit.thisArmorClass);
            Damage = Damage * 3;
            EnemyUnit.TakeDamage(Damage);
            EnemyHUD.SetHP(EnemyUnit.thisCurrentHP);

            PlayerUnit.setAP(Cost);
            PlayerUnit.addMP(Magic);
            PlayerHUD.SetAP(PlayerUnit.thisCurrentAP);

            PlayerUnit.onHeal(Heal);
            PlayerHUD.SetHP(PlayerUnit.thisCurrentHP);

            PlayerUnit.Defend(Defence);
            PlayerHUD.SetDP(PlayerUnit.thisArmorClass);
        }


        print("Damage Issued");
        PlayerSpell.SetActive(true);

        yield return new WaitForSeconds(Wait);

        TurnResult.gameObject.SetActive(true);
        PDraw.gameObject.SetActive(true);

        string Playerevent;

        Playerevent = "You played the " + AttackCard.tag + " card. Your opponent " + EnemyUnit.thisUnitName + " takes " + Damage + " Damage.";

        Event.text = Playerevent;
        PName.text = PlayerUnit.thisUnitName;
        PHP.text = "HP:" +  PlayerUnit.thisCurrentHP;
        PMP.text = "MP:" + PlayerUnit.thisCurrentAP ;
        PDP.text = "DP:" + PlayerUnit.thisArmorClass;

        eName.text = EnemyUnit.thisUnitName;
        eHP.text = "HP:" + EnemyUnit.thisCurrentHP;
        eMP.text = "MP:" + EnemyUnit.thisCurrentAP;
        eDP.text = "DP:" + EnemyUnit.thisArmorClass;


    }

    public void PlayerDrawCard()
    {
        GameState = Battle.PLAYERDRAW;

        PlayerSpell.SetActive(false);
    }

    public void EnemyTurn()
    {
        if(EnemyUnit.thisCurrentHP > 1)
        {
            GameState = Battle.ENEMYTURN;
        }
        else
        {
            WinGame();
        }
        
    }

    public IEnumerator EnemyAttack(Cards AttackCard)
    {
        // Card Damage

        int Damage = AttackCard.CardDamage;

        int Cost = AttackCard.CardCost;

        int Heal = AttackCard.CardHeal;

        int Magic = AttackCard.CardMagic;

        int Defence = AttackCard.CardDefence;

        if (Enemy.CardsSelected == 1 || PlayerUnit.thisArmorClass > 70)
        {
            //enemy damage
            PlayerUnit.ReduceDefent(Damage);
            PlayerHUD.SetDP(PlayerUnit.thisArmorClass);
            PlayerUnit.TakeDamage(Damage);
            PlayerHUD.SetHP(PlayerUnit.thisCurrentHP);


            EnemyUnit.setAP(Cost);
            EnemyUnit.addMP(Magic);
            EnemyHUD.SetAP(EnemyUnit.thisCurrentAP);

            EnemyUnit.onHeal(Heal);
            EnemyHUD.SetHP(EnemyUnit.thisCurrentHP);


            EnemyUnit.Defend(Defence);
            EnemyHUD.SetDP(EnemyUnit.thisArmorClass);
        }
        else
        if (Enemy.CardsSelected == 2 || PlayerUnit.thisArmorClass > 40)
        {
            PlayerUnit.ReduceDefent(Damage);
            PlayerHUD.SetDP(PlayerUnit.thisArmorClass);
            Damage = Damage + Damage;
            PlayerUnit.TakeDamage(Damage);
            PlayerHUD.SetHP(PlayerUnit.thisCurrentHP);

            EnemyUnit.setAP(Cost);
            EnemyUnit.addMP(Magic);
            EnemyHUD.SetAP(EnemyUnit.thisCurrentAP);

            EnemyUnit.onHeal(Heal);
            EnemyHUD.SetHP(EnemyUnit.thisCurrentHP);


            EnemyUnit.Defend(Defence);
            EnemyHUD.SetDP(EnemyUnit.thisArmorClass);
        }
        if (Enemy.CardsSelected == 3)
        {
            PlayerUnit.ReduceDefent(Damage);
            PlayerHUD.SetDP(PlayerUnit.thisArmorClass);
            Damage = Damage * 3;
            PlayerUnit.TakeDamage(Damage);
            PlayerHUD.SetHP(PlayerUnit.thisCurrentHP);

            EnemyUnit.setAP(Cost);
            EnemyUnit.addMP(Magic);
            EnemyHUD.SetAP(EnemyUnit.thisCurrentAP);

            EnemyUnit.onHeal(Heal);
            EnemyHUD.SetHP(EnemyUnit.thisCurrentHP);

            EnemyUnit.Defend(Defence);
            EnemyHUD.SetDP(EnemyUnit.thisArmorClass);
        }


        print("Damage Issued");

        EnemySpell.SetActive(true);

        StartCoroutine(thisCamera.Shake(Wait, .05f));

        yield return new WaitForSeconds(Wait);


        TurnResult.gameObject.SetActive(true);
        EDraw.gameObject.SetActive(true);

        string EnemyEvent;
        EnemyEvent = EnemyUnit.thisUnitName +" played the " + AttackCard.tag + " card. You take " + Damage + " Damage.";

        Event.text = EnemyEvent;

        PName.text = PlayerUnit.thisUnitName;
        PHP.text = "HP:" + PlayerUnit.thisCurrentHP;
        PMP.text = "MP:" + PlayerUnit.thisCurrentAP;
        PDP.text = "DP:" + PlayerUnit.thisArmorClass;

        eName.text = EnemyUnit.thisUnitName;
        eHP.text = "HP:" + EnemyUnit.thisCurrentHP;
        eMP.text = "MP:" + EnemyUnit.thisCurrentAP;
        eDP.text = "DP:" + EnemyUnit.thisArmorClass;

    }

    public void EnemyDraw()
    {
        GameState = Battle.ENEMYDRAW;

        EnemySpell.SetActive(false);
    }

    public void LostGame()
    {
        GameState = Battle.LOSE;

        TurnResult.gameObject.SetActive(true);
        string OhNO;
        OhNO = "Oh man, " + EnemyUnit.thisUnitName + " defeated you. Better luck next time Mage.";

        Event.text = OhNO;
    }

    public void WinGame()
    {
        GameState = Battle.WIN;
        TurnResult.gameObject.SetActive(true);
        string Congrads;
        Congrads = "A Celebration is in order! " + PlayerUnit.thisUnitName + ", you have won your first battle!";

        Event.text = Congrads;
    }
}
