using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    //Vars

    public Transform target;

    public Vector3 offset;
    public Vector3 eulerRotation;
    public float damper;

    //Func

    void Start()
    {

        transform.eulerAngles = eulerRotation;
        // Sets the transforms angles to the eulers rotations.

        if (GameObject.FindGameObjectWithTag("DragRacer"))
            target = GameObject.FindGameObjectWithTag("DragRacer").GetComponent<Transform>();
        else if (GameObject.FindGameObjectWithTag("DodgeRacer"))
            target = GameObject.FindGameObjectWithTag("DodgeRacer").GetComponent<Transform>();
        else if (GameObject.FindGameObjectWithTag("Bucket_Racer"))
            target = GameObject.FindGameObjectWithTag("Bucket_Racer").GetComponent<Transform>();

    }//Start


    void Update()
    {

        if (target == null)
            return;

        transform.position = Vector3.Lerp(transform.position, target.position + offset, damper * Time.deltaTime);
                                                                                    
                                                                                // If the cameras target is null it returns the script. The camera position is then 
                                                                                // pmade to follow the target at the offset distance, with the smoothing factor added.
        
    }//Update


}// CAMERA FOLLOw
