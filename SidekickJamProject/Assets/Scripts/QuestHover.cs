using System;
using UnityEngine;

public class QuestHover : MonoBehaviour
{
    private bool canGrow, canShrink;
    public static bool questSent;
    
    public static GameObject mainCam;
    public static GameObject counterCam;

    private void Awake()
    {
        gameObject.transform.localScale = new Vector3(2f, 2f, 2f);
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
    
    private void OnMouseUp()
    {
        questSent = true;
        mainCam.SetActive(true);
        counterCam.SetActive(false);
        
        GetComponent<Quest>().heroes.Add(GameObject.FindWithTag("Hero").GetComponent<Hero>());
        GameBehaviour.AddLoggedQuests(this.GetComponent<Quest>());
        QuestUIManager.collectClickedQuest(this.gameObject);
        Destroy(gameObject);
    }
    
    private void Grow()
    {
        if(transform.localScale.magnitude < new Vector3(50f, 50f, 50f).magnitude)
        {
            transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
        }
    }

    private void Shrink()
    {
        if(transform.localScale.magnitude > new Vector3(40f, 40f, 40f).magnitude)
        {
            transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
        }
    }
}
