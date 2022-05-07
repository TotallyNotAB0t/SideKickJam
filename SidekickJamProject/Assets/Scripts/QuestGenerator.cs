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

    private static void GenerateQuest()
    {
        var newQuest = new GameObject();
        newQuest.name = "NewQuest";
        newQuest.AddComponent<Quest>();
        newQuest.GetComponent<Quest>().SetBonus(Random.Range(0, 4));
        newQuest.GetComponent<Quest>().SetMalus(Random.Range(0, 3));
        newQuest.GetComponent<Quest>().SetQuestName("PlaceHolderName");
    }
}
