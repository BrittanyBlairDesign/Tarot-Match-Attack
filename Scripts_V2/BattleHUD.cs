using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public Text thisNameText;
    public Text thisLevelText;
    //public Text thisEffectStatus;
    public Slider thisHPSlider;
    public Slider thisAPSlider;
    public Slider thisDPSlider;

    public void SetHUD(Unit aunit)
    {
        thisNameText.text = aunit.thisUnitName;
        thisLevelText.text = "Lvl " + aunit.thisUnitLevel;
        thisHPSlider.maxValue = aunit.thisMaxHP;
        thisHPSlider.value = aunit.thisCurrentHP;
        thisAPSlider.maxValue = aunit.thisMaxAP;
        thisAPSlider.value = aunit.thisCurrentAP;
        thisDPSlider.maxValue = aunit.thisMaxArmorClass;
        thisDPSlider.value = aunit.thisArmorClass;
        //thisEffectStatus.text = aunit.thisStatusEffect;
    }

    public void SetHP(int aHP)
    {
        thisHPSlider.value = aHP;
    }

    public void SetAP(int aAP)
    {
        thisAPSlider.value = aAP;
    }

    public void SetDP(int aDP)
    {
        thisDPSlider.value = aDP;
    }
}
