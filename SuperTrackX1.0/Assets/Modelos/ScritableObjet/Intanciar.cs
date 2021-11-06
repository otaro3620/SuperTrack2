using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intanciar : MonoBehaviour
{
    public InstanciCarro selecionCarro;
    public GameObject[] insCar;
    public int z;
    public int y;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (z>=0&&z<=10)
        {
            if (selecionCarro.seleccion == 0)
            {
                insCar[0].SetActive(true);
                insCar[1].SetActive(false);
                /*insCar[2].SetActive(false);
                insCar[3].SetActive(false);
                insCar[4].SetActive(false);
                insCar[5].SetActive(false);
                insCar[6].SetActive(false);
                insCar[7].SetActive(false);
                insCar[8].SetActive(false);
                insCar[9].SetActive(false);*/
            }
            else if (selecionCarro.seleccion == 1)
            {
                insCar[0].SetActive(false);
                insCar[1].SetActive(true);
                /*insCar[2].SetActive(false);
                insCar[3].SetActive(false);
                insCar[4].SetActive(false);
                insCar[5].SetActive(false);
                insCar[6].SetActive(false);
                insCar[7].SetActive(false);
                insCar[8].SetActive(false);
                insCar[9].SetActive(false);*/
            }
        }
    }
    public void SelecionCar(int carro)
    {
        selecionCarro.seleccion =  carro;
    }
    public void ApagarCarro(int apagado)
    {
        y = apagado;
    }
}
