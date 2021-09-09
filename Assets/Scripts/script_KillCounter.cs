using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_KillCounter : MonoBehaviour
{

    script_MainMenu MM;

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
        if (killCount == killRequirement)
        {
            MM.Win();
        }
    }

    public void KilledOne()
    {
        killCount = killCount + 1;
        return;
    }

    void GameStart()
    {
        killCount = 0;
    }
}
