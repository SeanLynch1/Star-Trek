using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class IntroCinematics : MonoBehaviour
{
    public List<TextMeshProUGUI> textMeshesList;
    public List<bool> pairedTextState;
    public GameObject cameraTarget;
    public GameObject fadeImage;
    public GameObject mainCamera;
    private  int iterations = 0;
    private float timeInterval = 1f;
    public float cameraSpeed = 20;
    private float startTime;
    public AudioSource music;

    private void Awake()
    {
        startTime = timeInterval;
    }
    private void Start()
    {
        GameEvents.Instance.FadeImageOut(fadeImage, 10.5f);
    }
    private void FixedUpdate()
    {
        GameEvents.Instance.RollTextCinematicsFunction(textMeshesList,pairedTextState, ref timeInterval, ref iterations, 4f);

        startTime -= Time.deltaTime;
        
        if(startTime <= 0)
        {
            startTime = 0;
            if (cameraSpeed < 10000)
            {
                cameraSpeed += 2f;
            }
            GameEvents.Instance.MoveToTarget(mainCamera, cameraTarget, cameraSpeed * Time.deltaTime);
        }
        if(!music.isPlaying)
        {
            StartCoroutine(WaitForSeconds());
        }
    }
    private IEnumerator WaitForSeconds()
    {
        GameEvents.Instance.FadeImageIn(fadeImage, 7.5f);
        yield return new WaitForSeconds(6f);
        SceneManager.LoadScene("Scene1");
    }
}
