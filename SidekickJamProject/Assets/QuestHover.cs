using System;
using System.Collections;
using UnityEngine;

public class QuestHover : MonoBehaviour
{
    private bool canGrow, canShrink;
    
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
        SceneUI.currentQuest = gameObject;
        canGrow = true;
        canShrink = false;
    }

    private void OnMouseExit()
    {
        SceneUI.currentQuest = SceneUI.nullQuest;
        canShrink = true;
        canGrow = false;
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
