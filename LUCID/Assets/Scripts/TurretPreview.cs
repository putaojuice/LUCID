using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretPreview : MonoBehaviour
{
    [SerializeField] private Material previewMaterial;
	[SerializeField] private Color buildableColor;
	[SerializeField] private Color unbuildableColor;

    // Start is called before the first frame update
    void Start()
    {
        previewMaterial.SetColor("_Color", buildableColor);
    }

    public void UnbuildableColor()
    {
        previewMaterial.SetColor("_Color", unbuildableColor);
    }

    public void BuildableColor()
    {
        previewMaterial.SetColor("_Color", buildableColor);
    }
}
