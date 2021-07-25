using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TurretUI : MonoBehaviour
{
    [SerializeField] private GameObject ui;
    [SerializeField] private TurretBase target;
    [SerializeField] private TextMeshProUGUI upgradeStatus;
    [SerializeField] private Button upgradeButton;
    [SerializeField] private GameObject NotEnoughPoints;

    public void SetTarget (TurretBase target)
    {
        this.target = target;

        transform.position = target.GetBaseCoord();

        if (target.isUpgraded == 0 || target.isUpgraded == 1)
		{
			upgradeButton.interactable = true;
		
        } else 
		{
            Debug.Log("No more upgrades.");
			upgradeButton.interactable = false;
		}

        ui.SetActive(true);
    }

    public void Hide ()
    {
        ui.SetActive(false);
    }

    public void Unhide ()
    {
        ui.SetActive(true);
    }

    public void Upgrade ()
    {
        if (UpgradePoints.upgradePoints > 2 && target.TurretTag() == "Tier1Turret")
        {
            target.UpgradeTurret();
            Debug.Log("Turret Upgraded.");
            TurretController.turretController.DeselectBase();
            UpgradePoints.Minus(3);
        } 
        else if (UpgradePoints.upgradePoints > 4 && target.TurretTag() == "Tier2Turret")
        {
            target.UpgradeTurret();
            Debug.Log("Turret Upgraded.");
            TurretController.turretController.DeselectBase();
            UpgradePoints.Minus(5);
        }
        else 
        {
            Debug.Log("Not enough upgrade points");
            ShowNotEnoughPoints();
        }

    }

    public void ShowNotEnoughPoints()
    {
        GameObject newText = Instantiate(NotEnoughPoints, transform.position, Quaternion.identity, transform) as GameObject;
        newText.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);

    }

    public void Destroy ()
    {
        target.DestroyTurret();
        Debug.Log("Turret Destroyed.");
        TurretController.turretController.DeselectBase();
    }
}
