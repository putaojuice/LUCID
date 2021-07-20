using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class FindTarget : MonoBehaviour {

    public GameObject healthBar;
    public Vector3 targetPos;
    public Camera gameCamera;

 // Use this for initialization
 void Start () {
        gameCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }
 
 // Update is called once per frame
 void Update () {
        Vector3 targetPos = gameCamera.transform.position;
        targetPos.z = 0;
        healthBar.transform.LookAt(targetPos);
       
    }
}

