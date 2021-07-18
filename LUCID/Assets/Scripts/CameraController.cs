using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float speed = 15f;
    [SerializeField] private float borderSize = 15f;
    [SerializeField] private float clampVal = 20f;
    private Vector3 pos;
    

    void Update()
    {
        CameraControl();
    }

    private void CameraControl()
	{
        pos = transform.position;

        if (Input.mousePosition.y >= Screen.height - borderSize)
		{
            pos.z += speed * Time.deltaTime;
		}
        if (Input.mousePosition.y <= borderSize)
        {
            pos.z -= speed * Time.deltaTime;
        }
        if (Input.mousePosition.x <= borderSize)
        {
            pos.x -= speed * Time.deltaTime;
        }
        if (Input.mousePosition.x >= Screen.width - borderSize)
        {
            pos.x += speed * Time.deltaTime;
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        pos.y += scroll * speed * 150f * Time.deltaTime;
        
        pos.y = Mathf.Clamp(pos.y, 10, 20);
        pos.x = Mathf.Clamp(pos.x, 0, clampVal);
        pos.z = Mathf.Clamp(pos.z, 0, clampVal);

        transform.position = pos;
    }
}
