using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public NavMeshAgent enemy;
    public GameObject Base;

    public Material destructionMat;
    
    // Start is called before the first frame update
    void Start()
    {
        // Instantiate Base
        Base = GameObject.Find("Base");

        // enemy will navigate to the Base
        enemy.SetDestination(Base.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    // Enemy self destruction method
	private void EnemyDestroy()
	{
        if (gameObject != null) {
            //gameObject.GetComponent<MeshRenderer>().material = destructionMat;
            
            // Destroy after 1 sec delay
            Destroy(gameObject, 1.0f);
        }
	}

	// When enemy trigger the base's collider
    private void OnTriggerEnter(Collider other)
	{
        Debug.Log("Enemy destroyed");
        EnemyDestroy();
	}
}
