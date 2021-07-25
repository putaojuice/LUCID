using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [Header("Enemy Target Attributes")]
    private string enemyTag = "Enemy";
    [SerializeField] private Transform enemyTarget;
    
    [Header("Tower Attributes")]
    [SerializeField] private float range;
    [SerializeField] private float fireRate = 1f;
    [SerializeField] private float fireCountdown = 0f;
    
    [Header("Turret Gun Attributes")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePosition;
    [SerializeField] private GameObject rotationObject;
    [SerializeField] private float rotationSpeed = 5f;
    
    

    // Start is called before the first frame update
    void Start()
    {
        // Invoke the method FindTarget at 0.5s interval throughout runtime
        InvokeRepeating("FindTarget", 0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyTarget == null) 
        {
            return;
        } 
        else
        {
            TargetLockOn();
            
            if (fireCountdown <= 0f) 
            {
                Shoot();
                fireCountdown = 1f / fireRate; 
            }

            fireCountdown -= Time.deltaTime;
        }
        
    }
    
    void Shoot() 
    {
        GameObject bulletGameObject = (GameObject) Instantiate(bulletPrefab, firePosition.position, firePosition.rotation);
        Bullet bullet = bulletGameObject.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.FindTarget(enemyTarget);
        } 
    
        Debug.Log("Bullet fired!");
    }

    void TargetLockOn()
    {
        // Target lock on
        Vector3 direction = enemyTarget.position - transform.position;
        // Quaternion is the way unity deals with rotation angles, eulerAngles convert Quaternion to Vector3
        Vector3 rotation = Quaternion.Lerp(rotationObject.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotationSpeed).eulerAngles;
        rotationObject.transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void FindTarget()
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

        // Only aim enemies that hasn't die yet
        if (nearestEnemy != null && shortestDist <= range && nearestEnemy.GetComponent<EnemyController>().GetDeath() == false) 
        {
            enemyTarget = nearestEnemy.transform;
        } 
        else 
        {
            enemyTarget = null;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
