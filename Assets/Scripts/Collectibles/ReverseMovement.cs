using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseMovement : MonoBehaviour
{
    // Object to follow
    public Transform lookAt;

    // Position to keep from the object
    [SerializeField]
    private Vector3 positionOffset = Constants.blessingPosition;
    [SerializeField]
    private Vector3 rotation = Constants.cameraRotation;

    private void Start()
    {
        transform.position = lookAt.position + positionOffset;
        transform.rotation = Quaternion.Euler(rotation);
    }

    private void LateUpdate()
    {
        Vector3 targetPosition = transform.position;
        targetPosition = lookAt.position + positionOffset;

        transform.position = targetPosition;
    }
}
