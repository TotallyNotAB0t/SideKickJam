using UnityEngine;

public class Quest : MonoBehaviour
{
    private int bonus;
    private string questName;
    private int malus;
    

    public void SetBonus(int bonusValue)
    {
        bonus = bonusValue;
    }

    public void SetMalus(int malusValue)
    {
        malus = malusValue;
    }

    public void SetQuestName(string questValue)
    {
        questName = questValue;
    }
}
