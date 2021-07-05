using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{

    // Var

    public bool steer;
    public bool invertSteer;
    public bool power;

    public float steerAngle { get; set; }
    public float torque { get; set; }

    private WheelCollider wheelCollider;
    private Transform wheelTransform;

    public GameObject emission;

    // Func

    void Start()
    {

        wheelCollider = GetComponentInChildren<WheelCollider>();
        wheelTransform = GetComponentInChildren<MeshRenderer>().GetComponent<Transform>();

    }//Start

    
    void Update()
    {

        wheelCollider.GetWorldPose(out Vector3 pos, out Quaternion rot);
        wheelTransform.position = pos;
        wheelTransform.rotation = rot;                                                                      // Gets the postion and rotation relative to the wheel collider.
        
    }//Update


    void FixedUpdate()
    {

        if (steer)
        {
            wheelCollider.steerAngle = steerAngle * (invertSteer ? -1 : 1);
        }

        if (power)
        {
            if(torque == 0)
            {
                wheelCollider.motorTorque = 0;
                emission.SetActive(false);
            }
            wheelCollider.motorTorque = torque;
            emission.SetActive(true);


        }
                                                                                                        // Checks if the booleans are true, if steer it then checks if the invert is true or not
                                                                                                        // And either makes it a negative for right or positive for left. If power is true it gives 
                                                                                                        // torque to the vehicle
    }


}// WHEEL

