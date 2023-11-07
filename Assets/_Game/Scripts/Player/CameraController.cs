using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraController : MonoBehaviour
{
    [SerializeField] protected GameObject camera;
    [SerializeField] private Vector3 offset;
    void LateUpdate()
    {
        camera.transform.position = transform.position + offset;
    }
}
