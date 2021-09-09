using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class script_Signal : MonoBehaviour
{

    Rigidbody RB;
    script_WaypointSpawner WS;
    public Text Number;

    float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
        WS = GameObject.Find("WaypointSpawner").GetComponent<script_WaypointSpawner>();
        Number.text = WS.get_currentSignal().ToString();
        speed = script_ParameterLoader.get_runningSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        RB.velocity = new Vector3(speed * 10f, 0f, 0f);
    }

    void StartGame()
    {
        Destroy(gameObject);
        return;
    }
}
