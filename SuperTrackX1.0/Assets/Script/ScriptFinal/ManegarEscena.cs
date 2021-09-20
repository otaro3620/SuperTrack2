using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManegarEscena : MonoBehaviour
{
    public string[] misescenas;

    public Animator animatorMenu;
    public int activacion;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Transicion");
    }

    // Update is called once per frame
    void Update()
    {

        if (activacion == 1)
        {
            animatorMenu.SetInteger("Activacion", 1);
        }
        /*else if (activacion==2)
        {
            animatorMenu.SetInteger("Activacion", 2);
        }*/
    }
    public void CambioEscenas(int s)
    {
        StartCoroutine(Cambioescena(misescenas[s]));
    }
    IEnumerator Transicion()
    {
        yield return new WaitForSecondsRealtime(1);
        animatorMenu.SetInteger("Loading", 1);
    }

    IEnumerator Cambioescena(string escena)
    {
        animatorMenu.SetInteger("Loading", 1);
        yield return new WaitForSeconds(2);
        animatorMenu.SetInteger("Activacion", 2);
        SceneManager.LoadScene(escena);
    }
    public void Activacion(int a)
    {
        activacion = a;
    }
}
