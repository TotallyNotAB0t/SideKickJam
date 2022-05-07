using System;
using UnityEngine;

public class GeneratorHero : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            InstantiateHero();
        }
    }

    private void InstantiateHero()
    {
        var newHero = new GameObject();
        newHero.name = "NewHero";
        newHero.AddComponent<Hero>();
        newHero.GetComponent<Hero>().Randomize();
        newHero.GetComponent<Hero>().GetAttributes();
    }
}
