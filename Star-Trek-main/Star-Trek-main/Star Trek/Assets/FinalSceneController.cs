using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalSceneController : MonoBehaviour
{
    public GameObject fadeImage;

    private void Start()
    {
        GameEvents.Instance.FadeImageOut(fadeImage,4f);
    }
}
