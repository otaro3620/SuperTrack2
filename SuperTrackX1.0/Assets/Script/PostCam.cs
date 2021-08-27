using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PostCam : MonoBehaviour
{
    public Transform[] posCm;
    public GameObject[] InfoCar;
    public GameObject[] InstaciaCarr;
    public Transform PuntodeInstacia;
    public Transform RepCentral;
    public GameObject Selecion;
    [Range(0, 100)] public float movimientoCam;
    public bool verificacion;
    public int x;
    public int y;
    public int z;
    public int aa;
    void Start()
    {
        
    }
    void Update()
    {

        
        foreach (GameObject item in InfoCar)
        {
            InfoCar[y].SetActive(false);
        }
        foreach (GameObject item in InfoCar)
        {
            InfoCar[x].SetActive(true);
        }
        if (z!=0)
        {
            Instantiate(InstaciaCarr[z], PuntodeInstacia.position, Quaternion.identity);
            if (aa==1538)
            {
                //this.transform.position = Vector3.Lerp(this.transform.position, posCm[5].position, 50 );
                //this.transform.rotation = Quaternion.Lerp(this.transform.rotation, posCm[5].rotation, 50);
                Selecion.GetComponent<CinemachineVirtualCamera>().Priority = 99;
                verificacion = true;
                z = 0;
            }

 
        }
        else if (verificacion==false)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, posCm[x].position, 2 * Time.deltaTime);
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, posCm[x].rotation, 2 * Time.deltaTime);
            print("aa");
        }



    }
    public void Destino(int c)
    {
        x = c;
    }
    public void Inactivar(int d)
    {
        y = d;
    }
    public void Instaciar(int B)
    {
        z = B;
        
    }
    public void Centrar(int a)
    {
        aa = a;
    }
   
}
