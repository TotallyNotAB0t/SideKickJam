using System;
using System.IO;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

public class Hero : MonoBehaviour
{
    public string characterName, characterClass, fluff;
    public int level, lives, str, intel, spe;
    public bool ego;
    public TextAsset heroJsonFile;
    public static heroJson heroValues;

    public void Randomize(Vector3 pos)
    {
        transform.position = pos;
        
        characterName = $"{heroValues.surname[Random.Range(0, heroValues.surname.Length)]} {heroValues.name[Random.Range(0, heroValues.name.Length)]}";
        fluff = "fluff";
        lives = Random.Range(5, 30);
        
        // Calcul Elite
        var egoVal = Random.Range(0, 100);
        ego = egoVal > 90;

        // Reputation linked generation
        var rep = GameBehaviour.Reputation;
        instantiateHeroClass(rep);
    }

    void instantiateHeroClass(int rep)
    {
        if (rep < 15) // EARLY
        {
            level = Random.Range(1, 5);
        }
        else if (rep < 30) //MID
        {
            level = Random.Range(5, 12);
        }
        else if (rep < 55) //LATE
        {
            level = Random.Range(12, 20);
        }
        
        str = level + Random.Range(-1,rep/3 + 1);
        intel = level + Random.Range(-1,rep/3 + 1);
        spe = level + Random.Range(-1,rep/3 + 1);

        var tmp = Math.Max(str, Math.Max(intel, spe));
        if (str == tmp)
        {
            characterClass = "Warrior";
        }
        if (intel == tmp)
        {
            characterClass = "Mage";
        }
        if (spe == tmp)
        {
            characterClass = "Ranger";
        }
    }

    public void GetAttributes()
    {
        Debug.Log($"name : {characterName}, class : {characterClass}," +
                  $" level : {level}," +
                  $" life : {lives}" +
                  $" STR : {str} INT : {intel} SPE : {spe}");
    }
    
    
    [Serializable]
    public class heroJson
    {
        public string[] name;
        public string[] surname;
        public string[] fluff;
    }
}
