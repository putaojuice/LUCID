using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InstructionsMenu : MonoBehaviour
{
    [SerializeField] private GameObject[] images;
    private int pointer;

    // Start is called before the first frame update
    void Start()
    {
        pointer = 0;
        gameObject.SetActive(false);
    }

    public void NextPage()
    {
        if (pointer < images.Length-1)
        {
            images[pointer].SetActive(false);
            pointer++;
            images[pointer].SetActive(true);
        }
    }

    public void PreviousPage()
    {
        if (pointer > 0)
        {
            images[pointer].SetActive(false);
            pointer--;
            images[pointer].SetActive(true);
        }
    }

    public void OpenInstructions()
    {
        gameObject.SetActive(true);
    }

    public void CloseInstructions()
    {
        gameObject.SetActive(false);
    }
}
