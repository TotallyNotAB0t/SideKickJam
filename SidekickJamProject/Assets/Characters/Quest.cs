using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class Quest : MonoBehaviour
{
    public int bonus,malus, duration;
    public string bonusType, malusType;
    public bool active = true;
    public string questName;
    public List<Hero> heroes = new();
    
    private List<string> proba = new();
    
    public static questJson questsNames;

    public int threshold;
    public string thresholdStat;

    public void Randomize(int rep)
    {
        initProba();
        bonusType = getQuestType();
        malusType = getQuestType();
        while (malusType == bonusType)
        {
            malusType = getQuestType();
        }
        
        bonus = Random.Range(1, 5);
        malus = Random.Range(1, 4);
        duration = Random.Range(1,4);
        
        setQuestName();
    }

    public void lastQuest()
    {
        bonusType = "reputation";
        malusType = "money";

        bonus = 3;
        malus = 3;
        duration = 5;

        questName = "Save the world";
        threshold = 70;
    }
    
    private void setQuestName()
    {
        var rep = GameBehaviour.Reputation;
        if (rep <= 15) // EARLY
        {
            switch (bonusType)
            {
                case "food":
                    questName = questsNames.earlyfood[Random.Range(0, questsNames.earlyfood.Length)];
                    break;
                case "money":
                    questName = questsNames.earlymoney[Random.Range(0, questsNames.earlymoney.Length)];
                    break;
                case "looks":
                    questName = questsNames.earlylooks[Random.Range(0, questsNames.earlylooks.Length)];
                    break;
                case "reputation":
                    questName = questsNames.earlyreputation[Random.Range(0, questsNames.earlyreputation.Length)];
                    break;
            }

            var tmp = new List<string> {"str", "intel", "speed"};
            thresholdStat = tmp[Random.Range(0, tmp.Count)];
            threshold = Random.Range(0,rep);
        }
        else if (rep <= 30) //MID
        {
            switch (bonusType)
            {
                case "food":
                    questName = questsNames.midfood[Random.Range(0, questsNames.midfood.Length)];
                    break;
                case "money":
                    questName = questsNames.midmoney[Random.Range(0, questsNames.midmoney.Length)];
                    break;
                case "looks":
                    questName = questsNames.midlooks[Random.Range(0, questsNames.midlooks.Length)];
                    break;
                case "reputation":
                    questName = questsNames.midreputation[Random.Range(0, questsNames.midreputation.Length)];
                    break;
            }
        }
        else if (rep <= 55) //LATE
        {
            switch (bonusType)
            {
                case "food":
                    questName = questsNames.latefood[Random.Range(0, questsNames.latefood.Length)];
                    break;
                case "money":
                    questName = questsNames.latemoney[Random.Range(0, questsNames.latemoney.Length)];
                    break;
                case "looks":
                    questName = questsNames.latelooks[Random.Range(0, questsNames.latelooks.Length)];
                    break;
                case "reputation":
                    questName = questsNames.latereputation[Random.Range(0, questsNames.latereputation.Length)];
                    break;
            }
        }
    }
    
    private string getQuestType()
    {
        if (bonusType != null)
        {
            proba.RemoveAll(alreadyBonus);
        }
        return proba[Random.Range(0, proba.Count - 1)];
    }

    private bool alreadyBonus(String s)
    {
        return s.EndsWith(bonusType);
    }
    
    private void initProba()
    {
        proba.Add("food");
        proba.Add("food");
        proba.Add("food");
        proba.Add("money");
        proba.Add("money");
        proba.Add("money");
        proba.Add("looks");
        proba.Add("looks");
        proba.Add("looks");
        proba.Add("reputation");
    }
    
    [Serializable]
    public class questJson
     {
         public string[] earlyfood;
         public string[] earlymoney;
         public string[] earlylooks;
         public string[] earlyreputation;
         
         public string[] midfood;
         public string[] midmoney;
         public string[] midlooks;
         public string[] midreputation;
         
         public string[] latefood;
         public string[] latemoney;
         public string[] latelooks;
         public string[] latereputation;
     }
}


