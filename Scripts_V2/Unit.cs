using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    //Stats
    public string thisUnitName;
    public string thisStatusEffect;
    public int thisUnitLevel;
    public int thisMaxHP;
    public int thisCurrentHP;
    public int thisArmorClass;
    public int thisMaxArmorClass;
    public int thisMaxAP;
    public int thisCurrentAP;

    public InputField aNewName = null;

    //Effects
    public bool Burned = false;
    public bool Stunned = false;
    public bool poisoned= false;
    public bool Confused= false;

   public void setStatus(string Stat)
   {
        thisStatusEffect = Stat;
   }

    public bool TakeDamage(int aDmg)
    {
        thisCurrentHP -= aDmg;

        if (thisCurrentHP <= 0)
        {
            thisCurrentHP = 0;
            return true;
            
        }
        else
        {
            return false;
        }
    }

    public void addMP(int MP)
    {
        thisCurrentAP += MP;
        if (thisCurrentAP >= thisMaxAP)
        {
            thisCurrentAP = thisMaxAP;
        }
    }

    public bool setAP(int AttackCOst)
    {
        thisCurrentAP -= AttackCOst;

        if (thisCurrentAP <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void onHeal(int aHealth)
    {
        thisCurrentHP += aHealth;

        if (thisCurrentHP > thisMaxHP)
        {
            thisCurrentHP = thisMaxHP;
        }
    }

    public void Defend( int aDefence)
    {
        thisArmorClass += aDefence;

        if (thisArmorClass > thisMaxArmorClass)
        {
            thisArmorClass = thisMaxArmorClass;
        }
    }

    public void ReduceDefent( int aDefence)
    {
        thisArmorClass -= aDefence;
        if(thisArmorClass < 0)
        {
            thisArmorClass = 0;
        }
    }


    public void onDeath()
    {
        if (thisCurrentHP <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void NewName()
    {

        thisUnitName = aNewName.text ;
    }
}
