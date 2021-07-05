using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAnimation : MonoBehaviour
{

    //Var

    [SerializeField]
    Vector3 finalPos;
    Vector3 initialPos;


    //Func

    void Awake()
    {

        initialPos = transform.position;

    }//Awake


    void Update()
    {

        transform.position = Vector3.Lerp(transform.position, finalPos, 0.1f);

    }//Update


    void OnDisable()
    {

        transform.position = initialPos;

    }//OnDisable


}// CAR ANIMATION
