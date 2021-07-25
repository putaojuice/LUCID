using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsMenu : MonoBehaviour
{
    [SerializeField] private GameObject creditsPanel;
    [SerializeField] private GameObject creditsText;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject decorations;

    private void Awake() 
    {
        creditsText.transform.position = new Vector3(25, 18, 0);    
    }

    private void Update() 
    {
        creditsText.transform.position += new Vector3(0, 0, 5 * Time.deltaTime);

        if (creditsText.transform.position.z >= 145f)
        {
            creditsText.transform.position = new Vector3(25, 18, 0);
        }
    }

    public void OffCredits()
    {
        creditsPanel.SetActive(false);
        mainMenu.SetActive(true);
        decorations.SetActive(true);
        creditsText.transform.position = new Vector3(25, 18, 0);
    }

    public void OnCredits()
    {
        creditsPanel.SetActive(true);
        mainMenu.SetActive(false);
        decorations.SetActive(false);
    }
}
