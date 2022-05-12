using System;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class QuestUIManager : MonoBehaviour
{
    [SerializeField] private Sprite sprite;
    [SerializeField] private TextMeshProUGUI bonusText, questText, malusText;
    [SerializeField] private Transform parent;
    [SerializeField] private static Camera mainCam;
    [SerializeField] private GameObject questAlign;
    [SerializeField] private GameObject questPrefab;
    public static GameObject currentQuest;
    public static GameObject nullQuest;

    private List<GameObject> availableQuests = new();

    // TODO faire la deletion de l'objet selectionné (ptet dans le HoverQuest) puis recharger une quete a l'endroit de l'objet cliqué
    private void Start()
    {
        using (StreamReader reader = new StreamReader("Assets/Resources/quests.json"))
        {
            Quest.questsNames = JsonUtility.FromJson<Quest.questJson>(reader.ReadToEnd());
        }
        
        Debug.Log(Quest.questsNames);
        
        GenerateCards();
    }

    private void SwitchQuest(GameObject questObj)
    {
        Destroy(currentQuest);
        currentQuest = questObj;
    }

    private void DisplayQuest()
    {
        var questVals = currentQuest.GetComponent<Quest>();
        
        bonusText.text = $"Bonus : {questVals.bonus}";
        questText.text = questVals.questName;
        malusText.text = $"Malus : {questVals.malus}";
    }

    private void GenerateCards()
    {
        for (float i = questAlign.transform.localPosition.x - 5f; i < 10f; i += 5f)
        {
            availableQuests.Add(GenerateACard(new Vector3(questAlign.transform.position.x + i, questAlign.transform.position.y,0f)));
        }
    }

    private GameObject GenerateACard(Vector3 pos)
    {
        var newQuest = Instantiate(questPrefab);
        newQuest.AddComponent<Quest>();
        var questVals = newQuest.GetComponent<Quest>();
        questVals.GetComponent<Quest>().Randomize(GameBehaviour.Reputation);
        newQuest.transform.SetParent(parent);
        newQuest.transform.position = pos;

        return newQuest;
    }
    
    public static void exit()
    {
        mainCam.gameObject.SetActive(true);
    }
}
