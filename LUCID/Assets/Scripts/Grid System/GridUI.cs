using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridUI : MonoBehaviour
{
    public GameObject buildingUI;
    public GridController gridController;
    public GridGenerate gridGenerate;
    private bool buildMode = false;

    public void Building(GameObject obj)
	{
        gridController.NewBuild(obj);
        TogglePanel();
	}

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
        /*if (!buildMode) 
        {
            buildMode = !buildMode;
            TogglePanel();
            gridGenerate.ToggleGrid(buildMode);
        }
        else
		{
            buildMode = !buildMode;
            TogglePanel();
            gridGenerate.ToggleGrid(buildMode);
		}*/

        buildMode = !buildMode;
        TogglePanel();
        gridGenerate.ToggleGrid(buildMode);
    }
}
