using System;
using TMPro;
using UnityEngine;

public class GetHeroInformation : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI heroName, heroClass, heroHealth, heroSTR, heroINT, heroSPE;

    public void GetInfo(Hero hero)
    {
        heroName.SetText($"Name : {hero.characterName}");
        heroClass.SetText($"Class : {hero.characterClass}");
        heroHealth.SetText($"Health : {hero.lives}");
        heroSTR.SetText($"Strength : {hero.str}");
        heroINT.SetText($"Intelligence : {hero.intel}");
        heroSPE.SetText($"Speed : {hero.spe}");
    }
}
