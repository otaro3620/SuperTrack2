using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mini : MonoBehaviour
{
    public CambiodeColor config_mini;
    public Renderer render;
    public int z;
    void Start()
    {
        render = GetComponent<MeshRenderer>();
        z = config_mini.z;
    }
    void Update()
    {
        render.material.SetTexture("_BaseColorMap", config_mini.texture[config_mini.z]);
        config_mini.z = z;
    }
    public void CambioCol(int color)
    {
        z = color;
    }
}
