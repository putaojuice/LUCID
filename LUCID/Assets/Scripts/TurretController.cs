using UnityEngine;

public class TurretController : MonoBehaviour
{
    public static TurretController turretController;

    void Awake () 
    {
        turretController = this;
    }

    private TurretLevel turretSelected;
    private TurretBase turretBase;
    public TurretUI turretUI;
    
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
}

