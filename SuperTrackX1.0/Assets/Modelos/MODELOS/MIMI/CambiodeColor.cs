using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiodeColor : MonoBehaviour
{
    public Texture[] texture;
    public Renderer render;
    public int z;

    // Update is called once per frame
    void Update()
    {
        render.material.SetTexture("_BaseColorMap", texture[z]);
    }
    public void CambioCol(int color)
    {
        z = color;
    }
}
