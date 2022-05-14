using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class menuData : MonoBehaviour
{
    [SerializeField] private GameObject scoreFood, scoreMoney, scoreLooks, scoreDays;

    private void Update()
    {
        scoreFood.GetComponent<TextMeshProUGUI>().text = $"{GameBehaviour.Food} food";
        scoreMoney.GetComponent<TextMeshProUGUI>().text = $"{GameBehaviour.Money} money";
        scoreLooks.GetComponent<TextMeshProUGUI>().text = $"{GameBehaviour.Looks} Looks";
        scoreDays.GetComponent<TextMeshProUGUI>().text = $"You played for {GameBehaviour.Days} days!";
    }
}
