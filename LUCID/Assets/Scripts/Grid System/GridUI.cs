using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridUI : MonoBehaviour
{
    [SerializeField] private GameObject buildingUI;
    [SerializeField] private GridController gridController;
    [SerializeField] private GridGenerate gridGenerate;
    private bool buildMode = false;

    public void TogglePanel()
	{
		buildingUI.SetActive(buildMode);
	}

    public void DisableUI()
    {
        buildMode = false;
        buildingUI.SetActive(buildMode);
        gridGenerate.ToggleGrid(buildMode);
    }

    public void EnableUI()
    {
        buildMode = !buildMode;
        TogglePanel();
        gridGenerate.ToggleGrid(buildMode);
    }
}
