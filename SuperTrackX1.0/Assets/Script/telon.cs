using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class telon : MonoBehaviour
{
    public Image miimagen;
    public string[] misescenas;
    public int seconds;

    // Start is called before the first frame update
    void Start()
    {
        miimagen.CrossFadeAlpha(0, 2.0f, false);
    }

    public void Telonar(int s)
    {
        miimagen.CrossFadeAlpha(1, 2.0f, false);
        StartCoroutine(Cambioescena(misescenas[s]));
    }
    IEnumerator Cambioescena(string escena)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(escena);
    }
}
