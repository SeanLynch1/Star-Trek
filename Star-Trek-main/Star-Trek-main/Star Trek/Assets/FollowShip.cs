using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowShip : MonoBehaviour
{
    public GameObject target;
    public float speed;
    // Update is called once per frame
    void Update()
    {
        GameEvents.Instance.MoveToTarget(gameObject,target, speed * Time.deltaTime);
    }
}
