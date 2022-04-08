using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTime : MonoBehaviour
{
    public int lifeSpan=2;
    void Start()
    {
        Destroy(gameObject,lifeSpan);
    }

}