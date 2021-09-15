using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SelecionCarro : MonoBehaviour
{
    public Transform[] posCm;
    public GameObject[] InfoCar;
    public GameObject[] InstaciaCarr;
    public Transform PuntodeInstacia;
    public GameObject cam_repisas;

    [Range(0, 100)] public float movimientoCam;
    public bool verificacion;
    public int x;
    public int y;
    public int z;
    public int aa;
    void Start()
    {
        x = 25;
    }
    void Update()
    {

        
        foreach (GameObject item in InfoCar)
        {
            InfoCar[y].SetActive(false);
        }
        if (x>=0&&x<=10)
        {
            foreach (GameObject item in InfoCar)
            {
                InfoCar[x].SetActive(true);
            }
            cam_repisas.transform.position = Vector3.Lerp(cam_repisas.transform.position, posCm[x].position, 2 * Time.deltaTime);
            cam_repisas.transform.rotation = Quaternion.Lerp(cam_repisas.transform.rotation, posCm[x].rotation, 2 * Time.deltaTime);
        }

        if (z != 0)
        {
            Instantiate(InstaciaCarr[z], PuntodeInstacia.position, Quaternion.identity);
        }
        else if (verificacion==false)
        {


        }
        if (aa == 1542)
        {
            InfoCar[y].SetActive(false);
            aa = 0;
        }
        print(aa);



    }
    public void Destino(int destino)
    {
        x = destino;
    }
    public void Inactivar(int inactivar)
    {
        y = inactivar;
    }
    public void Instaciar(int instanciar)
    {
        z = instanciar;
        
    }
    public void Centrar(int RepCentral)
    {
        aa = RepCentral;
    }
}
