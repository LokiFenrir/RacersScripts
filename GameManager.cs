using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    //Vars

    public static GameManager instance { get; private set; }
    public CarController carController { get; private set; }

    public string carDriving;
    public GameObject startPoint;
    public GameObject dodgePoint;

    public GameObject dragRacer;
    public GameObject dodgeRacer;


    //Func

    void Awake()
    {

        instance = this;
        carController = GetComponentInChildren<CarController>();
                                                                        // Sets the GameManager to the instance and gets the car controller script in this
                                                                        // objects children.

        carDriving = PlayerPrefs.GetString("Driving_This");

    }//Awake


    void Start()
    {

        if (carDriving == "Drag")
            Instantiate(dragRacer, startPoint.transform);

        if (carDriving == "Dodge")
            Instantiate(dodgeRacer, dodgePoint.transform);

        FindObjectOfType<AudioManager>().Play("Race_Theme");
        FindObjectOfType<AudioManager>().Stop("Menu_Theme");

    }//Start


}// GAME MANAGER
