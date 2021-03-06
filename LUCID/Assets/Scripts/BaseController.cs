using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BaseController : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    [SerializeField] private float baseHP;
    private float startHP;
    private bool baseDestroyed = false;


    // Start is called before the first frame update
    void Start()
    {
        // Initialise base HP.
        startHP = 10f;
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
            SceneManager.LoadScene("Defeat");
        }
	}
}
