using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scene1Controller : MonoBehaviour
{
    public GameObject fadeImage;

    public GameObject mirindaClass;
    public GameObject mirindaClassTarget;
    public float shipSpeed = 500f;
    private void Start()
    {
        GameEvents.Instance.FadeImageOut(fadeImage, 2f);
    }

    private void Update()
    {
        if(shipSpeed < 10000)
        {
            shipSpeed += 1;
        }
        GameEvents.Instance.MoveToTarget(mirindaClass, mirindaClassTarget, shipSpeed * Time.deltaTime);
    }
}
