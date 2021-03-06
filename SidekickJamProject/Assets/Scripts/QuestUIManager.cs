using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;

public class QuestUIManager : MonoBehaviour
{
    [SerializeField] private Sprite lastQuestSprite;
    [SerializeField] private TextMeshProUGUI bonusText, questText, malusText, durationText;
    [SerializeField] private Transform parent;
    [SerializeField] private static Camera mainCam;
    [SerializeField] private GameObject questAlign;
    [SerializeField] private GameObject questPrefab;
    public static GameObject currentQuest;
    public static GameObject nullQuest;


    private static GameObject tmp;
    private static bool isClicked;
    public static bool lastQuestNow;

    private static List<GameObject> availableQuests = new();
    
    private void Start()
    {
        using (var reader = new StreamReader("Assets/Resources/quests.json"))
        {
            Quest.questsNames = JsonUtility.FromJson<Quest.questJson>(reader.ReadToEnd());
        }
        
        GenerateCards();
    }

    private void Update()
    {
        DisplayQuest();
        if (isClicked)
        {
            updateAvailableQuests();
        }
    }

    private void GenerateCards()
    {
        availableQuests.Clear();
        for (float i = questAlign.transform.localPosition.x - 6f; i <= 6.1f; i += 3f)
        {
            availableQuests.Add(GenerateACard(new Vector3(questAlign.transform.position.x + i, questAlign.transform.position.y,0f)));
        }
    }

    private GameObject GenerateACard(Vector3 pos)
    {
        var newQuest = Instantiate(questPrefab);
        newQuest.AddComponent<Quest>();
        var questVals = newQuest.GetComponent<Quest>();
        questVals.Randomize(GameBehaviour.Reputation);
        newQuest.transform.SetParent(parent);
        newQuest.transform.position = pos;
        newQuest.GetComponent<SpriteRenderer>().sortingOrder = 1;

        return newQuest;
    }

    private GameObject generateLastQuest(Vector3 pos)
    {
        var lastQuest = Instantiate(questPrefab);
        lastQuest.AddComponent<Quest>();
        var questVals = lastQuest.GetComponent<Quest>();
        questVals.lastQuest();
        lastQuest.transform.SetParent(parent);
        lastQuest.transform.position = pos;
        lastQuest.GetComponent<SpriteRenderer>().sortingOrder = 1;
        lastQuest.GetComponent<SpriteRenderer>().sprite = lastQuestSprite;
        return lastQuest;
    }

    public static void collectClickedQuest(GameObject quest)
    {
        tmp = quest;
        isClicked = true;
        if (quest.GetComponent<Quest>().questName.Equals("Save the world"))
        {
            lastQuestNow = true;
        }
    }
    
    private void updateAvailableQuests()
    {
        isClicked = false;
        availableQuests.Remove(tmp);
        if (GameBehaviour.Reputation > 70)
        {
            if (!availableQuests.Find(el => el.GetComponent<Quest>().questName.Equals("Save the world")) && !lastQuestNow)
            {
                availableQuests.Add(generateLastQuest(tmp.transform.position));
            }
            else availableQuests.Add(GenerateACard(tmp.transform.position));
        }
        else
            availableQuests.Add(GenerateACard(tmp.transform.position));

        tmp = null;
    }

    private void DisplayQuest()
    {
        if (currentQuest == null) return;
        var questVals = currentQuest.GetComponent<Quest>();
        if (questVals == null)
        {
            bonusText.text = "";
            questText.text = "";
            malusText.text = "";
            durationText.text = "";
            return;
        }
        bonusText.text = $"{questVals.bonusType} {String.Concat(Enumerable.Repeat("+ ", questVals.bonus))}";
        questText.text = questVals.questName;
        malusText.text = $"{questVals.malusType} {String.Concat(Enumerable.Repeat("- ", questVals.malus))}";
        durationText.text = $"{questVals.duration} days";
    }
    
    public static void exit()
    {
        mainCam.gameObject.SetActive(true);
    }
}
