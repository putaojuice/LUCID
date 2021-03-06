using UnityEngine;
using UnityEngine.EventSystems;
public class TurretBase : MonoBehaviour
{
    [SerializeField] private Color hoverColor;
    [SerializeField] private GameObject turret;
    [SerializeField] private Color origColor;
    private Renderer rend; 
    [SerializeField] private Vector3 positionOffset;
    TurretController turretController;
    [SerializeField] private TurretLevel turretLevel;
    [SerializeField] private DeckManager deckManager;
    public int isUpgraded = 0;
    public static bool building = false;

    void Start () 
    {
        deckManager = GameObject.Find("DeckManager").GetComponent<DeckManager>();
        rend = GetComponent<Renderer>();
        origColor = rend.material.color;
        turretController = TurretController.turretController;
    }

    public Vector3 GetBaseCoord ()
	{
		return transform.position + positionOffset;
	}

    void OnMouseDown ()
    {
        if (EventSystem.current.IsPointerOverGameObject()) 
            return;

        if (turret != null)
        {
            turretController.SelectBase(this);
            return; 
        }

        if (!turretController.BaseAvailable)
            return;
        
        if (building)
            if (turretController.IsBlockingPath())
            {
                return;
            }
            else
            {
                BuildTurret(turretController.GetTurret());
                turretController.DeselectBase();
                turretController.DestroyPreview();
                deckManager.ShowHandUI();
            }
    }

    void BuildTurret (TurretLevel tl)
    {
        GameObject turret1 = (GameObject) Instantiate(tl.prefab, GetBaseCoord(), Quaternion.identity);
        turret = turret1;
        turretLevel = tl;
        EndBuild();
        Debug.Log("Turret Built!");
    }

    public void UpgradeTurret ()
    {
        if (isUpgraded == 0)
        {     
            DestroyTurret();
            
            GameObject turret1 = (GameObject) Instantiate(turretLevel.upgradedPrefab, GetBaseCoord(), Quaternion.identity);
            turret = turret1;
            isUpgraded = 1;

        } else if (isUpgraded == 1)
        {
            DestroyTurret();
            
            GameObject turret1 = (GameObject) Instantiate(turretLevel.upgradedPrefab2, GetBaseCoord(), Quaternion.identity);
            turret = turret1;
            isUpgraded = 2;

        }
    }

    public void DestroyTurret()
    {
        Destroy(turret);
    }

    void OnMouseEnter ()
    {
        if (!building)
        {
            if (EventSystem.current.IsPointerOverGameObject()) 
                return;

            if (!turretController.BaseAvailable)
                return;

        } else {
            rend.material.color = hoverColor;
        }
    }


    void OnMouseExit () 
    {
        rend.material.color = origColor;
    }

    public static void BuildingMode()
    {
        building = true;
    }

    public static void EndBuild()
    {
        building = false;
    }

    public static bool IsBuilding()
    {
        return building;
    }

    public string TurretTag()
    {
        return turret.tag.ToString();
    }
}
