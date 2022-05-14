using System;
using TMPro;
using UnityEngine;

public class GetHeroInformation : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI heroName, heroClass, heroHealth, heroSTR, heroINT, heroSPE;

    public void GetInfo(Hero hero)
    {
        heroName.SetText(hero.characterName);
        heroClass.SetText(hero.characterClass);
        heroHealth.SetText(hero.lives.ToString());
        heroSTR.SetText(hero.str.ToString());
        heroINT.SetText(hero.intel.ToString());
        heroSPE.SetText(hero.spe.ToString());
    }
}
