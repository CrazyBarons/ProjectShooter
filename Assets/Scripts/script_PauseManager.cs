using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class script_PauseManager : MonoBehaviour
{

    script_MainMenu MM;
    script_CountDownManager CDM;
    public Text PauseText;

    bool gamePaused = false;
    //gameReady is used to coordinate and to avoid letting the player spam the enter button and break the game's pause function
    bool gameReady = true;

    void Start()
    {
        MM = GameObject.Find("MainMenu").GetComponent<script_MainMenu>();
        CDM = GameObject.Find("CountDownManager").GetComponent<script_CountDownManager>();
    }

    void Update()
    {
        if (MM.get_gameRunning() && Input.GetKeyDown(KeyCode.Return) && !CDM.get_counting() && gameReady)
        {
            gameReady = false;
            StartCoroutine(PauseGame());
        }

        if (gamePaused)
        {
            PauseText.enabled = true;
        }
        else
        {
            PauseText.enabled = false; ;
        }

    }

    IEnumerator PauseGame()
    {
        if (gamePaused)
        {
            Time.timeScale = 1.0f;
            gamePaused = false;
        }
        else
        {
            Time.timeScale = 0.0f;
            gamePaused = true;
        }

        yield return new WaitForSecondsRealtime(0.2f);
        gameReady = true;
        StopCoroutine(PauseGame());
    }
}