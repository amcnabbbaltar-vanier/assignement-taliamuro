using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    This sclass keeps the camera following the player without rotating
*/
public class CameraFollow1 : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}
