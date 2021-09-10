using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_RelativeSpeed : MonoBehaviour
{
    
    public Rigidbody RB;
    public script_Player PS;

    public float baseSpeed;
    public float realSpeed;
    public float slowPercentage;

    public bool slow = false;

    public virtual void Start()
    {
        RB = GetComponent<Rigidbody>();
        PS = GameObject.Find("Player").GetComponent<script_Player>();
        baseSpeed = script_ParameterLoader.get_runningSpeed();
        slowPercentage = script_ParameterLoader.get_slowPercent();
    }

    public virtual void Update()
    {
        RB.velocity = new Vector3(realSpeed * 10f, 0f, 0f);
        slow = PS.get_isSlowed();

        if (slow)
        {
            realSpeed = baseSpeed - baseSpeed * slowPercentage;
        }
        else
        {
            realSpeed = baseSpeed;
        }
    }
}
