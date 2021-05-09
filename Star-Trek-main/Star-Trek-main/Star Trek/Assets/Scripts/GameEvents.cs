using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using TMPro;

public partial class GameEvents : MonoBehaviour
{
    public static GameEvents Instance
    {
        get;
        private set;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    #region Delegates & Events
    public delegate void GameObjectDel(GameObject g,GameObject transform, float t);
    public event GameObjectDel onMoveToTarget;

    public delegate void GameObjectFloatDel(GameObject g, float t);
    public event GameObjectFloatDel onFadeImageIn;
    public event GameObjectFloatDel onFadeImageOut;

    public delegate void TextDel(TextMeshProUGUI text, float startTime);
    public event TextDel onFadeTextIn;
    public event TextDel onFadeTextOut;
    public event TextDel onFadeInAndOut;

    public delegate void TextCinematicDel(List<TextMeshProUGUI> textsArray, List<bool> textBools, ref float timeInterval, ref int iterations, float resetTime);
    public event TextCinematicDel onRollCinematics;
    #endregion

    #region Events Functions
    public void MoveToTarget(GameObject g,GameObject transform, float t)
    {
        if(onMoveToTarget != null)
        {
            onMoveToTarget(g,transform, t);
        }
    }
    public void RollTextCinematicsFunction(List<TextMeshProUGUI> textsArray, List<bool> textBools, ref float timeInterval, ref int iterations, float resetTime)
    {
        if(onRollCinematics != null)
        {
            onRollCinematics(textsArray,textBools, ref timeInterval, ref iterations,resetTime);
        }
    }
    public void FadeTextInFunction(TextMeshProUGUI text, float startTime)
    {
        if(onFadeTextIn != null)
        {
            onFadeTextIn(text,startTime);
        }
    }
    public void FadeTextOutFunction(TextMeshProUGUI text, float startTime)
    {
        if (onFadeTextOut != null)
        {
            onFadeTextOut(text, startTime);
        }
    }
    public void FadeInAndOutFunc(TextMeshProUGUI text, float startTime)
    {
        if(onFadeInAndOut != null)
        {
            onFadeInAndOut(text,startTime);
        }
    }
    public void FadeImageIn(GameObject g, float time)
    {
        if(onFadeImageIn != null)
        {
            onFadeImageIn(g,time);
        }
    }
    public void FadeImageOut(GameObject g,float time)
    {
        if (onFadeImageOut != null)
        {
            onFadeImageOut(g,time);
        }
    }
  
    #endregion
}
