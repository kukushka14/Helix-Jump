using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class CameraFollow : MonoBehaviour
{
    public Player player;
    public Vector3 PlatformToCameraOffset;
    public float Speed;

    void Update()
    {
        if (player.CurrentPlatform == null) return;
        Vector3 targetPosition = player.CurrentPlatform.transform.position + PlatformToCameraOffset;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Speed * Time.deltaTime);
    }
}

