using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Cecil;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    // TODO lisser la relation smoothSpeed et speed du player pour limiter le jittering
    [SerializeField] private float smoothSpeed = 0.125f;
    [SerializeField] private Vector3 offset;

    void FixedUpdate()
    {
        Vector3 desiredPosition;
        float velocity = Input.GetAxis("Horizontal");
        
        if (velocity < 0) desiredPosition = target.position - offset;
        else if (velocity > 0) desiredPosition = target.position + offset;
        else desiredPosition = target.position;
        
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
