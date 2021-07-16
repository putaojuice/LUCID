using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    // SerializeField makes private variables visible in the inspector
    [SerializeField] private NavMeshAgent enemy;
    [SerializeField] private GameObject Base;
    [SerializeField] private Material destructionMat;
    [SerializeField] private float enemyHP;
    private float startHP;
    private bool enemyDeath = false;

    public float enemyDamage = 50f;

    public Image healthBar;
    
    // Start is called before the first frame update
    void Start()
    {
        // Initialise Base
        Base = GameObject.Find("Base");

        // Enemy will navigate to the Base
        enemy.SetDestination(Base.transform.position);

        // Initialise enemy HP based on which wave it is right now. Enemy HP increase by 10 every 5 rounds.
        startHP = 10f + Mathf.Ceil(WaveSpawner.wave / 5) * 10f;
        enemyHP = startHP;
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
            healthBar.fillAmount = enemyHP / startHP;
             
            if (enemyHP <= 0f)
            {
                enemyDeath = true;
                EnemyDestroy();
            }
        }
    }

    public bool GetDeath()
	{
        return enemyDeath;
	}

    // Enemy self destruction method
	private void EnemyDestroy()
	{
        // Stop enemy movement
        //enemy.SetDestination(transform.position);
        gameObject.GetComponent<NavMeshAgent>().enabled = false;
        WaveSpawner.numOfEnemyAlive--;
        if (gameObject != null) {
            // Play enemy dissolve animation from dissolve shader
            StartCoroutine(PlayDissolve(1f));

            // Destroy after 1 sec delay
            Destroy(gameObject, 1.0f);
            
            Debug.Log(WaveSpawner.numOfEnemyAlive);

            if (WaveSpawner.numToSpawn == 0)
			{
                WaveSpawner.waveEnd = true;
			}
        }
	}
    void BaseHit()
    {        
        Base.GetComponent<BaseController>().Damaged(enemyDamage);
    }

	// When enemy trigger the base's collider
    private void OnTriggerEnter(Collider other)
	{
        BaseHit();
        enemyDeath = true;
        EnemyDestroy();
	}

}
