using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CarControler))]
public class Control_Car : MonoBehaviour
{
    
    private CarControler m_Car; // the car controller we want to use


    private void Awake()
    {
        // get the car controller
        m_Car = GetComponent<CarControler>();
    }


    private void FixedUpdate()
    {
        // pass the input to the car!
        float h = Input.GetAxis("Horizontalplayer1");
        float v = Input.GetAxis("Verticalplayer1");
#if !MOBILE_INPUT
        float handbrake = Input.GetAxis("Jump");
        m_Car.Move(h, v, v, handbrake);
#else
            m_Car.Move(h, v, v, 0f);
#endif
    }
}

