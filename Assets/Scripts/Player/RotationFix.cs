using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationFix : MonoBehaviour
{
    [SerializeField]
    private Vector3 rotation = new Vector3(0, 90, 0);

    void Start()
    {
        transform.rotation = Quaternion.Euler(rotation);
    }

    void Update()
    {

    }
}
