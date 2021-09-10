using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_Bullet : script_HitBox
{

    float projectileSpeed;

    public override void Start()
    {
        RB = GetComponent<Rigidbody>();
        PS = GameObject.Find("Player").GetComponent<script_Player>();
        baseSpeed = script_ParameterLoader.get_runningSpeed();
        slowPercentage = script_ParameterLoader.get_slowPercent();
        projectileSpeed = script_ParameterLoader.get_projectileSpeed();
    }
    
    public override void Update()
    {
        RB.velocity = new Vector3(realSpeed, 0f, 0f);
        slow = PS.get_isSlowed();

        if (slow)
        {
            realSpeed = projectileSpeed - baseSpeed * slowPercentage;
        }
        else
        {
            realSpeed = projectileSpeed;
        }
    }

    public override void EnemyHit(GameObject Enemy)
    {
        KC.KilledOne();
        Destroy(Enemy);
        Destroy(gameObject);
        return;
    }

    void GameStart()
    {
        Destroy(gameObject);
    }
}