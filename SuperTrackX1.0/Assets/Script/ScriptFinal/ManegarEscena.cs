using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManegarEscena : MonoBehaviour
{
    public string[] misescenas;
    public PostCam carga;
    public void CambioEscenas()
    {
        StartCoroutine(Cambioescena(misescenas[carga.pistas]));
    }
    public void EscenaAnterior(int anterior)
    {
        StartCoroutine(Cambioescena(misescenas[anterior]));
    }
    IEnumerator Cambioescena(string escena)
    {
        
        yield return new WaitForSeconds(0.5f);   
        SceneManager.LoadScene(escena);
    }
}
