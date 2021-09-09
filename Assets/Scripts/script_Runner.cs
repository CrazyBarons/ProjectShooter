using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_Runner : script_Enemy
{
    //Distance from the player character
    public float distance;
    float baseSpeed;
    float realSpeed;
    float slowPercentage;

    bool homing;
    bool slow = false;

    Rigidbody RB;
    
    // Start is called before the first frame update
    void Start()
    {
        baseSpeed = -script_ParameterLoader.get_enemySpeed();
        slowPercentage = script_ParameterLoader.get_slowPercent();
        RB = GetComponent<Rigidbody>();
        homing = false;
    }

    // Update is called once per frame
    void Update()
    {

        distance = Mathf.Abs(transform.position.x - P.position.x);

        if (distance >= 300 && !homing)
        {
            RB.velocity = new Vector3(realSpeed, 0f, 0f);
        }
        else
        {
            homing = true;
            //RB.velocity = Vector3.MoveTowards(transform.position, Player.position, -speed * Time.deltaTime * Time.deltaTime);
            RB.velocity = new Vector3(0f, 0f, 0f);
            transform.position = Vector3.MoveTowards(transform.position, P.position, -realSpeed * Time.deltaTime);
        }

        slow = PS.get_isSlowed();

        if (slow)
        {
            realSpeed = baseSpeed + baseSpeed * slowPercentage;
        }
        else
        {
            realSpeed = baseSpeed;
        }
    }

    public override void PlayerHit(GameObject Player)
    {
        MM.Lose();
        return;
    }

}
