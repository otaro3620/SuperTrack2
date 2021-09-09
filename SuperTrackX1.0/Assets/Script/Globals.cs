using System.Collections;
using System.Collections.Generic;
using UnityEngine;

delegate void VoidFuncVoid();

public enum SceneTran
{
    fade,
    Barrido,
    Hambrienta,
    CortinaB,
    Hambrienta2,
    Zoom,
    DobleReloj,
    Iris,
    snes,
    IrisPixel,
    deinterlace,
    Cenicienta,
    Vortex,
   
};



public class Globals : Singleton<Globals>
{
    public string[] shaders = {
        "Fade",
        "Barrido",
        "Hambrienta",
        "CortinaB",
        "Hambrienta2",
        "Zoom",
        "DobleReloj",
        "Iris",
        "Snes",
        "IrisPixel",
        "Deinterlace",
        "Cenicienta",
        "Vortex",
        };

    public SceneTran scenetran = SceneTran.fade;
    public int scene = 0;

}