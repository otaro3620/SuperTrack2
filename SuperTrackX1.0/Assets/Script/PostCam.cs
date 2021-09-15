using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PostCam : MonoBehaviour
{
    //public GameObject[] InfoCar;
    //camaras de repisas 
    public GameObject camara_seleccionREP;
    //menu principal
    public GameObject canvas_camara_principal;
    public GameObject camara_principal;
    public GameObject camara_grua;
    public GameObject camara_pistas;
    [Range(0, 100)] public float movimientoCam;
    public bool verificacion;
    public SelecionCarro infocar;
    public SeleccionPista pista;

  
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
        if (aa==1539)//Repisas
        {
            camara_seleccionREP.SetActive(true);
            infocar.x = 0;
            canvas_camara_principal.SetActive(false);   
            camara_seleccionREP.GetComponent<CinemachineVirtualCamera>().Priority = 2000;
            camara_principal.GetComponent<CinemachineVirtualCamera>().Priority = 1;
            camara_grua.GetComponent<CinemachineVirtualCamera>().Priority = 1;
            camara_pistas.GetComponent<CinemachineVirtualCamera>().Priority = 1;
            print("aaaa");
            aa = 0;
        }
        else if (aa==1540)//Grua
        {
            camara_grua.SetActive(true);
            canvas_camara_principal.SetActive(false);
            camara_grua.GetComponent<CinemachineVirtualCamera>().Priority = 2000;
            camara_seleccionREP.GetComponent<CinemachineVirtualCamera>().Priority =1;
            camara_principal.GetComponent<CinemachineVirtualCamera>().Priority = 1;
            camara_pistas.GetComponent<CinemachineVirtualCamera>().Priority = 1;
            aa = 0;
        }
        else if (aa==1541)//Pistas
        {
            camara_pistas.SetActive(true);
            canvas_camara_principal.SetActive(false);
            pista.i = 0;
            camara_pistas.GetComponent<CinemachineVirtualCamera>().Priority =2000;
            camara_grua.GetComponent<CinemachineVirtualCamera>().Priority = 1;
            camara_seleccionREP.GetComponent<CinemachineVirtualCamera>().Priority = 1;
            camara_principal.GetComponent<CinemachineVirtualCamera>().Priority = 1;
            aa = 0;
        }
        else if (aa == 1542)//Menu Principal
        {
            canvas_camara_principal.SetActive(true);
            camara_grua.SetActive(false);
            camara_pistas.SetActive(false);
            camara_seleccionREP.SetActive(false);
            infocar.InfoCar[y].SetActive(false);
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
