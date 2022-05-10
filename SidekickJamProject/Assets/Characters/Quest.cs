using System;
using System.Collections.Generic;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using Random = UnityEngine.Random;

public class Quest : MonoBehaviour
{
    public int bonus,malus, duration;
    public string bonusType, malusType;
    public bool active = true;
    public string questName;
    public List<Hero> heroes = new();

    public void Randomize(int rep)
    {
        bonusType = getQuestType();
        
        // TODO C'EST DEGUEULASSE, A OPTI QUAND J'AI PAS LE CERVEAU EN COMPOTE
        malusType = getQuestType();
        while (malusType == bonusType)
        {
            malusType = getQuestType();
        }
        
        bonus = Random.Range(0, 4);
        malus = Random.Range(0, 3);
        duration = Random.Range(0,3);
        
        //En fonction de la reputation et du bonusType, la base de textes est pas la meme
        questName = "Yeet the dragon";
    }
    
    // TODO A GRANDEMENT AMELIORER
    public static string getQuestType()
    {
        switch (Random.Range(0, 9))
        {
            case 0:
            case 1:
            case 2:
                return "food";
            case 3:
            case 4:
            case 5:
                return "money";
            case 6:
            case 7:
            case 8:
                return "looks";
            case 9:
                return "reputation";
        }

        return "";
    }
}
