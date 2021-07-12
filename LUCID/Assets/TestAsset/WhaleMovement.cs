using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhaleMovement : MonoBehaviour
{
    [SerializeField] private Transform[] waypoint;
    private int size;
    private int pointer = 0;
    private Transform currTarget;

    public ParticleSystem ripple;

    private float timer = 1f;

    // Start is called before the first frame update
    void Start()
    {
        size = waypoint.Length;
        Next();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation
            (Vector3.RotateTowards(transform.forward, transform.position - currTarget.position, Time.deltaTime * 30f, 0.0f));
        transform.position = Vector3.MoveTowards(transform.position, currTarget.position, Time.deltaTime * 1f);

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            ParticleSystem particle = Instantiate(ripple, transform.position, Quaternion.LookRotation(new Vector3(0,90,0)));
            timer = 1f;
        }
    }

    private void Next()
    {
        currTarget = waypoint[pointer];
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Waypoint")
        {
            Debug.Log("Waypoint " + pointer + " reached");

            if (pointer >= size - 1)
            {
                pointer = 0;
                Next();
            }
            else
            {
                pointer++;
                Next();
            }
        }
    }
}
