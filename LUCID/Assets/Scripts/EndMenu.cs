using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    public void ReturnToMain()
    {
        // Return to main menu
        SceneManager.LoadScene("MainMenu2");
    }
}
