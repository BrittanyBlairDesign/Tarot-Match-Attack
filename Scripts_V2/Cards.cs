using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cards : MonoBehaviour
{
    //BattleState
    private GameObject BattleManager;
    BattleState thisState;

    //MeshRenderer
    public MeshRenderer CardMeshRenderer = null;

    //Card number
    private int CardNumber = 0;

    //Card Stats
    public int CardDamage = 0;
    public int CardHeal = 0;
    public int CardMagic = 0;
    public int CardDefence = 0;
    public int CardEffectTime = 0;
    public int CardCost = 0;
    public string CardEffect = null;

    //Card Materials
    [SerializeField] private Material[] CardTypes = null;

    //Who Owns this Card??
    public bool PlayerCard = false;
    public bool EnemyCard = false;
    public bool TableTopCard = false;

    //start of the game
    private void Start()
    {

        BattleManager = GameObject.FindGameObjectWithTag("Manager");

        CardNumber = Random.Range(1, 22);

        if(CardNumber == 1)
        {
            //assign material
            CardMeshRenderer.material = CardTypes[0];
            //Assign Tag
            this.gameObject.tag = "Fool";
            //Set Stats
            CardCost = Random.Range(0, 10);
            CardDamage = Random.Range(0,25);
            CardHeal = Random.Range(0, 25);
            CardMagic = CardDamage;
            CardDefence = 0;
            CardEffect = null;
            CardEffectTime = 0;

        }
        else
        if(CardNumber == 2)
        {
            //assign material
            CardMeshRenderer.material = CardTypes[1];
            //Assign Tag
            this.gameObject.tag = "Emperor";
            //Set Stats
            CardCost = 10;
            CardDamage = 15;
            CardHeal = 0;
            CardMagic = 0;
            CardDefence = 0;
            CardEffect = null;
            CardEffectTime = 0;

        }
        else
        if (CardNumber == 3)
        {
            //assign material
            CardMeshRenderer.material = CardTypes[2];
            //Assign Tag
            this.gameObject.tag = "Strength";
            //Set Stats
            CardCost = 15;
            CardDamage = 30;
            CardHeal = 0;
            CardMagic = 0;
            CardDefence = 0;
            CardEffect = "Stun";
            CardEffectTime = 2;

        }
        else
        if (CardNumber == 4)
        {
            //assign material
            CardMeshRenderer.material = CardTypes[3];
            //Assign Tag
            this.gameObject.tag = "Hanged";
            //Set Stats
            CardCost = 5;
            CardDamage = 25;
            CardHeal = 0;
            CardMagic = 0;
            CardDefence = 0;
            CardEffect = null;
            CardEffectTime = 0;

        }
        else
        if (CardNumber == 5)
        {
            //assign material
            CardMeshRenderer.material = CardTypes[4];
            //Assign Tag
            this.gameObject.tag = "Tower";
            //Set Stats
            CardCost = 10;
            CardDamage = 20;
            CardHeal = 0;
            CardMagic = 0;
            CardDefence = 0;
            CardEffect = null;
            CardEffectTime = 0;
        }
        else
        if (CardNumber == 6)
        {
            //assign material
            CardMeshRenderer.material = CardTypes[5];
            //Assign Tag
            this.gameObject.tag = "Judgement";
            //Set Stats
            CardCost = 5;
            CardDamage = 25;
            CardHeal = 0;
            CardMagic = 0;
            CardDefence = 0;
            CardEffect = null;
            CardEffectTime = 0;
        }
        else
        if (CardNumber == 7)
        {
            //assign material
            CardMeshRenderer.material = CardTypes[6];
            //Assign Tag
            this.gameObject.tag = "Magician";
            //Set Stats
            CardCost = 10;
            CardDamage = 6;
            CardHeal = 0;
            CardMagic = 0;
            CardDefence = 0;
            CardEffect = "Bleed";
            CardEffectTime = 3;
        }
        else
        if (CardNumber == 8)
        {
            //assign material
            CardMeshRenderer.material = CardTypes[7];
            //Assign Tag
            this.gameObject.tag = "Heirophant";
            //Set Stats
            CardCost = 5;
            CardDamage = 0;
            CardHeal = 10;
            CardMagic = 10;
            CardDefence = 10;
            CardEffect = null;
            CardEffectTime = 0;
        }
        else
        if (CardNumber == 9)
        {
            //assign material
            CardMeshRenderer.material = CardTypes[8];
            //Assign Tag
            this.gameObject.tag = "Hermit";
            //Set Stats
            CardCost = 0;
            CardDamage = 0;
            CardHeal = 15;
            CardMagic = 10;
            CardDefence = 15;
            CardEffect = null;
            CardEffectTime = 0;
        }
        else
        if (CardNumber == 10)
        {
            //assign material
            CardMeshRenderer.material = CardTypes[9];
            //Assign Tag
            this.gameObject.tag = "Death";
            //Set Stats
            CardCost = 10;
            CardDamage = 30;
            CardHeal = 0;
            CardMagic = 0;
            CardDefence = 0;
            CardEffect = null;
            CardEffectTime = 0;
        }
        else
        if (CardNumber == 11)
        {
            //assign material
            CardMeshRenderer.material = CardTypes[10];
            //Assign Tag
            this.gameObject.tag = "Star";
            //Set Stats
            CardCost = 10;
            CardDamage = 15;
            CardHeal = 0;
            CardMagic = 10;
            CardDefence = 5;
            CardEffect = null;
            CardEffectTime = 0;
        }
        else
        if (CardNumber == 12)
        {
            //assign material
            CardMeshRenderer.material = CardTypes[11];
            //Assign Tag
            this.gameObject.tag = "World";
            //Set Stats
            CardCost = 0;
            CardDamage = 0;
            CardHeal = 10;
            CardMagic = 10;
            CardDefence = 10;
            CardEffect = null;
            CardEffectTime = 0;
        }
        else
        if (CardNumber == 13)
        {
            //assign material
            CardMeshRenderer.material = CardTypes[12];
            //Assign Tag
            this.gameObject.tag = "Priestess";
            //Set Stats
            CardCost = 10;
            CardDamage = 25;
            CardHeal = 10;
            CardMagic = 0;
            CardDefence = 10;
            CardEffect = null;
            CardEffectTime = 0;
        }
        else
        if (CardNumber == 14)
        {
            //assign material
            CardMeshRenderer.material = CardTypes[13];
            //Assign Tag
            this.gameObject.tag = "Lovers";
            //Set Stats
            CardCost = 20;
            CardDamage = 0;
            CardHeal = 25;
            CardMagic = 25;
            CardDefence = 10;
            CardEffect = null;
            CardEffectTime = 0;
        }
        else
        if (CardNumber == 15)
        {
            //assign material
            CardMeshRenderer.material = CardTypes[14];
            //Assign Tag
            this.gameObject.tag = "Fortune";
            //Set Stats
            CardCost = Random.Range(0, 10);
            CardDamage = CardCost *2;
            CardHeal = 0;
            CardMagic = 0;
            CardDefence = 0;
            CardEffect = null;
            CardEffectTime = 0;
        }
        else
        if (CardNumber == 16)
        {
            //assign material
            CardMeshRenderer.material = CardTypes[15];
            //Assign Tag
            this.gameObject.tag = "Temperance";
            //Set Stats
            CardCost = 5;
            CardDamage = 10;
            CardHeal = 0;
            CardMagic = 10;
            CardDefence = 15;
            CardEffect = null;
            CardEffectTime = 0;
        }
        else
        if (CardNumber == 17)
        {
            //assign material
            CardMeshRenderer.material = CardTypes[16];
            //Assign Tag
            this.gameObject.tag = "Moon";
            //Set Stats
            CardCost = 20;
            CardDamage = 25;
            CardHeal = 0;
            CardMagic = CardDamage;
            CardDefence = 0;
            CardEffect = null;
            CardEffectTime = 0;
        }
        else
        if (CardNumber == 18)
        {
            //assign material
            CardMeshRenderer.material = CardTypes[17];
            //Assign Tag
            this.gameObject.tag = "Empress";
            //Set Stats
            CardCost = 15;
            CardDamage = 30;
            CardHeal = 0;
            CardMagic = 0;
            CardDefence = 0;
            CardEffect = null;
            CardEffectTime = 0;
        }
        else
        if (CardNumber == 19)
        {
            //assign material
            CardMeshRenderer.material = CardTypes[18];
            //Assign Tag
            this.gameObject.tag = "Chariot";
            //Set Stats
            CardCost = 20;
            CardDamage = 20;
            CardHeal = 0;
            CardMagic = 0;
            CardDefence = 10;
            CardEffect = null;
            CardEffectTime = 0;
        }
        else
        if (CardNumber == 20)
        {
            //assign material
            CardMeshRenderer.material = CardTypes[19];
            //Assign Tag
            this.gameObject.tag = "Justice";
            //Set Stats
            CardCost = 10;
            CardDamage = 10;
            CardHeal = 10;
            CardMagic = 10;
            CardDefence = 10;
            CardEffect = null;
            CardEffectTime = 0;
        }
        else
        if (CardNumber == 21)
        {
            //assign material
            CardMeshRenderer.material = CardTypes[20];
            //Assign Tag
            this.gameObject.tag = "Devil";
            //Set Stats
            CardCost = 30;
            CardDamage = 40;
            CardHeal = 0;
            CardMagic = 0;
            CardDefence = -15;
            CardEffect = null;
            CardEffectTime = 0;
        }
        else
        if (CardNumber == 22)
        {
            //assign material
            CardMeshRenderer.material = CardTypes[21];
            //Assign Tag
            this.gameObject.tag = "Sun";
            //Set Stats
            CardCost = 10;
            CardDamage = 15;
            CardHeal = 5;
            CardMagic = 10;
            CardDefence = 5;
            CardEffect = null;
            CardEffectTime = 0;
        }

    }

    
}
