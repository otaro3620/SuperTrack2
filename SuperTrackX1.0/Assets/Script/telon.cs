using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class telon : MonoBehaviour
{
    
    public string[] misescenas;
    public Animator animacionBotones;
    public int activacion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activacion==1)
        {
            animacionBotones.SetInteger("Activacion", 1);
        }
    }
    public void Telonar(int s)
    {
        StartCoroutine(Cambioescena(misescenas[s]));
    }
    IEnumerator Cambioescena(string escena)
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(escena);
    }
    public void Activacion(int a)
    {
        activacion = a;
    }
}
