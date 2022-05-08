using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        onDoor = false;
    }

    private void Update()
    {
        if (!onDoor) return;
        //TODO penser pour la localisation
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (this.transform.position == doorLink.Item1) player.transform.position = doorLink.Item2;
            else player.transform.position = doorLink.Item1;
        }
    }
}
