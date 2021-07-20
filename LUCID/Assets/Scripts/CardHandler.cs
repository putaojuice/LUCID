using System.Linq;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class CardHandler : MonoBehaviour
{
    TurretController turretController;
    public GameObject tilePreviewPrefab;
    public GameObject turretPreviewPrefab;
    public TurretLevel turret1;
    public TurretLevel turret2;
    public TurretLevel turret3;
    private DeckManager deckManager;
    public string CardName;    
    public Sprite cardImage;

    void Start()
    {
        deckManager = GameObject.Find("DeckManager").GetComponent<DeckManager>();
        turretController = TurretController.turretController;
    }
    
    private void SelectTurret1 ()
    {
        turretController.BuildTurret(turret1);
        Debug.Log("Turret 1 selected.");
    }

    private void SelectTurret2 ()
    {
        turretController.BuildTurret(turret2);
        Debug.Log("Turret 2 selected.");
    }

    private void SelectTurret3 ()
    {
        turretController.BuildTurret(turret3);
        Debug.Log("Turret 3 selected.");
    }

    public void OnMouseDown()
    {
        GameObject.Find("Button Sound").GetComponent<AudioSource>().Play();

        var card = deckManager.Hand.FirstOrDefault(x => x.Name == CardName);
        
        GridController gridController = GameObject.Find("GridGenerator").GetComponent<GridController>();

        void Destruction()
        {
            deckManager.Hand.Remove(card);
            Destroy(gameObject);
            DeckManager.currHandSize--;
        }

        if (card != null)
        {
            if (card.prefab.CompareTag("TurretCard"))
            {
                if (card.turretID == 1)
                {
                    TurretBase.BuildingMode();
                    turretController.NewBuild(turretPreviewPrefab);
                    SelectTurret1();
                    Destruction();
                }    
                else if (card.turretID == 2)
                {
                    TurretBase.BuildingMode();
                    turretController.NewBuild(turretPreviewPrefab);
                    SelectTurret2();
                    Destruction();
                }
                else if (card.turretID == 3)
                {
                    TurretBase.BuildingMode();
                    turretController.NewBuild(turretPreviewPrefab);
                    SelectTurret3();
                    Destruction();
                }
            } else if (card.prefab.CompareTag("TetrisCard")) 
            {
                Debug.Log("Tetris card selected.");
                gridController.NewBuild(tilePreviewPrefab);
                TurretBase.EndBuild();
                Destruction();
            }
        }
    }
}
