using UnityEngine;

public class Hero : MonoBehaviour
{
    private string characterName;
    private int level;
    private string characterClass;
    private int lives;

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
