using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class WorldBorder : MonoBehaviour
{
    [FormerlySerializedAs("camera")] [SerializeField] private GameObject cam;
    [SerializeField] private String extremum;
    private Boolean visible = false;
    private float previousPostion;

    private void OnTriggerExit(Collider other)
    {
        blockleft();
    }

    void blockleft()
    {
        if (previousPostion > cam.transform.position.x)
        {
            cam.transform.position = new Vector3(previousPostion,cam.transform.position.y,cam.transform.position.z);
        }
    }
    
    void blockright()
    {
        if (previousPostion < cam.transform.position.x)
        {
            cam.transform.position = new Vector3(previousPostion,cam.transform.position.y,cam.transform.position.z);
        }
    }
}
