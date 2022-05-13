using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;

public class GameBehaviour : MonoBehaviour
{
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

    private bool alive;
    
    [SerializeField] private int difficulty;
    [SerializeField] private GameObject foodPrompt;
    [SerializeField] private GameObject moneyPrompt;
    [SerializeField] private GameObject looksPrompt;
    
    private bool onBed = false;
    private static List<Quest> loggedQuests = new();

    void Start()
    {
        using (StreamReader reader = new StreamReader("Assets/Resources/heroes.json"))
        {
            Hero.heroValues =JsonUtility.FromJson<Hero.heroJson>(reader.ReadToEnd());
        }

        days = 1;
        food = 5;
        money = 4;
        looks = 3;
        reputation = 2;
        alive = true;
        GameObject.FindWithTag("MainCamera").SetActive(true);
    }

    private void Update()
    {
        //Check LoseCon
        if (money < 0 || food < 0 || looks < 0)
        {
            alive = false;
        }
        
        //UI stat
        if(foodPrompt.activeSelf)
            foodPrompt.GetComponent<TextMeshProUGUI>().text = $"Food : {food}";
        if (moneyPrompt.activeSelf)
            moneyPrompt.GetComponent<TextMeshProUGUI>().text = $"Money : {money}";
        if (looksPrompt.activeSelf)
            looksPrompt.GetComponent<TextMeshProUGUI>().text = $"Looks : {looks}";

        //Next Day
        if (onBed)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Days++;
                Food--;
                Money--;
                if (Days % 3 == 0) Looks--;
                Debug.Log($"Day : {Days}, Food : {Food} , Money : {Money}, Looks : {Looks}");

                advanceQuests();
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
        else reputation--;
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
            if (quest.duration <= 0)
            {
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
    
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        onBed = true;
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        onBed = false;
    }
}

        