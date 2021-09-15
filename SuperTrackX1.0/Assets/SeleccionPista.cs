using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeleccionPista : MonoBehaviour
{
    public Transform[] postPista;
    public GameObject camPista;
    public GameObject[] infoPista;
    public int i;
    public int j;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (i==0)
        {
            infoPista[0].SetActive(true);
            infoPista[1].SetActive(false);
            infoPista[2].SetActive(false);
            infoPista[3].SetActive(false);

        }
        else if (i==1)
        {
            infoPista[0].SetActive(false);
            infoPista[1].SetActive(true);
            infoPista[2].SetActive(false);
            infoPista[3].SetActive(false);
        }
        else if (i==2)
        {
            infoPista[0].SetActive(false);
            infoPista[1].SetActive(false);
            infoPista[2].SetActive(true);
            infoPista[3].SetActive(false);
        }
        else if (i==3)
        {
            infoPista[0].SetActive(false);
            infoPista[1].SetActive(false);
            infoPista[2].SetActive(false);
            infoPista[3].SetActive(true);
        }
        else if (i==4)
        {
            infoPista[0].SetActive(false);
            infoPista[1].SetActive(false);
            infoPista[2].SetActive(false);
            infoPista[3].SetActive(false);
        }
        if (i>=0&&i<=4)
        {
            camPista.transform.position = Vector3.Lerp(camPista.transform.position, postPista[i].position, 2 * Time.deltaTime);
            camPista.transform.rotation = Quaternion.Lerp(camPista.transform.rotation, postPista[i].rotation, 2 * Time.deltaTime);
        }
        
    }
    public void SiguientePista(int sigPist)
    {
        i = sigPist;
    }

}
