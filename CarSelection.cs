using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CarSelection : MonoBehaviour
{

    //Vars

    [SerializeField]
    Button previousBtn;
    [SerializeField]
    Button nextBtn;

    int currentCar;

    public string carType;
    public int carValue;

    //Func


    void Awake()
    {

        SelectCar(0);

    }//Awake


    void SelectCar(int _index)
    {

        previousBtn.interactable = (_index != 0);
        nextBtn.interactable = (_index != transform.childCount - 1);

        for(int i = 0; i < transform.childCount; i++)
        {

            transform.GetChild(i).gameObject.SetActive(i == _index);

        }

        carValue = _index;

    }//SelectCar


    public void ChangeCar(int _change)
    {

        currentCar += _change;
        SelectCar(currentCar);

    }//ChangeCar;


    private void Update()
    {

        if (carValue == 0)
            carType = "Dodge";
        else if (carValue == 1)
            carType = "Drag";
            
    }


    public void EnterSelection()
    {



        PlayerPrefs.SetString("Driving_This", carType);
        SceneManager.LoadScene("Track_Scene");

    }


    // Use this script to find the game objects name. and set up a playerpref.

}// CAR SELECTION
