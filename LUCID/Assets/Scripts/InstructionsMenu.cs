using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InstructionsMenu : MonoBehaviour
{
    [SerializeField] private GameObject[] images;
    [SerializeField] private GameObject[] circles;
    [SerializeField] private Color selectedColor;
    [SerializeField] private Color notSelectedColor;
    private int pointer;

    // Start is called before the first frame update
    void Start()
    {
        pointer = 0;
    }

    public void NextPage()
    {
        if (pointer < images.Length-1)
        {
            images[pointer].SetActive(false);
            circles[pointer].GetComponent<Image>().color = notSelectedColor;
            pointer++;
            images[pointer].SetActive(true);
            circles[pointer].GetComponent<Image>().color = selectedColor;
        }
    }

    public void PreviousPage()
    {
        if (pointer > 0)
        {
            images[pointer].SetActive(false);
            circles[pointer].GetComponent<Image>().color = notSelectedColor;
            pointer--;
            images[pointer].SetActive(true);
            circles[pointer].GetComponent<Image>().color = selectedColor;
        }
    }

    public void OpenInstructions()
    {
        gameObject.SetActive(true);
        images[pointer].SetActive(false);
        circles[pointer].GetComponent<Image>().color = notSelectedColor;
        pointer = 0;
        images[pointer].SetActive(true);
        circles[pointer].GetComponent<Image>().color = selectedColor;

    }

    public void CloseInstructions()
    {
        gameObject.SetActive(false);
    }
}
