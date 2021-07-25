using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DeckManager : MonoBehaviour
{
    private static DeckManager deckManager;
    public List<CardBlueprint> TurretDeckList = new List<CardBlueprint>();
    public List<CardBlueprint> TetrisDeckList = new List<CardBlueprint>();
    public Stack<CardBlueprint> TurretDeck = new Stack<CardBlueprint>();
    public Stack<CardBlueprint> TetrisDeck = new Stack<CardBlueprint>();
    public List<CardBlueprint> Hand = new List<CardBlueprint>();
    public Transform DeckPanel;

    public int maxHandSize = 5;
    public int maxTurretHandSize = 2;
    public int maxTetrisHandSize = 3;
    public static int currHandSize = 0;

    private void Awake()
    {
        currHandSize = 0;
        deckManager = this;
        ResetTurretDeck();
        ResetTetrisDeck();
    }

    private void ResetTurretDeck()
    {
        // Fisher Yates Algo
        var rand = new System.Random();
        
        for (var n = TurretDeckList.Count -1; n > 0; --n)
        {
            var next = rand.Next(n + 1);
            var temp = TurretDeckList[next];
            TurretDeckList[n] = TurretDeckList[next];
            TurretDeckList[next] = temp;

        }

        foreach(var card in TurretDeckList)
        {
            TurretDeck.Push(card);
        }
    }

    private void ResetTetrisDeck()
    {
        // Fisher Yates Algo
        var rand = new System.Random();
        for (var n = TetrisDeckList.Count -1; n > 0; --n)
        {
            var next = rand.Next(n + 1);
            var temp = TetrisDeckList[n];
            TetrisDeckList[n] = TetrisDeckList[next];
            TetrisDeckList[next] = temp;

        }

        foreach(var card in TetrisDeckList)
        {
            TetrisDeck.Push(card);
        }
    }

    private void DealTurretCard()
    {
        if (TurretDeck.Count <= 0)
        {
            ResetTurretDeck();
        }

        CardBlueprint newTurretCard = Instantiate(TurretDeck.Pop());

        Hand.Add(newTurretCard);

        var card = Instantiate(newTurretCard.prefab);
        card.transform.SetParent(DeckPanel);
        card.transform.localScale = Vector3.one;

        var cardHandler = card.GetComponent<CardHandler>();
        if (cardHandler != null)
        {
            cardHandler.CardName = newTurretCard.Name;
            cardHandler.cardImage = newTurretCard.artwork;
        }
    }

    private void DealTetrisCard()
    {
        if (TetrisDeck.Count <= 0)
        {
            ResetTetrisDeck();
        }

        CardBlueprint newTetrisCard = Instantiate(TetrisDeck.Pop());

        Hand.Add(newTetrisCard);

        var card = Instantiate(newTetrisCard.prefab);
        card.transform.SetParent(DeckPanel);
        card.transform.localScale = Vector3.one;

        var cardHandler = card.GetComponent<CardHandler>();
        if (cardHandler != null)
        {
            cardHandler.CardName = newTetrisCard.Name;
            cardHandler.cardImage = newTetrisCard.artwork;
        }
    }

    void Start()
    {
        DealingTurret();
        DealingTetris();
    }
    
    public void DealingTurret()
    {
        for (int i = 0; i < maxTurretHandSize; i++)
        {
            if (currHandSize == maxHandSize)
			{
                break;
			}
            DealTurretCard();
            currHandSize++;
        }
    }

    public void DealingTetris()
    {
        for (int i = 0; i < maxTetrisHandSize; i++)
        {
            if (currHandSize == maxHandSize)
			{
                break;
			}
            DealTetrisCard();
            currHandSize++;
        }
    }

    public void ClearHand()
    {
        GameObject[] tetrisCards = GameObject.FindGameObjectsWithTag("TetrisCard");
        GameObject[] turretCards = GameObject.FindGameObjectsWithTag("TurretCard");

        foreach (GameObject x in tetrisCards)
        {
            Destroy(x);
        }

        foreach (GameObject x in turretCards)
        {
            Destroy(x);
        }

        while (currHandSize > 0)
        {
            deckManager.Hand.RemoveAt(0);
            UpgradePoints.Add();
            currHandSize--;
        }
        Debug.Log("Current hand size: " + currHandSize);
    }

}
