using System;
using System.IO;
using UnityEngine;
using Random = UnityEngine.Random;

public class Hero : MonoBehaviour
{
    public string characterName, characterClass, fluff;
    public int level, lives, force, intelligence, speed;
    public bool ego;

    public void Randomize(Vector3 pos)
    {
        transform.position = pos;
        
        name = "placeHolderName";
        fluff = "fluff";
        lives = Random.Range(5, 30);
        
        // Calcul Elite
        var egoVal = Random.Range(0, 100);
        ego = egoVal > 90;

        // Reputation linked generation
        var rep = GameBehaviour.Reputation;

        if (rep < 15) // EARLY
        {
            level = Random.Range(1, 5);
            instantiateHeroClass(rep);
        }
        else if (rep < 30) //MID
        {
            level = Random.Range(5, 12);
        }
        else if (rep < 55) //LATE
        {
            level = Random.Range(12, 20);
        }
    }

    void instantiateHeroClass(int rep)
    {
        switch (Random.Range(1, 3))
        {
            case 1:
                characterClass = "Warrior";
                break;
            case 2:
                characterClass = "Mage";
                break;
            case 3:
                characterClass = "Ranger";
                break;
        }
    }

    public void GetAttributes()
    {
        Debug.Log($"name : {characterName}, class : {characterClass}, level : {level}, lives : {lives}");
    }
}
