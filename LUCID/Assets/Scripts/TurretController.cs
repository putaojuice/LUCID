using UnityEngine;
using UnityEngine.AI;

public class TurretController : MonoBehaviour
{
    public static TurretController turretController;

    private GameObject turretPreviewPrefab;
    [SerializeField] private Camera cam;
	[SerializeField] private LayerMask layer;
    [SerializeField] private GameObject playerBase;
    [SerializeField] private NavMeshAgent agent;
    private bool isBlockingPath = false;
    private TurretLevel turretSelected;
    private TurretBase turretBase;
    [SerializeField] private TurretUI turretUI;
    
    void Awake () 
    {
        turretController = this;
    }

    void Update() 
    {
        if (TurretBase.IsBuilding())
        {
            GenerateRay();
        }    
    }

    public bool BaseAvailable 
    { 
        get 
        { 
            return turretSelected != null; 
        } 
    }

    public void SelectBase (TurretBase tb)
    {
        if (turretBase == tb)
        {
            DeselectBase();
            return;
        }
        
        turretBase = tb;
        turretSelected = null;
        turretUI.SetTarget(tb);
    }

    public void DeselectBase ()
    {
        turretBase = null;
        turretUI.Hide();
    }

    public void BuildTurret (TurretLevel turret) 
    {
        turretSelected = turret;
        DeselectBase();
    }

    public TurretLevel GetTurret ()
    {
        return turretSelected;
    }

    public void NewBuild(GameObject obj)
    {
        turretPreviewPrefab = Instantiate(obj, Vector3.zero, Quaternion.identity);
    }

    private void GenerateRay()
	{
		Ray ray = cam.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit, layer))
		{
            if (hit.transform.CompareTag("GridFloor"))
            {
                GameObject go = hit.transform.gameObject;
                PositionObj(go.transform.position);
                // PositionObj(hit.point);
                turretPreviewPrefab.GetComponent<TurretPreview>().BuildableColor();
                PathCalculation();
            }
			    
            else
            {
                PathCalculation();
                turretPreviewPrefab.GetComponent<TurretPreview>().UnbuildableColor();
                // Debug.Log("mouse not on grid");
            }
		}
	}

	private void PositionObj(Vector3 position)
	{
		int x = Mathf.RoundToInt(position.x);
		int z = Mathf.RoundToInt(position.z);
        turretPreviewPrefab.transform.position = position + new Vector3(0f, 0.5f, 0f);
        // turretPreviewPrefab.transform.position = new Vector3(x + 0.5f, 1.5f, z + 0.5f);
	}

    public void DestroyPreview()
    {
        Destroy(turretPreviewPrefab);
        turretPreviewPrefab = null;
    }

    private void PathCalculation()
    {
        NavMeshPath path = new NavMeshPath();
        agent.CalculatePath(playerBase.transform.position, path);
        // Debug.Log(path.status);

        if (path.status == NavMeshPathStatus.PathComplete)
        {
            // Debug.Log(path.status);
            turretPreviewPrefab.GetComponent<TurretPreview>().BuildableColor();
            isBlockingPath = false;
        }
        else 
        {
            // Debug.Log(path.status);
            turretPreviewPrefab.GetComponent<TurretPreview>().UnbuildableColor();
            isBlockingPath = true;
        }
    }

    public bool IsBlockingPath()
    {
        return isBlockingPath;
    }
}

