using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class FindTarget : MonoBehaviour {

    public GameObject healthBar;
    public Vector3 targetPos;
    public Camera camera;

 // Use this for initialization
 void Start () {
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }
 
 // Update is called once per frame
 void Update () {
        Vector3 targetPos = camera.transform.position;
        targetPos.z = 0;
        healthBar.transform.LookAt(targetPos);
       
    }
}

