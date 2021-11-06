using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R5 : MonoBehaviour
{
    public CambiodeColor config_R5;
    public Renderer render;
    public int z;
    void Start()
    {
        render = GetComponent<MeshRenderer>();
        z = config_R5.z;
    }
    void Update()
    {
        render.material.SetTexture("_BaseColorMap", config_R5.texture[config_R5.z]);
        config_R5.z = z;
    }
    public void CambioCol(int color)
    {
        z = color;
    }
}
