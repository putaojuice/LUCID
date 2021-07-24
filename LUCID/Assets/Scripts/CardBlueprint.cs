using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class CardBlueprint : ScriptableObject
{
    public string Name;
    public GameObject prefab;
    public Sprite artwork;
    public int turretID;
}

