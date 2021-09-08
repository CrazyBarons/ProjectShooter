using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class script_CountDownManager : MonoBehaviour
{
    public Text Count;

    void GameStart()
    {
        StartCoroutine(StartCountdown());
    }

    IEnumerator StartCountdown()
    {
        Count.enabled = true;
        Count.text = "3";
        yield return new WaitForSecondsRealtime(1f);
        Count.text = "2";
        yield return new WaitForSecondsRealtime(1f);
        Count.text = "1";
        yield return new WaitForSecondsRealtime(1f);
        Count.text = "GO!";
        yield return new WaitForSecondsRealtime(1f);
        Count.enabled = false;
        Time.timeScale = 1.0f;
        StopCoroutine(StartCountdown());
    }
}
