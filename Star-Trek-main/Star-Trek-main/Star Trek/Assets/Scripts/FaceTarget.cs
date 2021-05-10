using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceTarget : MonoBehaviour
{
    public Transform target;
    public bool scene1;
    void Update()
    {
        if(scene1)
        target = Scene1Controller.currentCameraListStatic[Scene1Controller.CurrentCameraIndex].transform;
        if(target != null)
        transform.LookAt(target.position);
    }
}
