using UnityEngine;

public class GeneratorHero : MonoBehaviour
{
    [SerializeField] private GameObject initPos, targetPos;
    [SerializeField] private Sprite heroSprite;
    [SerializeField, Range(0.1f, 5f)] private float heroSpeed;
    private GameObject actualHero;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            InstantiateHero();
        }

        if (actualHero)
        {
            actualHero.transform.position = Vector3.MoveTowards(actualHero.transform.position, targetPos.transform.position, heroSpeed * Time.deltaTime);
        }
        
    }

    private void InstantiateHero()
    {
        var newHero = new GameObject();
        newHero.name = "NewHero";
        newHero.tag = "Hero";
        var spr = newHero.AddComponent<SpriteRenderer>();
        spr.sprite = heroSprite;
        newHero.AddComponent<Hero>();
        newHero.GetComponent<Hero>().Randomize(initPos.transform.position);
        newHero.GetComponent<Hero>().GetAttributes();
        actualHero = newHero;
    }
}
