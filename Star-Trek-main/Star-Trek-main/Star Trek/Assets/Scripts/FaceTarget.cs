using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceTarget : MonoBehaviour
{
    public Transform target;

    void Start()
    {
        transform.LookAt(target.position);
    }
}
