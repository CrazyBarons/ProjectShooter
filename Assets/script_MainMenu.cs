using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class script_MainMenu : MonoBehaviour
{

    Image myImage;
    public Sprite MainMenu;
    public Sprite GameOver;
    public Sprite YouWin;

    bool isOnMain = true;
    bool gameRunning = false;
    bool processingEnter = false;

    void Start()
    {
        myImage = GameObject.FindGameObjectWithTag("Canvas").GetComponentInChildren<Image>();
        myImage.sprite = MainMenu;
    }

    void Update()
    {

        //Whenever the player presses Enter, the menu calls for a small coroutine, which guarantees the player doesn't send too many
        //requests at the same time
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (!processingEnter)
            {
                StartCoroutine(EnterPressed());
            }
        }

        //The UI is on whenever the game's not running, covering the screen while the game's not ready
        //While the UI is up, the game's Paused too, so that all of the game's components don't run in the background
        if (gameRunning)
        {
            myImage.enabled = false;
        }
        else
        {
            myImage.enabled = true;
        }


    }

    //Function called wheneer an enemy touches the player
    public void Lose()
    {
        Time.timeScale = 0.0f;
        isOnMain = false;
        myImage.sprite = GameOver;
        gameRunning = false;
        processingEnter = false;
        return;
    }

    //Function called whenever the finish line is touched by the player
    public void Win()
    {
        Time.timeScale = 0.0f;
        isOnMain = false;
        myImage.sprite = YouWin;
        gameRunning = false;
        processingEnter = false;
        return;
    }

    //Coroutine started when the player presses enter and the main menu is up
    IEnumerator EnterPressed()
    {
        processingEnter = true;
        yield return new WaitForSecondsRealtime(0.2f);
        if (isOnMain)
        {
            StartCoroutine(GameOn());
        }
        else
        {
           myImage.sprite = MainMenu;
            isOnMain = true;
            processingEnter = false;
        }
        StopCoroutine(EnterPressed());
    }

    //Coroutine started when the game has to be initialized
    IEnumerator GameOn()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        Object[] all = FindObjectsOfType(typeof(GameObject));
        foreach (GameObject generic in all)
        {
            generic.SendMessage("GameStart", SendMessageOptions.DontRequireReceiver);
        }
        gameRunning = true;
        StopCoroutine(GameOn());
    }

    public bool get_gameRunning()
    {
        return gameRunning;
    }

}
