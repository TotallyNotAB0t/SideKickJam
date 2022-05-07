using UnityEngine;

public class Hero : MonoBehaviour
{
    private string characterName;
    private int level;
    private string characterClass;
    private int lives;

    public void Randomize()
    {
        transform.position = new Vector2(Random.Range(0f, 10f), 0);
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
