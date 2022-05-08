using UnityEngine;

public class GeneratorHero : MonoBehaviour
{
    [SerializeField] private Vector3 initPos, targetPos;
    [SerializeField] private Sprite heroSprite;
    [SerializeField, Range(0.1f, 5f)] private float heroSpeed;
    private GameObject actualHero;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            InstantiateHero();
        }

        if (actualHero)
        {
            actualHero.transform.position = Vector3.MoveTowards(actualHero.transform.position, targetPos, heroSpeed * Time.deltaTime);
        }
        
    }

    private void InstantiateHero()
    {
        var newHero = new GameObject();
        newHero.name = "NewHero";
        var spr = newHero.AddComponent<SpriteRenderer>();
        spr.color = Color.cyan;
        spr.sprite = heroSprite;
        newHero.AddComponent<Hero>();
        newHero.GetComponent<Hero>().Randomize(initPos);
        newHero.GetComponent<Hero>().GetAttributes();
        actualHero = newHero;
    }
}
