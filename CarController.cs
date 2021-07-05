using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    //Vars

    public string inputSteerAxis = "Horizontal";
    public string inputThrottelAxis = "Vertical";

    public float throttelInput { get; set; }
    public float steerInput { get; set; }

    //Func


    void Start()
    {
        


    }//Start


    void Update()
    {

        steerInput = Input.GetAxis(inputSteerAxis);
        throttelInput = Input.GetAxis(inputThrottelAxis);
                                                                                // Sets the public variables to the strings to get axis.   
    }//Update


}// CAR CONTROLLER
