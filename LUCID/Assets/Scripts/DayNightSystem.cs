using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightSystem : MonoBehaviour
{
    [SerializeField] private Material skybox;
    [SerializeField] private Texture daySky;
    [SerializeField] private Texture nightSky;
    [SerializeField] private Light dirLight;
    [SerializeField] private Color dayLight;
    [SerializeField] private Color nightLight;
    

    // Start is called before the first frame update
    void Start()
    {
        dirLight.color = dayLight;
        skybox.SetTexture("_Tex", daySky);
    }

    public void DayTime()
    {
        dirLight.color = dayLight;
        skybox.SetTexture("_Tex", daySky);
    }

    public void NightTime()
    {
        dirLight.color = nightLight;
        skybox.SetTexture("_Tex", nightSky);
    }
}
