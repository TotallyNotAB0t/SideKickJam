using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using Unity.Collections;
using UnityEditor;
using UnityEngine;

public class GameBehaviour : MonoBehaviour
{
    public static int maxHero;
    private static Camera camCounter;
    private static int food, money, looks, reputation = 1, days;
    public static int Food
    {
        get { return food; }
        set
        {
            food = value;
        }
    }
    public static int Money
    {
        get
        {
            return money;
        }
        set
        {
            money = value;
        }
    }
    public static int Looks
    {
        get
        {
            return looks;
        }
        set => looks = value;
        }
    public static int Days
        {
            get => days;
            set => days = value;
        }
    public static int Reputation
    {
        get => reputation;
    }

    [SerializeField] private int difficulty;
    [SerializeField] private GameObject foodPrompt;
    [SerializeField] private GameObject moneyPrompt;
    [SerializeField] private GameObject looksPrompt;

    [SerializeField] private GameObject winUI, lossUI, menuUI;
    private static bool won;

    private bool onBed = false;
    private static List<Quest> loggedQuests = new();
    
    private GameObject mainCam;
    private GameObject counterCam;

    void Start()
    {
        maxHero = Random.Range(2, 5);
        camCounter = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        using (StreamReader reader = new StreamReader("Assets/Resources/heroes.json"))
        {
            Hero.heroValues = JsonUtility.FromJson<Hero.heroJson>(reader.ReadToEnd());
        }

        days = 1;
        food = 5;
        money = 4;
        looks = 3;
        reputation = 2;
        
        mainCam = GameObject.FindWithTag("MainCamera");
        counterCam = GameObject.FindWithTag("SecondaryCamera");
        if (counterCam)
        {
            counterCam.SetActive(false);
        }
        QuestHover.mainCam = mainCam;
        QuestHover.counterCam = counterCam;
    }

    private void Update()
    {
        //Check LoseCon
        if (money < 0 || food < 0 || looks < 0)
        {
            menuUI.SetActive(true);
            lossUI.SetActive(true);
        }
        
        //UI stat
        if(foodPrompt.activeSelf)
            foodPrompt.GetComponent<TextMeshProUGUI>().text = $"Food : {food}";
        if (moneyPrompt.activeSelf)
            moneyPrompt.GetComponent<TextMeshProUGUI>().text = $"Money : {money}";
        if (looksPrompt.activeSelf)
            looksPrompt.GetComponent<TextMeshProUGUI>().text = $"Looks : {looks}";
        displayUI();

        //Next Day
        if (onBed)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                GeneratorHero.ResetHeroCount();
                maxHero = Random.Range(2, 5);
                Days++;
                Food--;
                Money--;
                if (Days % 3 == 0) Looks--;
                Debug.Log($"Day : {Days}, Food : {Food} , Money : {Money}, Looks : {Looks}");

                advanceQuests();

                if (won)
                {
                    menuUI.SetActive(true);
                    winUI.SetActive(true);
                }
                //Stocker days, food, money, reputation, looks,
                //tableau des quetes données à des heros, "score" (pas encore implémenté),
                // tableau des quetes que l'on peut passer aux heros (questUIManager.availableQuests)
            }
        }
    }
    
    public static void AddLoggedQuests(Quest quest)
    {
        loggedQuests.Add(quest);
        if (CheckQuestCompatibility(quest))
        {
            reputation++;
        }
        else
        {
            if (quest.heroes[0].ego)
            {
                reputation -= 3;
            }
            else reputation--;
        }
    }

    private static bool CheckQuestCompatibility(Quest quest)
    {
        var hero = quest.heroes[0];

        if (quest.thresholdStat == "str")
        {
            return hero.str >= quest.threshold;
        }
        if (quest.thresholdStat == "intel")
        {
            return hero.intel >= quest.threshold;
        }
        if (quest.thresholdStat == "spe")
        {
            return hero.spe >= quest.threshold;
        }

        return true;
    }

    public static void advanceQuests()
    {
        foreach (var quest in loggedQuests)
        {
            quest.duration--;
            if (quest.duration <= 0 && QuestUIManager.lastQuestNow)
            {
                if (quest.questName.Equals("Save the world") )
                {
                    if (CheckQuestCompatibility(quest))
                    {
                        won = true;
                    }
                    else
                    {
                        QuestUIManager.lastQuestNow = false;
                    }
                } 
                quest.active = false;

                switch (quest.bonusType)
                {
                    case "food" :
                        food += quest.bonus;
                        break;
                    case "money" :
                        money += quest.bonus;
                        break;
                    case "looks" :
                        looks += quest.bonus;
                        break;
                    case "reputation":
                        reputation += quest.bonus;
                        break;
                }
                
                switch (quest.bonusType)
                {
                    case "food" :
                        food -= quest.malus;
                        break;
                    case "money" :
                        money -= quest.malus;
                        break;
                    case "looks" :
                        looks -= quest.malus;
                        break;
                    case "reputation":
                        reputation -= quest.malus;
                        break;
                }
            }
        }

        loggedQuests = loggedQuests.Where(el => el.active).ToList();
        
        //incrémenter le score I guess
    }

    private static void displayUI()
    {
        if (camCounter.isActiveAndEnabled)
        {
            GameObject.FindWithTag("DayCount").GetComponent<TextMeshProUGUI>().text = days.ToString();
        }
    }
    
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        TriggerInteractions.ShowBubble("Sleep");
        onBed = true;
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        TriggerInteractions.RemoveBubble();
        onBed = false;
    }
}

        