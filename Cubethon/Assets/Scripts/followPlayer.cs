using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    public Vector3 cameraOffset;
    public float shakeDistance;
    // Update is called once per frame
    void OnEnable()
    {
        PlayerMovement.onMove += CameraUpdate;
    }
    void OnDisable()
    {
        PlayerMovement.onMove -= CameraUpdate;
    }
    public void CameraUpdate(Vector3 player)
    {
        transform.position = player + cameraOffset;
        Shake();
    }
    void Shake()
    {
        transform.position =new Vector3(transform.position.x + shakeDistance, transform.position.y, transform.position.z);
        shakeDistance = -shakeDistance;
    }
}
