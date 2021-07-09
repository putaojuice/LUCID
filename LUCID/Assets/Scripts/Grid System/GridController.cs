using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GridController : MonoBehaviour
{
    public Camera cam;
	public LayerMask layer;
	public GridUI gridUI;
	private GameObject previewPrefab;
	private GridTile gridTile;
	private bool isBuilding = false;
	private bool onUI = false;

	public NavMeshSurface surf;

    // Start is called before the first frame update
    void Start()
    {
		// BuildNavMesh on start up
		surf = GetComponent<NavMeshSurface>();
		surf.BuildNavMesh();
    }

    private void Update()
	{
		BuildLogic();
	}

	public void BuildLogic()
	{
		// Toggle build mode with "B" key -> on/off the UI pannel as well
		// if (Input.GetKeyDown(KeyCode.B))
		// {
		// 	if (onUI)
		// 	{
		// 		onUI = false;
		// 		StopBuild();
		// 	}
		// 	else
		// 	{
		// 		onUI = true;
		// 		gridUI.EnableUI();
		// 	}
		// }

		if (Input.GetMouseButton(0) && isBuilding && gridTile.GetBuildable())
		{
			BuildIt();
		}
		
		if (Input.GetMouseButton(1) && isBuilding)
		{
			StopBuild();
		}

		// Rotation feature for the preview tile that player is going to build
		if (Input.GetKeyDown(KeyCode.R) && isBuilding)
		{
			previewPrefab.transform.Rotate(0f, 90f, 0f);
			previewPrefab.GetComponent<GridTile>().Rotate();
		}

		// Calls method GenerateRay in order for player to place the tile
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
		onUI = false;
        gridUI.DisableUI();
	}

	private void BuildIt()
	{
		gridTile.Build();
		
		// update navmesh data in run time
		surf.UpdateNavMesh(surf.navMeshData);
		StopBuild();
	}

	// This method casts a ray from player's mouse to the position on the screen in order for positioning and snapping of tile to work
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
