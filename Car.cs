using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{

    // Varaiables

    public Transform centerMass;
   
    public float steer { get; set; }
    public float throttle { get; set; }

    public float motorToque = 300f;
    public float maxSteer = 20f;

    Rigidbody rb;
    Wheel[] wheels;

    public GameObject lights;
    bool lightOn;

    public GameObject explosionPrefab;

    // Functions

    void Start()
    {

        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = centerMass.localPosition;

        wheels = GetComponentsInChildren<Wheel>();
        

    }//Start


    void Update()
    {


        foreach(var wheel in wheels)
        {

            wheel.steerAngle = steer * maxSteer;
             //* -1;

            if (this.gameObject.CompareTag("DragRacer") || this.gameObject.CompareTag("Bucket_Racer"))
            {

                wheel.torque = throttle * motorToque *-1;

            }else
                wheel.torque = throttle * motorToque;

        }
                                                                        // Executes the code in each wheel which has the script on.

        if (Input.GetKeyDown(KeyCode.L))
        {

            lightOn = !lightOn;
        }
                                                                        // Gets the input to activate the lights or deactivate them.

        if (Input.GetKeyDown(KeyCode.B))
        {

            rb.velocity = Vector3.zero;
            
        }
        // Used to activate the handbrake, to stop the vehicle from moving.

        if (lights == null)
            return;

        if (lightOn)
            lights.SetActive(true);
        else
            lights.SetActive(false);
                                                                         // if the boolean is true or false, it sets the lights on or off, respectivly.
    }//Update


}// CARS
