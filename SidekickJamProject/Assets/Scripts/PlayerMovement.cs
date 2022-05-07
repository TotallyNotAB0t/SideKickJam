using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 0.1f;
    
    void Update()
    {
        float velocity = Input.GetAxis("Horizontal");
        transform.Translate(speed * velocity * 0.2f , 0f,0f);
    }
}
