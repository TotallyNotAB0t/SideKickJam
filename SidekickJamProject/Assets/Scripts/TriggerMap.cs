using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMap : MonoBehaviour
{
    [SerializeField] private GameObject player;
    void OnTriggerEnter2D(Collider2D col)
    {
        player.GetComponent<SpriteRenderer>().enabled = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        player.GetComponent<SpriteRenderer>().enabled = false;
    }
}
