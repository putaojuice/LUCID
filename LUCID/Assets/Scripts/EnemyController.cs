using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    // SerializeField makes private variables visible in the inspector
    [SerializeField] NavMeshAgent enemy;
    [SerializeField] GameObject Base;
    [SerializeField] Material destructionMat;
    [SerializeField] float enemyHP = 20f;
    private bool enemyDeath = false;
    
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
        if (enemyDeath) 
        {
            enemyDeath = false;
            EnemyDestroy();
        }
    }

    IEnumerator PlayDissolve(float duration) 
    {
        float timeElapsed = 0f;
        gameObject.GetComponent<MeshRenderer>().material = destructionMat;
        gameObject.GetComponent<Renderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;

        while (timeElapsed <= duration)
        {
            timeElapsed += Time.deltaTime;
            gameObject.GetComponent<MeshRenderer>().material.SetFloat("_tConstant", Mathf.Lerp(1f, 0f, timeElapsed / duration));
            yield return new WaitForEndOfFrame();
        }
    }

    public void Damaged(float damage)
    {
        if (enemyDeath == false) {
            enemyHP -= damage;
            
            if (enemyHP <= 0f)
            {
                enemyDeath = true;
            }
        }
    }

    // Enemy self destruction method
	private void EnemyDestroy()
	{
        // Stop enemy movement
        //enemy.SetDestination(transform.position);
        gameObject.GetComponent<NavMeshAgent>().enabled = false;

        if (gameObject != null) {
            // Play enemy dissolve animation from dissolve shader
            StartCoroutine(PlayDissolve(1f));

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
