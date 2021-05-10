using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public partial class GameEvents : MonoBehaviour
{
    #region InvocationListEditing
    private void OnEnable()
    {
        onFadeImageIn += IncreaseAlpha;
        onFadeImageOut += DecreaseAlpha;
        onFadeTextIn += FadeTextIn;
        onFadeTextOut += FadeTextOut;
        onFadeInAndOut += FadeTextInAndOut;
        onRollCinematics += RollTextCinematics;
        onMoveToTarget += MoveTowardsTarget;
        onPanCamera += PanCamera;
        onSwitchCamera += CameraOrderOfOperations;
        onCalculateDistance += CalculateDistance;
        onArrangeStoppageTime += ArrangeTimes;
    }
    private void OnDisable()
    {
        onFadeImageIn -= IncreaseAlpha;
        onFadeImageOut -= DecreaseAlpha;
        onFadeTextIn -= FadeTextIn;
        onFadeTextOut -= FadeTextOut;
        onFadeInAndOut -= FadeTextInAndOut;
        onRollCinematics -= RollTextCinematics;
        onMoveToTarget -= MoveTowardsTarget;
        onPanCamera -= PanCamera;
        onSwitchCamera -= CameraOrderOfOperations;
        onCalculateDistance -= CalculateDistance;
        onArrangeStoppageTime -= ArrangeTimes;
    }
    #endregion
    #region Functions
    public void IncreaseAlpha(GameObject g,float time)
    {
        Image i;
        i = g.GetComponent<Image>();
        g.GetComponent<Image>().CrossFadeAlpha(1f, 3f, false);
    }
    
    public void DecreaseAlpha(GameObject g, float time)
    {
        StartCoroutine(WaitToDecreaseAlpha( g,  time));
    }
    public IEnumerator WaitToDecreaseAlpha(GameObject g, float time)
    {
        Image i;
        i = g.GetComponent<Image>();
        yield return new WaitForSeconds(time);
        g.GetComponent<Image>().CrossFadeAlpha(0, 3f, false);
    }
    public void FadeTextInAndOut(TextMeshProUGUI textMesh, float startTime)
    {
        StartCoroutine(AlphaFade(textMesh, startTime));
    }
    private IEnumerator AlphaFade(TextMeshProUGUI textMesh, float waitTime)
    {
        textMesh.CrossFadeAlpha(122f, 2f, false);
        yield return new WaitForSeconds(waitTime);
        textMesh.CrossFadeAlpha(0, 2f, false);
    }
    public void FadeTextIn(TextMeshProUGUI textMesh, float startTime)
    {
        StartCoroutine(FadeAlphaIn(textMesh, startTime));
    }

    private IEnumerator FadeAlphaIn(TextMeshProUGUI textMesh, float startTime)
    {
        yield return new WaitForSeconds(startTime);
        textMesh.CrossFadeAlpha(1, 0.5f, false);
    }

    public void FadeTextOut(TextMeshProUGUI textMesh, float startTime)
    {
        StartCoroutine(FadeAlphaOut(textMesh, startTime));
    }

    private IEnumerator FadeAlphaOut(TextMeshProUGUI textMesh, float startTime)
    {
        yield return new WaitForSeconds(startTime);
        textMesh.CrossFadeAlpha(0, 0.35f, false);
    }
    public void RollTextCinematics(List<TextMeshProUGUI> textsList, List<bool> textsBools, ref float timeInterval, ref int iterations, float resetTime, float pairedTextTime)
    {
        if (iterations == textsList.Count)
            return;

        timeInterval -= Time.deltaTime;
        if(timeInterval <= 0 && textsBools[iterations] == false) // For Single Text Appearing
        {
            FadeInAndOutFunc(textsList[iterations], 9f);
            iterations += 1;
            timeInterval = 4;
        }
        else if(timeInterval <= 0 && textsBools[iterations] == true) //For Paired Text Appearing
        {
            FadeInAndOutFunc(textsList[iterations], pairedTextTime);
            iterations += 1;
            timeInterval = resetTime;
        }
    }
    private float CalculateDistance(GameObject current, GameObject target)
    {
        float distance = Vector3.Distance(current.transform.position, target.transform.position);
        return distance;
    }
    private void MoveTowardsTarget(GameObject g,GameObject target, float t)
    {
        g.transform.position = Vector3.MoveTowards(g.transform.position, target.transform.position, Time.deltaTime * t);
        g.transform.LookAt(target.transform.position);
        if (g.transform.position == target.transform.position)
        {
            g.SetActive(false);
            return;
        }
    }
    private void PanCamera(GameObject g, GameObject lookTarget, GameObject moveToTarget,  float panTime, float panSpeed, float moveSpeed,bool stopPan, float est)
    {
        float earlyStoppagTime;
        if(stopPan)
        {
            earlyStoppagTime = est;
        }
        else
            earlyStoppagTime = 0;
        if (panTime >= earlyStoppagTime)
        {
            Quaternion toRotation = Quaternion.FromToRotation(transform.forward, lookTarget.transform.position - g.transform.position);
            g.transform.rotation = Quaternion.Lerp(g.transform.rotation, toRotation, panSpeed * Time.deltaTime);
            g.transform.position = Vector3.MoveTowards(g.transform.position, moveToTarget.transform.position, moveSpeed * Time.deltaTime);
        }
    }
    private void CameraOrderOfOperations(List<GameObject> cameraList, int currentCameraIndex)
    {
        ApplyOperations(cameraList, cameraList[currentCameraIndex]);
    }
    private void ApplyOperations(List<GameObject> cameraList, GameObject activatedCamera)
    {
        for (int i = 0; i < cameraList.Count; i++)
        {
            if (!cameraList[i].Equals(activatedCamera))
            {
                cameraList[i].SetActive(false);
            }
            else
            {
                cameraList[i].SetActive(true);
            }
        }
    }

    private void ArrangeTimes(List<float> timeStamps, List<float> shotDurations)  //Call this in start
    {
        for (int i = 0; i < timeStamps.Count; i++)
        {
            if (i != 0)
                shotDurations.Add(timeStamps[i] - timeStamps[i - 1]);
            else
                shotDurations.Add(timeStamps[i]);
        }
    }
    #endregion
}