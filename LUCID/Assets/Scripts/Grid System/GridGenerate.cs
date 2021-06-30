using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerate : MonoBehaviour
{
    [Header("Grid Parameters")]
    public int xVal;
    public int zVal;
    private List<GameObject> grid = new List<GameObject>();

    [Header("Block Parameters")]
    public GameObject blockPrefab;
    public float blockSize;

    public GridController gridController;

    public GameObject baseGrid;

    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid();
        baseGrid.transform.position = new Vector3(xVal/2, 1, zVal/2);
    }

    void GenerateGrid() 
    {
        for (int x = 0; x < xVal; x++)
		{
            for (int z = 0; z < zVal; z++)
			{
                Vector3 spawnPos = new Vector3(x + blockSize / 2, 0, z + blockSize / 2);
                GameObject block = (GameObject) Instantiate(blockPrefab, spawnPos, transform.rotation);
                grid.Add(block);
                block.GetComponent<MeshRenderer>().enabled = false;
                block.GetComponent<GridBase>().SetGridController(gridController);
                block.transform.SetParent(transform);
			}
		}

        Debug.Log("Generated grid of size " + xVal + ", " + zVal);
    }

    private void OnDrawGizmos()
	{
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireCube(transform.position, transform.localScale);
	}

    public void ToggleGrid(bool b)
    {
        foreach(var obj in grid)
        {
            obj.GetComponent<MeshRenderer>().enabled = b;
        }
    }
}
