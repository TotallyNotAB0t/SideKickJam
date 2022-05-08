using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SceneUI : MonoBehaviour
{
    [SerializeField] private Sprite sprite;
    [SerializeField] private TextMeshProUGUI bonusText, questText, malusText;
    [SerializeField] private Transform parent;
    public static GameObject currentQuest;
    public static GameObject nullQuest;

    private void Start()
    {
        currentQuest = QuestGenerator.GenerateQuest();
        GenerateCards();
        nullQuest = new GameObject();
        nullQuest.AddComponent<Quest>();
        var param= nullQuest.GetComponent<Quest>();
        param.name = "";
        param.bonus = 0;
        param.malus = 0;
    }

    private void SwitchQuest(GameObject questObj)
    {
        Destroy(currentQuest);
        currentQuest = questObj;
    }

    private void Update()
    {
        DisplayQuest();

        if (Input.GetKeyDown(KeyCode.Q))
        {
            SwitchQuest(QuestGenerator.GenerateQuest());
        }
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
        for (float i = parent.transform.position.x - 5f; i < 10f; i += 5f)
        {
            GenerateACard(new Vector3(i, 0f,0f));
        }
    }

    private void GenerateACard(Vector3 pos)
    {
        var quest = QuestGenerator.GenerateQuest();
        quest.transform.SetParent(parent);
        quest.AddComponent<SpriteRenderer>().sprite = sprite;
        quest.AddComponent<QuestHover>();
        quest.AddComponent<BoxCollider2D>();
        quest.transform.localScale = new Vector3(50f, 90f, 50f);
        quest.transform.position = pos;
    }
}
