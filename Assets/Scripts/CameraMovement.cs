using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Object to follow
    public Transform lookAt;

    // Position to keep from the object
    [SerializeField]
    private Vector3 positionOffset = new Vector3(0f, 2.18f, -3f);
    [SerializeField]
    private Vector3 rotation = new Vector3(17.29f, 0f, 0f);

    private void Start()
    {
        transform.position = lookAt.position + positionOffset;
        transform.rotation = Quaternion.Euler(rotation);
    }

    private void LateUpdate()
    {
        Vector3 targetPosition = transform.position;
        targetPosition.z = lookAt.position.z + positionOffset.z;

        transform.position = targetPosition;
    }
}
