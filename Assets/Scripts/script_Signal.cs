using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class script_Signal : script_RelativeSpeed
{

    script_WaypointSpawner WS;
    public Text Number;

    // Start is called before the first frame update
    public override void Start()
    {
        RB = GetComponent<Rigidbody>();
        WS = GameObject.Find("WaypointSpawner").GetComponent<script_WaypointSpawner>();
        PS = GameObject.Find("Player").GetComponent<script_Player>();
        Number.text = WS.get_currentSignal().ToString();
        baseSpeed = script_ParameterLoader.get_runningSpeed();
        slowPercentage = script_ParameterLoader.get_slowPercent();
    }

    void GameStart()
    {
        Destroy(gameObject);
        return;
    }
}
