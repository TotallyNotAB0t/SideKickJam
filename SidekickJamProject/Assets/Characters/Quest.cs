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
    
    [SerializeField] private TextAsset questJson;
    [CanBeNull] private JsonManager.questJson quest;
    
    private void Start()
    {
        //quest = JsonUtility.FromJson<JsonManager.questJson>(questJson.text);
    }

    public void Randomize(int rep)
    {
        initProba();
        bonusType = getQuestType();
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
    
    public string getQuestType()
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
    
    /*
     * this is ugly af
     */
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
}