using System;
using UnityEngine;

public class TriggerDoor : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private bool onDoor = false;
    private Tuple<Vector3,Vector3> doorLink;

    private void Start()
    {
        GameObject[] els = GameObject.FindGameObjectsWithTag("Door");
        doorLink = Tuple.Create(els[0].transform.position, els[1].transform.position);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        onDoor = true;
        TriggerInteractions.bubbleParent.transform.localPosition = new Vector3(0f, 2f, 0f);
        TriggerInteractions.ShowBubble("Take door");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        TriggerInteractions.RemoveBubble();
        onDoor = false;
    }

    private void Update()
    {
        if (!onDoor) return;
        //TODO penser pour la localisation
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (this.transform.position == doorLink.Item1) player.transform.position = doorLink.Item2;
            else player.transform.position = doorLink.Item1;
        }
    }
}
