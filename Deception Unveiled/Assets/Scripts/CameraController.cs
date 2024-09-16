using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;

    void Update()
    {
        if (player!= null)
        {
            Vector3 targetPos = player.position;
            targetPos.z = -20;
            transform.position = targetPos;
        }
    }
}
