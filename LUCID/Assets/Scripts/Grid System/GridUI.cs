using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridUI : MonoBehaviour
{
    public GameObject buildingUI;
    public GridController gridController;
    private bool buildMode = false;

    public GridGenerate gridGenerate;

    void Update() 
    {
        BuildMode();
    }

    public void BuildMode()
    {
        if(Input.GetKeyDown(KeyCode.B))
        {
            buildMode = !buildMode;
            TogglePanel();
            gridGenerate.ToggleGrid(buildMode);
        }
    }

    public void Building(GameObject obj)
	{
        gridController.NewBuild(obj);
        TogglePanel();
	}

    public void TogglePanel()
	{
        buildingUI.SetActive(buildMode);
	}

    public void OffPanel()
    {
        buildMode = false;
        buildingUI.SetActive(buildMode);
        gridGenerate.ToggleGrid(buildMode);
    }
}
