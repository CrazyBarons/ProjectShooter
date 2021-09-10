using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class script_KillCounter : MonoBehaviour
{

    script_MainMenu MM;
    public Text Count;

    int killRequirement;
    int killCount;

    // Start is called before the first frame update
    void Start()
    {
        MM = GameObject.Find("MainMenu").GetComponent<script_MainMenu>();
        killRequirement = script_ParameterLoader.get_enemyTotal();
        killCount = 0;
    }

    private void Update()
    {
        if (MM.get_gameRunning())
        {
            Count.enabled = true;
        }
        else
        {
            Count.enabled = false;
        }

        if (killCount == killRequirement)
        {
            MM.Win();
            killCount = 0;
        }

        Count.text = "Kill Count: " + killCount.ToString() + "/" + killRequirement.ToString();
    }

    //Called by weapons that kill enemies
    public void KilledOne()
    {
        killCount = killCount + 1;
        return;
    }

    void GameStart()
    {
        killCount = 0;
        return;
    }
}
