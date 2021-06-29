using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public string enemyTag = "Enemy";
    public Transform target;
    public float range;
    
    public GameObject rotationObject;
    public float rotationSpeed = 5f;
    
    

    // Start is called before the first frame update
    void Start()
    {
        // Invoke the method FindTarget at 0.5s interval throughout runtime
        InvokeRepeating("FindTarget", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) 
        {
            return;
        } 
        else
        {
            TargetLockOn ();
        }
        
    }

    void TargetLockOn ()
    {
        // Target lock on
        Vector3 direction = target.position - transform.position;
        // Quaternion is the way unity deals with rotation angles, eulerAngles convert Quaternion to Vector3
        Vector3 rotation = Quaternion.Lerp(rotationObject.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotationSpeed).eulerAngles;
        rotationObject.transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void FindTarget ()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        
        // Initialised as infinity when shortest distance to nearest enemy is not found yet
        float shortestDist = Mathf.Infinity;
        // Initialised as null when nearest enemy is not found yet 
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies) 
        {
            float distToEnemy = Vector3.Distance(transform.position,  enemy.transform.position); 
            if (distToEnemy < shortestDist) 
            {
                 shortestDist = distToEnemy;
                 nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDist <= range) 
        {
            target = nearestEnemy.transform;
        } 
        
        else 
        {
            target = null;
        }
    }

    void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
