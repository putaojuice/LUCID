using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RelocateSpawner : MonoBehaviour
{
    private GameObject spawner;
    private GameObject playerBase;
    [SerializeField] private NavMeshAgent agent;
    private float currDist;
    private float newDist;

    //public GridController gridController;
    // Start is called before the first frame update
    void Start()
    {
        playerBase = GameObject.Find("Base");
        spawner = GameObject.FindGameObjectWithTag("Spawner");
        currDist = Vector3.Distance(spawner.transform.position, playerBase.transform.position);
        newDist = Vector3.Distance(transform.position, playerBase.transform.position);

        if (currDist < newDist)
        {
            Invoke("PathCalculation", 0.2f);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    void PathCalculation()
    {
        NavMeshPath path = new NavMeshPath();

        //NavMesh.CalculatePath(transform.position, playerBase.transform.position, NavMesh.AllAreas, path);
        agent.CalculatePath(playerBase.transform.position, path);
        Debug.Log(path.status);

        if (path.status == NavMeshPathStatus.PathComplete)
        {
            spawner.transform.position = gameObject.transform.position;
        }

        Destroy(gameObject);
    }
}
