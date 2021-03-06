using UnityEngine;

public class GeneratorHero : MonoBehaviour
{
    [SerializeField] private GameObject initPos, counterPos;
    [SerializeField, Range(0.1f, 10f)] private float heroSpeed;
    [SerializeField] private Sprite mageSprite, warriorSprite, rangerSprite;
    [SerializeField] private AudioSource audio;
    private GameObject actualHero;
    private bool onCounter, onExit;
    public static bool isCounterOpen;
    public GetHeroInformation info;
    public static int heroCount;
    public static bool isDayOver;

    private void Update()
    {
        if (heroCount <= GameBehaviour.maxHero)
        {
            isDayOver = false;
        }
        else
        {
            isDayOver = true;
        }
        ResetNewHero();
        if (!(heroCount <= GameBehaviour.maxHero)) return;
        if (isCounterOpen && !actualHero)
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
        
    }

    public static bool IsDayOver()
    {
        return isDayOver;
    }

    public static void ResetHeroCount()
    {
        heroCount = 0;
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
        actualHero.transform.localScale = new Vector3(-1, 1, 1);
        actualHero.transform.position = Vector3.MoveTowards(actualHero.transform.position, initPos.transform.position, heroSpeed * Time.deltaTime);
        if ( Vector3.Distance(actualHero.transform.position, initPos.transform.position) <= 0.01f)
        {
            onExit = true;
        }
    }

    private void ResetNewHero()
    {
        if (!(heroCount <= GameBehaviour.maxHero))
        {
            QuestHover.questSent = false;
            onCounter = false;
            onExit = false;
            Destroy(actualHero);
        }
        if (!onExit) return;
        QuestHover.questSent = false;
        onCounter = false;
        onExit = false;
        Destroy(actualHero);
    }

    private void InstantiateHero()
    {
        var newHero = new GameObject();
        newHero.name = "NewHero";
        newHero.tag = "Hero";
        var spr = newHero.AddComponent<SpriteRenderer>();
        newHero.AddComponent<Hero>();
        newHero.GetComponent<Hero>().Randomize(initPos.transform.position);
        newHero.GetComponent<Hero>().GetAttributes();
        switch (newHero.GetComponent<Hero>().characterClass)
        {
            case "Warrior":
                spr.sprite = warriorSprite;
                break;
            case "Mage":
                spr.sprite = mageSprite;
                break;
            case "Ranger":
                spr.sprite = rangerSprite;
                break;
        }

        newHero.GetComponent<SpriteRenderer>().sortingOrder = 3;
        actualHero = newHero;
        info.GetInfo(newHero.GetComponent<Hero>());
        heroCount++;
        audio.Play();
    }
}
