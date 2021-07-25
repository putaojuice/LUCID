using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradePoints : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI points;
    public static int upgradePoints;

    void Start()
    {
        upgradePoints = 0;
        points.text = upgradePoints.ToString();
    }

    void Update ()
    {
        points.text = upgradePoints.ToString();
    }

    public static void Add () 
    {
        upgradePoints++;
    }

    public static void Minus (int n)
    {
        upgradePoints -= n;
    }

}
