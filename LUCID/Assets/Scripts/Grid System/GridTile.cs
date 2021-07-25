using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTile : MonoBehaviour
{
    private List<GameObject> obj = new List<GameObject>();
	private List<GridBase> ground = new List<GridBase>();
	[SerializeField] private Material tileMat;
	[SerializeField] private Color buildableColor;
	[SerializeField] private Color unbuildableColor;
	[SerializeField] private GameObject buildPrefab;
	private bool buildable = false;
	private bool rotated = false;

	private void Start()
	{
		ChangeColor();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("GridFloor"))
		{
			obj.Add(other.gameObject);
		}

		if (other.CompareTag("GridBase"))
		{
			GridBase gridBase = other.GetComponent<GridBase>();
			ground.Add(gridBase);
			gridBase.Selection();
		}

		ChangeColor();
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("GridFloor"))
		{
			obj.Remove(other.gameObject);
		}

		if (other.CompareTag("GridBase"))
		{
			GridBase gridBase = other.GetComponent<GridBase>();
			ground.Remove(gridBase);
			gridBase.Selection();
		}

		ChangeColor();
	}

	private void ChangeColor()
	{
		if (obj.Count == 0)
		{
			tileMat.SetColor("_Color", buildableColor);
			buildable = true;
		}
		else
		{
			tileMat.SetColor("_Color", unbuildableColor);
			buildable = false;
		}
	}

	public bool GetBuildable()
	{
		return buildable;
	}

	public void Build()
	{
		for (int i = 0; i < ground.Count; i++)
		{
			ground[i].Selection();
		}

		Instantiate(buildPrefab, transform.position, transform.rotation);
		Destroy(gameObject);
	}

	public void Rotate()
	{
		rotated = !rotated;
	}

	public bool GetRotateState()
	{
		return rotated;
	}
}
