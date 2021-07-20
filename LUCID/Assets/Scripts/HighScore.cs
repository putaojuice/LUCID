using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private TextMeshProUGUI highScore;
    public static int currScore;

    void Start()
    {
        currScore = 0;
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    void Update ()
    {
        scoreUpdate();
    }

    public static void addDamageScore (int add) 
    {
        currScore += add;
    }

    public static void addDeathScore () 
    {
        currScore += (WaveSpawner.wave * 10);
    }
    
    public void scoreUpdate ()
    {
        score.text = currScore.ToString();

        if (currScore > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", currScore);
            highScore.text = currScore.ToString();
        }
    }

}
