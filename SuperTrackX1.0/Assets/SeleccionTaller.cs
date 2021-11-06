using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeleccionTaller : MonoBehaviour
{
    public Transform[] taller;
    public GameObject[] infotaller;
    public GameObject camTaller;
    public GameObject canvasTaller;
    public int i;


    void Start()
    {
        i = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (i==0)
        {
            canvasTaller.SetActive(true);
            camTaller.transform.position = Vector3.Lerp(camTaller.transform.position, taller[i].position, 2 * Time.deltaTime);
            camTaller.transform.rotation = Quaternion.Lerp(camTaller.transform.rotation, taller[i].rotation, 2 * Time.deltaTime);
        }
        else if (i>=1)
        {
            canvasTaller.SetActive(false);
            camTaller.transform.position = Vector3.Lerp(camTaller.transform.position, taller[i].position, 2 * Time.deltaTime);
            camTaller.transform.rotation = Quaternion.Lerp(camTaller.transform.rotation, taller[i].rotation, 2 * Time.deltaTime);
        }
        
    }
    public void SiguienteCamTaller(int taller)
    {
        i = taller;
    }
}
