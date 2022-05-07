using UnityEngine;

public class QuestGenerator : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GenerateQuest();
        }
    }

    public static GameObject GenerateQuest()
    {
        var newQuest = new GameObject();
        newQuest.name = "NewQuest";
        newQuest.AddComponent<Quest>();
        var questVals = newQuest.GetComponent<Quest>();
        
        questVals.bonus = Random.Range(0, 4);
        questVals.malus = Random.Range(0, 3);
        questVals.questName = "Yeet the dragon";

        return newQuest;
    }
}
