using UnityEngine;

public class hoverBook : MonoBehaviour
{

    private bool onIt;
    [SerializeField] private GameObject bookUI;
    
    private void OnMouseEnter()
    {
        Debug.Log("Enter Read");
        onIt = true;
    }

    private void OnMouseExit()
    {
        onIt = false;
    }

    private void Update()
    {
        bookUI.SetActive(onIt);
    }
}
