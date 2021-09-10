using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class script_CountDownManager : MonoBehaviour
{
    public Text Count;

    bool counting = false;

    IEnumerator StartCountdown()
    {
        counting = true;
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
        counting = false;
        StopCoroutine(StartCountdown());
    }

    public bool get_counting()
    {
        return counting;
    }

    void GameStart()
    {
        StartCoroutine(StartCountdown());
    }
}