using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{

    [SerializeField]
    private float rotateSpeed = 10;
    private void FixedUpdate()
    {
        transform.Rotate(Vector3.forward * (rotateSpeed * Time.deltaTime));
    }
}
