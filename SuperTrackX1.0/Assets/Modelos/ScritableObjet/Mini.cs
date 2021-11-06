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
        //render.material.shader = Shader.Find("HDRP/Li");
        z = config_mini.z;
    }
    void Update()
    {
        //render.material.SetTexture("_BaseColorMap", config_mini.texture[config_mini.z]);
        //render.material.SetColor("_Color", color.gamma);
        if (z == 0)
        {
            render.material.SetColor("_BaseColor", Color.black);
        }
        else if (z == 1)
        {
            render.material.SetColor("_BaseColor", Color.blue);
        }
        else if (z == 2)
        {
            render.material.SetColor("_BaseColor", Color.red);
        }
        else if (z==3)
        {
            render.material.SetColor("_BaseColor", Color.yellow);
        }
        else if (z==4)
        {
            render.material.SetColor("_BaseColor", Color.green);
        }
        else if (z==5)
        {
            render.material.SetColor("_BaseColor", Color.grey);
        }
        else if (z==6)
        {
            render.material.SetColor("_BaseColor", Color.white);
        }
        //render.material.SetColor("_BaseColor", Color.blue);
        config_mini.z = z;
    }
    public void CambioCol(int color)
    {
        z = color;
    }
}
