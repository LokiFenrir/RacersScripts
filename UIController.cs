using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    //Vars

    public GameObject uIPanel;

    public Text currentLapTxt;
    public Text currentTimeTxt;
    public Text lastLapTimeTxt;
    public Text bestLapTimeTxt;
    public Text carName;

    public PlayerController UpdateUIForPlayer;

    int currentLap = -1;
    float currentTime;
    float lastLapTime;
    float bestLapTime;

    public GameObject standingsPanel;

    public Text bestLapTimeStandingsText;
    public Text totalLapTimeText;

    public float totalTime;

    //Func

    void Awake()
    {

        standingsPanel.SetActive(false);

    }


    void Start()
    {

        UpdateUIForPlayer = FindObjectOfType<PlayerController>();

    }//Start

    void Update()
    {

        if (UpdateUIForPlayer == null)
            return;

        if (UpdateUIForPlayer.currentLap != currentLap)
        {

            currentLap = UpdateUIForPlayer.currentLap;
            currentLapTxt.text = $"LAP: {currentLap}";

        }

        if(UpdateUIForPlayer.currentLapTime != currentTime)
        {

            currentTime = UpdateUIForPlayer.currentLapTime;
            currentTimeTxt.text = $"TIME: {(int)currentTime / 60}:{(currentTime) % 60:00.000} ";

        }


        if (UpdateUIForPlayer.lastLapTime != lastLapTime)
        {

            lastLapTime = UpdateUIForPlayer.lastLapTime;
            lastLapTimeTxt.text = $"LAST: {(int)lastLapTime / 60}:{(lastLapTime) % 60:00.000} ";
            LapCalculation();

        }


        if (UpdateUIForPlayer.bestLapTime != bestLapTime)
        {

            bestLapTime= UpdateUIForPlayer.bestLapTime;
            bestLapTimeTxt.text = bestLapTime<100000 ? $"BEST: {(int)bestLapTime / 60}:{(bestLapTime) % 60:00.000} " : "BEST: --.---";

        }

        if(UpdateUIForPlayer.raceOver == true)
        {

            uIPanel.SetActive(false);
            standingsPanel.SetActive(true);
            bestLapTimeStandingsText.text = $" {(int)bestLapTime / 60}:{(bestLapTime) % 60:00.000}";
            totalLapTimeText.text = $"{(int)totalTime / 60}:{(totalTime) % 60:00.000}";
            GameManager gm = FindObjectOfType<GameManager>();
            carName.text = gm.carDriving.ToString();
            StartCoroutine(RaceEnded());

        }

    }//Update


    IEnumerator RaceEnded()
    {

        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene("MainMenu");

    }//RaceEnded


    void LapCalculation()
    {

        totalTime += lastLapTime;
        Debug.Log(totalTime);

    }//LapCalculation


}// UI CONTROLLER
