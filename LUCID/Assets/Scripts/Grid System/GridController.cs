using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    public Camera cam;
	public LayerMask layer;
	public GridUI gridUI;
	private GameObject previewPrefab;
	private GridTile gridTile;
	private bool isBuilding = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
	{
		BuildLogic();
	}

	public void BuildLogic()
	{
		if (Input.GetMouseButton(0) && isBuilding && gridTile.Buildable())
		{
			BuildIt();
		}
		
		if (Input.GetMouseButton(1) && isBuilding)
		{
			StopBuild();
		}

		if (Input.GetKeyDown(KeyCode.R) && isBuilding)
		{
			previewPrefab.transform.Rotate(0f, 90f, 0f);
			previewPrefab.GetComponent<GridTile>().Rotate();
		}

		if (isBuilding)
		{
			GenerateRay();
		}
	}

	public void NewBuild(GameObject obj)
	{
		previewPrefab = Instantiate(obj, Vector3.zero, Quaternion.identity);
		gridTile = previewPrefab.GetComponent<GridTile>();
		isBuilding = true;

	}

	private void StopBuild()
	{
		Destroy(previewPrefab);
		previewPrefab = null;
		gridTile = null;
		isBuilding = false;
        gridUI.OffPanel();
	}

	private void BuildIt()
	{
		gridTile.Build();
		StopBuild();
	}

	private void GenerateRay()
	{
		Ray ray = cam.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit, layer))
		{
			PositionObj(hit.point);
		}
	}

	private void PositionObj(Vector3 position)
	{
		int x = Mathf.RoundToInt(position.x);
		int z = Mathf.RoundToInt(position.z);
		if (previewPrefab.GetComponent<GridTile>().GetRotateState())
		{
			previewPrefab.transform.position = new Vector3(x + 0.5f, 1f, z);
		}
		else
		{
			previewPrefab.transform.position = new Vector3(x, 1f, z + 0.5f);
		}
		
	}

	public bool GetIsBuilding()
	{
		return isBuilding;
	}


}
