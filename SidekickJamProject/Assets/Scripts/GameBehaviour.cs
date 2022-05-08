using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameBehaviour : MonoBehaviour
{
    private int food, money, looks, reputation;
    private int Food => food;
    private int Money => money;
    private int Looks => looks;
    private int Reputation => reputation;
    
    private int days;
    private bool alive;
    
    [SerializeField] private int difficulty;
    [SerializeField] private GameObject foodPrompt;
    [SerializeField] private GameObject moneyPrompt;
    [SerializeField] private GameObject looksPrompt;
    
    void Start()
    {
        days = 0;
        food = 5;
        money = 4;
        looks = 3;
        reputation = 2;
        alive = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            days++;
            food--;
            money--;
            if (days % 3 == 0) looks--;
            Debug.Log($"Day : {days}, Food : {food} , Money : {money}, Looks : {looks}");
        }

        if (money < 0 || food < 0 || looks < 0)
        {
            alive = false;
        }
        if(foodPrompt.activeSelf)
            foodPrompt.GetComponent<TextMeshProUGUI>().text = $"Food : {food}";
        if (moneyPrompt.activeSelf)
            moneyPrompt.GetComponent<TextMeshProUGUI>().text = $"Money : {money}";
        if (looksPrompt.activeSelf)
            looksPrompt.GetComponent<TextMeshProUGUI>().text = $"Looks : {looks}";
    }
}

        