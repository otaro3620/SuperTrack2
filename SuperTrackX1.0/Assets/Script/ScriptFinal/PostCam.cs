using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class PostCam : MonoBehaviour
{   // gameobject camaras
    public CamarasPricipales camarasPrincipales;
    [System.Serializable]
    public class CamarasPricipales 
    { 
        public GameObject camara_Garage;
        public GameObject camara_Principal;
        public GameObject camara_Taller;
        public GameObject camara_Pistas;
    }
    
    public Botones botones;
    [System.Serializable]
    public class Botones
    {
        //gameobject canvas
    
        public GameObject anterior;
        public GameObject siguiente;
        public GameObject seleccionar;
        public GameObject botonConstrucion;
        public GameObject botonCiudad;
        public GameObject botonRally;
        public GameObject botonRace;
        public GameObject botonPintura;
        public GameObject botonGrua;
        public GameObject botonJugar;
        public Button botonGarage;
        public Button botonPista;
        public Button botonTaller;
        public Button buttonRegreso;
    }
    public InstanciCarro scriObject;
    [System.Serializable]
    public class ScriObject
    {
        public InstanciCarro selecionCarro;
    }
    //posicion camara en repisa
    public Transform[] poscampist;
    public Transform[] posCm;
    public Transform[] poscamtaller;
    public GameObject[] insCar;
    public int x,xAnterior;
    public int i;
    public int vehiculo;
    public int pistas;
    public int tallers;

    void Start()
    {
        camarasPrincipales.camara_Principal.GetComponent<CinemachineVirtualCamera>().Priority = 2;
    }
    void Update()
    {
        if (x!=xAnterior)
        {
            for (int i = 0; i < 2; i++)
            {
                insCar[i].SetActive(false);
                insCar[x].SetActive(true);
            }
            xAnterior = x;
        }

        /*switch (scriObject.seleccion)
        {
            case 0:
                insCar[0].SetActive(true);
                insCar[1].SetActive(false);
                break;
            case 1:
                insCar[0].SetActive(false);
                insCar[1].SetActive(true);
                break;
        }*/
        camarasPrincipales.camara_Garage.transform.position = Vector3.Lerp(camarasPrincipales.camara_Garage.transform.position, posCm[x].position, 2 * Time.deltaTime);
        camarasPrincipales.camara_Garage.transform.rotation = Quaternion.Lerp(camarasPrincipales.camara_Garage.transform.rotation, posCm[x].rotation, 2 * Time.deltaTime);

        camarasPrincipales.camara_Pistas.transform.position = Vector3.Lerp(camarasPrincipales.camara_Pistas.transform.position, poscampist[pistas].position, 2 * Time.deltaTime);
        camarasPrincipales.camara_Pistas.transform.rotation = Quaternion.Lerp(camarasPrincipales.camara_Pistas.transform.rotation, poscampist[pistas].rotation, 2 * Time.deltaTime);

        camarasPrincipales.camara_Taller.transform.position = Vector3.Lerp(camarasPrincipales.camara_Taller.transform.position, poscamtaller[tallers].position, 2 * Time.deltaTime);
        camarasPrincipales.camara_Taller.transform.rotation = Quaternion.Lerp(camarasPrincipales.camara_Taller.transform.rotation, poscamtaller[tallers].rotation, 2 * Time.deltaTime);
    }
    public void Centrar(int menuPrincipal)
    {
        switch (menuPrincipal)
        {
            case 1539:
                StartCoroutine("Garage");
                break;
            case 1540:
                StartCoroutine("Taller");
                break;
            case 1541:
                StartCoroutine("Pistas");
                break;
            case 1542:
                StartCoroutine("MenuPrincipal");
                break;
        }
    }
    public void VehiculosActivo ()
    {
        scriObject.seleccion = x;
    }
    IEnumerator Garage()
    {
        botones.botonTaller.interactable = false;
        botones.botonPista.interactable = false;
        botones.buttonRegreso.interactable = false;
        botones.botonJugar.SetActive(false);
        botones.botonPintura.SetActive(false);
        botones.botonGrua.SetActive(false);
        botones.botonCiudad.SetActive(false);
        botones.botonConstrucion.SetActive(false);
        botones.botonRace.SetActive(false);
        botones.botonRally.SetActive(false);
        yield return new WaitForSecondsRealtime(0.2f);
        camarasPrincipales.camara_Garage.SetActive(true);
        camarasPrincipales.camara_Garage.GetComponent<CinemachineVirtualCamera>().Priority = 2;
        camarasPrincipales.camara_Taller.GetComponent<CinemachineVirtualCamera>().Priority = 1;
        camarasPrincipales.camara_Pistas.GetComponent<CinemachineVirtualCamera>().Priority = 1;
        camarasPrincipales.camara_Principal.GetComponent<CinemachineVirtualCamera>().Priority = 1;
        yield return new WaitForSecondsRealtime(2f);
        botones.botonTaller.interactable = true;
        botones.botonPista.interactable = true;
        botones.buttonRegreso.interactable = true;
        botones.seleccionar.SetActive(true);
        botones.anterior.SetActive(true);
        botones.siguiente.SetActive(true);
    }
    IEnumerator Taller()
    {
        tallers = 0;
        botones.botonPista.interactable = false;
        botones.botonGarage.interactable = false;
        botones.buttonRegreso.interactable = false;
        botones.botonJugar.SetActive(false);
        botones.seleccionar.SetActive(false);
        botones.botonCiudad.SetActive(false);
        botones.botonConstrucion.SetActive(false);
        botones.botonRace.SetActive(false);
        botones.botonRally.SetActive(false);
        botones.anterior.SetActive(false);
        botones.siguiente.SetActive(false);
        yield return new WaitForSecondsRealtime(0.2f);
        camarasPrincipales.camara_Taller.SetActive(true);
        camarasPrincipales.camara_Taller.GetComponent<CinemachineVirtualCamera>().Priority = 2;
        camarasPrincipales.camara_Pistas.GetComponent<CinemachineVirtualCamera>().Priority = 1;
        camarasPrincipales.camara_Principal.GetComponent<CinemachineVirtualCamera>().Priority = 1;
        camarasPrincipales.camara_Garage.GetComponent<CinemachineVirtualCamera>().Priority = 1;
        yield return new WaitForSecondsRealtime(2f);
        botones.botonPista.interactable = true;
        botones.botonGarage.interactable = true;
        botones.buttonRegreso.interactable = true;
        botones.botonPintura.SetActive(true);
        botones.botonGrua.SetActive(true);
    }
    IEnumerator Pistas()
    {
        botones.botonTaller.interactable = false;
        botones.botonGarage.interactable = false;
        botones.buttonRegreso.interactable = false;
        botones.seleccionar.SetActive(false);
        botones.botonPintura.SetActive(false);
        botones.botonGrua.SetActive(false);
        botones.anterior.SetActive(false);
        botones.siguiente.SetActive(false);
        yield return new WaitForSecondsRealtime(0.2f);
        camarasPrincipales.camara_Pistas.GetComponent<CinemachineVirtualCamera>().Priority = 2;
        camarasPrincipales.camara_Garage.GetComponent<CinemachineVirtualCamera>().Priority = 1;
        camarasPrincipales.camara_Taller.GetComponent<CinemachineVirtualCamera>().Priority = 1;
        camarasPrincipales.camara_Principal.GetComponent<CinemachineVirtualCamera>().Priority = 1;
        yield return new WaitForSecondsRealtime(2f);
        botones.botonTaller.interactable = true;
        botones.botonGarage.interactable = true;
        botones.buttonRegreso.interactable = true;
        botones.botonJugar.SetActive(true);
        botones.botonCiudad.SetActive(true);
        botones.botonConstrucion.SetActive(true);
        botones.botonRace.SetActive(true);
        botones.botonRally.SetActive(true);
    }
    IEnumerator MenuPrincipal()
    {
        botones.botonJugar.SetActive(false);
        botones.seleccionar.SetActive(false);
        botones.botonPintura.SetActive(false);
        botones.botonGrua.SetActive(false);
        botones.botonCiudad.SetActive(false);
        botones.botonConstrucion.SetActive(false);
        botones.botonRace.SetActive(false);
        botones.botonRally.SetActive(false);
        botones.anterior.SetActive(false);
        botones.siguiente.SetActive(false);
        botones.buttonRegreso.interactable = false;
        yield return new WaitForSecondsRealtime(0.2f);
        camarasPrincipales.camara_Principal.GetComponent<CinemachineVirtualCamera>().Priority = 2;
        camarasPrincipales.camara_Garage.GetComponent<CinemachineVirtualCamera>().Priority = 1;
        camarasPrincipales.camara_Taller.GetComponent<CinemachineVirtualCamera>().Priority = 1;
        camarasPrincipales.camara_Pistas.GetComponent<CinemachineVirtualCamera>().Priority = 1;
    }
    public void RepisaSiguiente()
    {
        x++;
        print(x);
        if (x == 10)
        {
            x = 0;
        }
    }
    public void RepisaAnterior()
    {
        x--;
        if (x < 0)
        {
            x = 9;
        }
    }
    public void Pista (int pista)
    {
        pistas = pista;
    }
    public void Taller(int taller)
    {
        tallers = taller;
    }

}
