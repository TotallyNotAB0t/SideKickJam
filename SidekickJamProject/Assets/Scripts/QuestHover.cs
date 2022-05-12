using System;
using System.Collections;
using System.ComponentModel.Design;
using UnityEngine;

public class QuestHover : MonoBehaviour
{
    private bool canGrow, canShrink;
    
    
    private GameObject mainCam;
    private GameObject counterCam;

    //A deplacer ailleurs : nullreference parce que chaque quete possède quest hover, on a qu'une camera
    private void Start()
    {
        mainCam = GameObject.FindWithTag("MainCamera");
        counterCam = GameObject.FindWithTag("SecondaryCamera");
        if (counterCam)
        {
            counterCam.SetActive(false);
        }
    }

    private void Update()
    {
        if (canShrink)
        {
            Shrink();
        }
        else if (canGrow)
        {
            Grow();
        }
    }

    private void OnMouseEnter()
    {
        QuestUIManager.currentQuest = gameObject;
        canGrow = true;
        canShrink = false;
    }

    private void OnMouseExit()
    {
        QuestUIManager.currentQuest = QuestUIManager.nullQuest;
        canShrink = true;
        canGrow = false;
    }

    //Nullreference ?
    private void OnMouseUp()
    {
        mainCam.gameObject.SetActive(true);
        if (counterCam)
        {
            counterCam.gameObject.SetActive(false);
        }
        
        GetComponent<Quest>().heroes.Add(GameObject.FindWithTag("Hero").GetComponent<Hero>());
        GameBehaviour.AddLoggedQuests(this.GetComponent<Quest>());
    }
    
    private void Grow()
    {
        if(transform.localScale.magnitude < new Vector3(70f, 110f, 70f).magnitude)
        {
            transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
        }
    }

    private void Shrink()
    {
        if(transform.localScale.magnitude > new Vector3(50f, 90f, 50f).magnitude)
        {
            transform.localScale -= new Vector3(0.5f, 0.5f, 0.5f);
        }
    }
}
