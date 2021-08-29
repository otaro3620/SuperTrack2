using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PostCam : MonoBehaviour
{
    public GameObject[] InfoCar;
    //camaras de repisas 
    public GameObject Camara_SelecionINS;
    public GameObject camara_seleccionREP;
    //public Transform RepCentral;
    public GameObject canvas_camara_principal;
    public GameObject camara_principal;
    public GameObject camara_grua;
    public GameObject camara_pistas;
    [Range(0, 100)] public float movimientoCam;
    public bool verificacion;

    public SelecionCarro inactivar;
    public int aa;
    public int menu_inicio;
    public int priority;
    public int y;
    void Start()
    {
        camara_principal.GetComponent<CinemachineVirtualCamera>().Priority = priority+1;
    }
    void Update()
    {

        if (aa==1539)
        {
            canvas_camara_principal.SetActive(false);
            Camara_SelecionINS.SetActive(true);
            camara_seleccionREP.SetActive(true);
            camara_seleccionREP.GetComponent<CinemachineVirtualCamera>().Priority = 2000;
            camara_principal.GetComponent<CinemachineVirtualCamera>().Priority = 1;
            camara_grua.GetComponent<CinemachineVirtualCamera>().Priority = 1;
            camara_pistas.GetComponent<CinemachineVirtualCamera>().Priority = 1;
            print("aaaa");
            aa = 0;

        }
        else if (aa==1540)
        {

            canvas_camara_principal.SetActive(false);
            camara_grua.SetActive(true);
            camara_grua.GetComponent<CinemachineVirtualCamera>().Priority = 2000;
            camara_seleccionREP.GetComponent<CinemachineVirtualCamera>().Priority =1;
            camara_principal.GetComponent<CinemachineVirtualCamera>().Priority = 1;
            camara_pistas.GetComponent<CinemachineVirtualCamera>().Priority = 1;
            aa = 0;
        }
        else if (aa==1541)
        {
            canvas_camara_principal.SetActive(false);
            camara_pistas.SetActive(true);
            camara_pistas.GetComponent<CinemachineVirtualCamera>().Priority =2000;
            camara_grua.GetComponent<CinemachineVirtualCamera>().Priority = 1;
            camara_seleccionREP.GetComponent<CinemachineVirtualCamera>().Priority = 1;
            camara_principal.GetComponent<CinemachineVirtualCamera>().Priority = 1;
            aa = 0;
        }
        else if (aa == 1542)
        {
            canvas_camara_principal.SetActive(true);
            camara_grua.SetActive(false);
            camara_pistas.SetActive(false);
            camara_seleccionREP.SetActive(false);
            Camara_SelecionINS.SetActive(false);
            InfoCar[y].SetActive(false);
            camara_principal.GetComponent<CinemachineVirtualCamera>().Priority = 2000;
            camara_seleccionREP.GetComponent<CinemachineVirtualCamera>().Priority = 1;
            camara_grua.GetComponent<CinemachineVirtualCamera>().Priority = 1;
            camara_pistas.GetComponent<CinemachineVirtualCamera>().Priority = 1;
            aa = 0;
        }



        
    }


    public void Centrar(int a)
    {
        aa = a;
    }
    public void Volver(int a)
    {
        y= a;
    }
}
