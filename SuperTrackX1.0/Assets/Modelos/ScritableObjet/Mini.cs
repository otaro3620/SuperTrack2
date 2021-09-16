using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mini : MonoBehaviour
{
    public CambiodeColor config_mini;
    public Renderer render;
    void Start()
    {
        render = GetComponent<MeshRenderer>();
    }
    void Update()
    {
        render.material.SetTexture("_BaseColorMap", config_mini.texture[config_mini.z]);
    }

}
