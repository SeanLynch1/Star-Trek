using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scene1Controller : CameraSettings
{
    public GameObject fadeImage;
    public GameObject insideOfShip;
    public GameObject mirandaClass;
    public GameObject mirindaClassTarget;
    public GameObject dialogueCanvas;
    public GameObject spaceDock;

    [Header("Camera Settings")]
    public List<GameObject> currentCameraList;
    public static List<GameObject> currentCameraListStatic;


    public float elapsedTime;
    private float shipSpeed = 1f;
    public float cameraRotationDuration;
    public float cameraRotSpeed;
    public bool stopPan = false;
    private int currentCameraIndex;
    public int currentCamera;
    public static int CurrentCameraIndex
    {
        get;
        set;
    }
    [Header("Time Settings")]
    public List<float> timeStamp;
    public List<float> shotDurationList = new List<float>();
    private void Awake()
    {
        insideOfShip.SetActive(false);
    }
    private void Start()
    {
        GameEvents.Instance.FadeImageOut(fadeImage, 2f);

        GameEvents.Instance.ArrangeStoppageTime(timeStamp, shotDurationList);
    }
    private void Update()
    {
        currentCamera = CurrentCameraIndex;
    }
    private void FixedUpdate()
    {
        currentCameraListStatic = currentCameraList;
        elapsedTime += Time.deltaTime;

        for (int i = 0; i < timeStamp.Count; i++)
        {
            if (timeStamp[i] < elapsedTime)
                CurrentCameraIndex = i;
        }

        shipSpeed = GameEvents.Instance.CalculateDistanceFunc(mirandaClass, mirindaClassTarget);
        GameEvents.Instance.MoveToTarget(mirandaClass, mirindaClassTarget, shipSpeed * Time.deltaTime);
        GameEvents.Instance.SwitchCameraFunction(currentCameraList, CurrentCameraIndex);

        SwitchCamera();
    }
    public override void SwitchCamera()
    {

        switch (CurrentCameraIndex)
        {
            case 0:
                stopPan = false;
                shotDurationList[CurrentCameraIndex] -= Time.deltaTime;
                GameEvents.Instance.PanCameraFunction(currentCameraList[CurrentCameraIndex], mirandaClass, mirindaClassTarget, shotDurationList[CurrentCameraIndex], cameraRotSpeed, 10f, stopPan, 0.25f);
                break;
            case 1:
                stopPan = true;
                shotDurationList[CurrentCameraIndex] -= Time.deltaTime;
                GameEvents.Instance.PanCameraFunction(currentCameraList[CurrentCameraIndex], mirandaClass, mirindaClassTarget, timeStamp[CurrentCameraIndex], cameraRotSpeed, 30f, stopPan, 0);
                break;
            case 2:
                GameEvents.Instance.MoveToTarget(currentCameraList[CurrentCameraIndex], mirindaClassTarget, shipSpeed * Time.deltaTime); //Steady Shot
                break;
            case 3:
                insideOfShip.SetActive(true);
                mirandaClass.SetActive(false);
                StartCoroutine(ActivateCanvas());
                GameEvents.Instance.MoveToTarget(insideOfShip, mirindaClassTarget, shipSpeed * Time.deltaTime);
                break;
            case 4:
                if (DialogueText.secondBool)
                    DialogueText.playDialogue = true;
                else
                    DialogueText.playDialogue = false;
                StartCoroutine(ActivateCanvas());
                GameEvents.Instance.PanCameraFunction(currentCameraList[CurrentCameraIndex], spaceDock, spaceDock, timeStamp[CurrentCameraIndex], cameraRotSpeed, 1f, stopPan, 0);
                break;
            default:
                return;
        }

    }
    public IEnumerator ActivateCanvas()
    {
        yield return new WaitForSeconds(2f);
        if(DialogueText.secondBool)
        {
            if (DialogueText.playDialogue)
                dialogueCanvas.SetActive(true);
        }
    }
}