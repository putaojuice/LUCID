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



    IEnumerator PlayDissolve(float duration) 
    {
        float timeElapsed = 0f;
        Material newMaterial = Instantiate(destructionMat);
        gameObject.GetComponent<MeshRenderer>().material = destructionMat;

        while (timeElapsed <= duration)
        {
            timeElapsed += Time.deltaTime;
            gameObject.GetComponent<MeshRenderer>().material.SetFloat("_tConstant", Mathf.Lerp(1f, 0f, timeElapsed / duration));
            yield return new WaitForEndOfFrame();
        }
    }

    // Enemy self destruction method
	private void EnemyDestroy()
	{
        if (gameObject != null) {
            StartCoroutine(PlayDissolve(1.5f)); 
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
