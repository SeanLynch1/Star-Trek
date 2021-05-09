using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchRotation : MonoBehaviour
{
    public Transform target;
    void Start()
    {
        transform.rotation = target.rotation;
    }

    void Update()
    {
        transform.rotation = target.rotation;
    }
}
