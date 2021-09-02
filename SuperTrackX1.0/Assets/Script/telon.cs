using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class telon : MonoBehaviour
{
    public Image miimagen;
    public string[] misescenas;

    // Start is called before the first frame update
    void Start()
    {
        miimagen.CrossFadeAlpha(0, 5f, false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Telonar(int s)
    {
        miimagen.CrossFadeAlpha(1, 0.5f, false);
        StartCoroutine(Cambioescena(misescenas[s]));
    }
    IEnumerator Cambioescena(string escena)
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(escena);
    }
}
