using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFX : MonoBehaviour
{

    Material Material;

    private void Awake()
    {
        Material = new Material(Shader.Find("cierre"));
    }
    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, Material);
    }
}
