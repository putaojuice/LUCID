using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseController : MonoBehaviour
{
    public Image healthBar;
    [SerializeField] private float baseHP;
    private float startHP;
    private bool baseDestroyed = false;


    // Start is called before the first frame update
    void Start()
    {
        // Initialise base HP.
        startHP = 500f;
        baseHP = startHP;
    }

    public void Damaged(float damage)
    {
        if (baseDestroyed == false) {
            baseHP -= damage;
            healthBar.fillAmount = baseHP / startHP;
             
            if (baseHP <= 0f)
            {
                baseDestroyed = true;
                GameOver();
            }
        }
    }

    // Game Over.
	private void GameOver()
	{
        if (gameObject != null) {
            Destroy(gameObject);
            WaveSpawner.waveEnd = true;
            //Play end screen.
        }
	}
}
