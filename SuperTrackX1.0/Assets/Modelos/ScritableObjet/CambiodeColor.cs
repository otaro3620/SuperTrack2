using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="Carro",menuName ="texturas",order =2)]
public class CambiodeColor : ScriptableObject
{
    public Texture[] texture;
    public int z;

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CambioCol(int color)
    {
        z = color;
    }
}
