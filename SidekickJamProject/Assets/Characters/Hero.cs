using UnityEngine;

public class Hero : MonoBehaviour
{
    private string characterName, characterClass, fluff;
    private int level, lives, force, intelligence, speed, reputation;
    private bool ego;

    public void Randomize(Vector3 pos)
    {
        transform.position = pos;
        name = "placeHolderName";
        level = Random.Range(1, 51);
        characterClass = "placeholderclass";
        lives = Random.Range(20, 41);
    }

    public void GetAttributes()
    {
        Debug.Log($"name : {characterName}, class : {characterClass}, level : {level}, lives : {lives}");
    }
}
