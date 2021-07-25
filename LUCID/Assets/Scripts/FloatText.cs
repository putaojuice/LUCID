using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatText : MonoBehaviour
{
    [SerializeField] private float DestructTime = 1.5f;
    void Start()
    {
        Destroy(gameObject, DestructTime);
    }
}
 