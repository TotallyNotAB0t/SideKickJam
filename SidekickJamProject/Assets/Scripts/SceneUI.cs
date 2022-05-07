using System;
using TMPro;
using UnityEngine;

public class SceneUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bonusText, questText, malusText;
    private GameObject currentQuest;

    private void Start()
    {
        currentQuest = QuestGenerator.GenerateQuest();
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
}
