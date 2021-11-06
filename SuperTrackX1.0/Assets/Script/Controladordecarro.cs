using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Axle
{
    front,
    back
}
public struct Wheel
{
    public GameObject model;
    public WheelCollider wheelcollider;
    public Axle axle;

}
[RequireComponent(typeof(Rigidbody))]
public class Controladordecarro : MonoBehaviour
{
    public float maxAcceleracion;
    public float sensibilidadegiro;
    public float maxAngulo;
    public float maxVelocida;
    public float maxBreakTorque;
    public float rpm;
    public float Velocidadactual;

    public float inputX;
    public float inputy;
    public float freno;

    public Rigidbody carRB;
    public WheelCollider llanta;

    public List<AxleInfo> axleInfos = new List<AxleInfo>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        GetInput();
        Move();
        Velocida();
    }

    private void Velocida()
    {
        //Velocidadactual = llanta.rpm;//(2 * Mathf.PI * llanta.radius) * llanta.rpm * 60 / 1000;
        //print(Velocidadactual);
    }

    void Update()
    {

        
    }
    private void GetInput()
    {
        inputX = Input.GetAxis("Horizontalplayer1");
        inputy = Input.GetAxis("Verticalplayer1");
        freno = Input.GetAxis("Jump");
    }

    private void Move()
    {
        foreach (AxleInfo info in axleInfos)
        {
            if (info.isBack)
            {
                if (inputy!=0)
                {
                    info.rightWheel.brakeTorque = 0;
                    info.leftWheel.brakeTorque = 0;
                    info.rightWheel.motorTorque = inputy * maxAcceleracion * maxVelocida * Time.deltaTime;
                    info.leftWheel.motorTorque = inputy * maxAcceleracion * maxVelocida * Time.deltaTime;


                }
                else if (freno!=0)
                {
                    info.rightWheel.motorTorque = 0;
                    info.leftWheel.motorTorque = 0;
                    info.rightWheel.brakeTorque = maxBreakTorque;
                    info.leftWheel.brakeTorque = maxBreakTorque;

                }


            }
            if (info.isFront)
            {
                var _streeAngle = inputX * sensibilidadegiro * maxAngulo;
                info.rightWheel.steerAngle = Mathf.Lerp(info.rightWheel.steerAngle, _streeAngle, 0.5f);
                info.leftWheel.steerAngle = Mathf.Lerp(info.rightWheel.steerAngle, _streeAngle, 0.5f);
                
            }
            AnimateWheels(info.rightWheel, info.visualRightWheel);
            AnimateWheels(info.leftWheel, info.visualLeftWheel);

        }
    }

    private void AnimateWheels(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Quaternion _rotacion;
        Vector3 _posicion;

        Vector3 rotate = Vector3.zero;

        wheelCollider.GetWorldPose(out _posicion, out _rotacion);
        wheelTransform.transform.rotation = _rotacion;

    }
}
[System.Serializable]
public class AxleInfo
{
    public WheelCollider rightWheel;
    public WheelCollider leftWheel;

    public Transform visualRightWheel;
    public Transform visualLeftWheel;

    public bool isBack;
    public bool isFront;

}
