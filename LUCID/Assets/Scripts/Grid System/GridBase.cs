using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBase : MonoBehaviour
{
    public Color highlightColor;
    public Color origColor;

    private Renderer rend;
    private bool selected;
    public GridController gridController;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        origColor = rend.material.color;
        selected = false;
    }

    public void OnMouseEnter()
	{
        if (!gridController.GetIsBuilding())
		{
            selected = true;
            Selection();
        }
	}

	public void OnMouseExit()
	{
        if (!gridController.GetIsBuilding())
        {
            selected = false;
            Selection();
        }
    }

    public void Selection()
	{
        if (selected)
		{
            rend.material.color = highlightColor;
		}
        else
		{
            rend.material.color = origColor;
        }
	}

    public void SetGridController(GridController controller)
	{
        gridController = controller;
	}

}
