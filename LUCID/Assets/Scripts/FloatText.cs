using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatText : MonoBehaviour
{
    public float DestructTime = 1.5f;
    void Start()
    {
        Destroy(gameObject, DestructTime);
    }
}
 