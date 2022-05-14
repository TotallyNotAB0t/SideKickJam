using UnityEngine;

public class GeneratorHero : MonoBehaviour
{
    [SerializeField] private GameObject initPos, counterPos;
    [SerializeField] private Sprite heroSprite;
    [SerializeField, Range(0.1f, 10f)] private float heroSpeed;
    private GameObject actualHero;
    private bool onCounter, onExit;
    public static bool isCounterOpen;
    public GetHeroInformation info;

    private void Update()
    {
        if (isCounterOpen && !actualHero )
        {
            InstantiateHero();
        }

        if (isCounterOpen)
        {
            MoveHero();
        }

        if (QuestHover.questSent)
        {
            MoveHeroBackwards();
        }
        ResetNewHero();
    }

    private void MoveHero()
    {
        if (actualHero && !onCounter)
        {
            actualHero.transform.position = Vector3.MoveTowards(actualHero.transform.position, counterPos.transform.position, heroSpeed * Time.deltaTime);
            if ( Vector3.Distance(actualHero.transform.position, counterPos.transform.position) <= 0.01f)
            {
                onCounter = true;
            }
        }
    }

    private void MoveHeroBackwards()
    {
        if (!onCounter) return;
        if (!actualHero) return;
        actualHero.transform.position = Vector3.MoveTowards(actualHero.transform.position, initPos.transform.position, heroSpeed * Time.deltaTime);
        if ( Vector3.Distance(actualHero.transform.position, initPos.transform.position) <= 0.01f)
        {
            onExit = true;
        }
    }

    private void ResetNewHero()
    {
        if (!onExit) return;
        QuestHover.questSent = false;
        onCounter = false;
        onExit = false;
        Destroy(actualHero);
        InstantiateHero();
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
        info.GetInfo(newHero.GetComponent<Hero>());
    }
}
