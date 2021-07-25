using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TurretUI : MonoBehaviour
{
    public GameObject ui;
    private TurretBase target;
    public TextMeshProUGUI upgradeStatus;
    public Button upgradeButton;
    public GameObject NotEnoughPoints;

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
        if (UpgradePoints.upgradePoints > 0)
        {
            target.UpgradeTurret();
            Debug.Log("Turret Upgraded.");
            TurretController.turretController.DeselectBase();
            UpgradePoints.Minus();
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
