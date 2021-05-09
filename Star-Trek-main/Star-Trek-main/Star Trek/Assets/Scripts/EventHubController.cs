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
    public void RollTextCinematics(List<TextMeshProUGUI> textsList, List<bool> textsBools, ref float timeInterval, ref int iterations, float resetTime)
    {
        if (iterations == textsList.Count)
            return;

        timeInterval -= Time.deltaTime;
        if(timeInterval <= 0 && textsBools[iterations] == false) // For Single Text Appearing
        {
            FadeInAndOutFunc(textsList[iterations], 9f);
            iterations += 1;
            timeInterval = resetTime;
        }
        else if(timeInterval <= 0 && textsBools[iterations] == true) //For Paired Text Appearing
        {
            FadeInAndOutFunc(textsList[iterations], 5f);
            iterations += 1;
            timeInterval = 8.5f;
        }
    }
    private void MoveTowardsTarget(GameObject g,GameObject target, float t)
    {
        g.transform.position = Vector3.MoveTowards(g.transform.position, target.transform.position, Time.deltaTime * t);
        g.transform.LookAt(target.transform.position);
        if (g.transform.position == target.transform.position)
            return;
    }
    #endregion
}