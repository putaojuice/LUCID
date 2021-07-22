using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform enemyTarget;

    [SerializeField] private float bulletSpeed = 5f;

    [SerializeField] private float bulletDamage = 10f;
    [SerializeField] private ParticleSystem explosion;

    // Update is called once per frame
    void Update()
    {
        if (enemyTarget != null)
        {
            Vector3 destination = enemyTarget.position - gameObject.transform.position;
            float bulletTravelPerFrame = bulletSpeed * Time.deltaTime;
            
            if (destination.magnitude <= bulletTravelPerFrame) 
            {
                TargetHit();
                return;
            }
            else
            {
                gameObject.transform.Translate(destination.normalized * bulletTravelPerFrame, Space.World);
            }
        } 
        else 
        {
            Destroy(gameObject);
            return;
        }
    }
    
    public void FindTarget(Transform target)
    {
        enemyTarget = target;
    }

    void TargetHit()
    {
        Instantiate(explosion, transform.position, transform.rotation);
        enemyTarget.gameObject.GetComponent<EnemyController>().Damaged(bulletDamage);
        Debug.Log("Hit");

        Destroy(gameObject);
    }

    public float getBulletDamage()
    {
        return bulletDamage;
    }
}
