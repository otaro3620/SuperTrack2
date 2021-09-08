using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CambioColor : MonoBehaviour
{
    public GameObject[] materiales;
    public GameObject carro;
    public int z;
    public int y=1;
    public Slider scalaSlider;
    public Slider rotationSlider;
    public Slider rotationSliderz;
    public Slider rotationSliderx;
    public float scaleMinValor;
    public float scaleMaxValor;
    public float rotationMinValor;
    public float rotationMaxValor;
    public float rotationMinValorz;
    public float rotationMaxValorz;
    public float rotationMinValorx;
    public float rotationMaxValorx;
    //public Animator botonColor;
    // Start is called before the first frame update
    void Start()
    {
        /*scalaSlider.minValue = scaleMinValor;
        scalaSlider.maxValue = scaleMaxValor;
        scalaSlider.onValueChanged.AddListener(ScaleSliderUpdate);

        rotationSlider.minValue = rotationMinValor;
        rotationSlider.maxValue = rotationMaxValor;
        rotationSlider.onValueChanged.AddListener(RotateSliderUpdate);

        rotationSliderz.minValue = rotationMinValorz;
        rotationSliderz.maxValue = rotationMaxValorz;
        rotationSliderz.onValueChanged.AddListener(RotateSliderUpdateZ);

        rotationSliderx.minValue = rotationMinValorx;
        rotationSliderx.maxValue = rotationMaxValorx;
        rotationSliderx.onValueChanged.AddListener(RotateSliderUpdatex);*/
    }

    void RotateSliderUpdatex(float value)
    {
        carro.transform.localEulerAngles = new Vector3(value, transform.rotation.y, transform.rotation.z);
    }

    void RotateSliderUpdateZ(float value)
    {
        carro.transform.localEulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, value);
    }

    void RotateSliderUpdate(float value)
    {
        carro.transform.localEulerAngles = new Vector3(transform.rotation.x, value, transform.rotation.z);
    }

    void ScaleSliderUpdate(float value)
    {
        carro.transform.localScale = new Vector3 (value, value, value);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (z==1538)
        {
            botonColor.SetInteger("New Int",1);
        }
        if (z==1539)
        {
            botonColor.SetInteger("New Int", 0);
        }*/
        scalaSlider.minValue = scaleMinValor;
        scalaSlider.maxValue = scaleMaxValor;
        scalaSlider.onValueChanged.AddListener(ScaleSliderUpdate);

        rotationSlider.minValue = rotationMinValor;
        rotationSlider.maxValue = rotationMaxValor;
        rotationSlider.onValueChanged.AddListener(RotateSliderUpdate);

        rotationSliderz.minValue = rotationMinValorz;
        rotationSliderz.maxValue = rotationMaxValorz;
        rotationSliderz.onValueChanged.AddListener(RotateSliderUpdateZ);

        rotationSliderx.minValue = rotationMinValorx;
        rotationSliderx.maxValue = rotationMaxValorx;
        rotationSliderx.onValueChanged.AddListener(RotateSliderUpdatex);

        if (z==0)
        {
            materiales[0].SetActive(true);
            materiales[1].SetActive(false);
            materiales[2].SetActive(false);
            materiales[3].SetActive(false);
            materiales[4].SetActive(false);
        }
        else if (z==1)
        {
            materiales[0].SetActive(false);
            materiales[1].SetActive(true);
            materiales[2].SetActive(false);
            materiales[3].SetActive(false);
            materiales[4].SetActive(false);
        }
        else if (z==2)
        {
            materiales[0].SetActive(false);
            materiales[1].SetActive(false);
            materiales[2].SetActive(true);
            materiales[3].SetActive(false);
            materiales[4].SetActive(false);
        }
        else if(z==3)
        {
            materiales[0].SetActive(false);
            materiales[1].SetActive(false);
            materiales[2].SetActive(false);
            materiales[3].SetActive(true);
            materiales[4].SetActive(false);
        }
        else if (z==4)
        {
            materiales[0].SetActive(false);
            materiales[1].SetActive(false);
            materiales[2].SetActive(false);
            materiales[3].SetActive(false);
            materiales[4].SetActive(true);
        }
    }
    public void CambioTexturas(int s)
    {

        z = s;


    }

}
