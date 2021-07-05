using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //Var

    public enum ControlType { PlayerInput, AI}
    public ControlType controlType = ControlType.PlayerInput;

    public float bestLapTime { get; private set; } = Mathf.Infinity;
    public float lastLapTime { get; private set; } = 0;
    public float currentLapTime { get; private set; } = 0;
    public int currentLap { get; private set; } = 0;

    private float lapTimer;
    public int lastCheckpointPass = 0;

    Transform checkPoints;
    private int checkpointCount;
    private int checkPointLayer;

    public int finalLap = 4;

    Car car;

    public bool raceOver { get; private set; } = false;

    //Func

    void Awake()
    {

        checkPoints = GameObject.Find("CheckPoints").transform;
        checkpointCount = checkPoints.childCount;
        checkPointLayer = LayerMask.NameToLayer("CheckPoint");

        car = GetComponent<Car>();

    }//Awake


    void Update()
    {

        currentLapTime = lapTimer > 0 ? Time.time - lapTimer : 0;


        if (controlType == ControlType.PlayerInput)
        {

            car.steer = GameManager.instance.carController.steerInput;
            car.throttle = GameManager.instance.carController.throttelInput;


        }


    }//Update


    void StartLap()
    {

        Debug.Log("StartLap");
        currentLap++;
        lastCheckpointPass = 1;
        lapTimer = Time.time;

    }//StartLap


    void EndLap()
    {

        lastLapTime = Time.time - lastLapTime;
        bestLapTime = Mathf.Min(lastLapTime, bestLapTime);
        Debug.Log("End Lap - Laptime was " + lastLapTime + " seconds");

        if(currentLap >= finalLap)
        {

            raceOver = true;

        }

    }//EndLap


    private void OnTriggerEnter(Collider collider)
    {

        if (collider.gameObject.layer != checkPointLayer)
            return;

        if(collider.gameObject.name == "1")
        {
        
            if(lastCheckpointPass == checkpointCount)
            {

                EndLap();

            }

            if(currentLap == 0 || lastCheckpointPass == checkpointCount)
            {

                StartLap();

            }
            return;

        }


        if(collider.gameObject.name == (lastCheckpointPass + 1).ToString())
        {

            lastCheckpointPass ++;

        }


    }//OnTriggerEnter


}// PLAYER CONTROLLER
