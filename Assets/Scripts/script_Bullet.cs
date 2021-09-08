using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_Bullet : script_HitBox
{

    script_ParameterLoader PL;

    float speed;

    void Start()
    {
        PL = GameObject.FindGameObjectWithTag("ParameterLoader").GetComponent<script_ParameterLoader>();
        if (PL != null)
        {
            speed = PL.get_projectileSpeed();
        }
        else
        {
            speed = 450f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(speed, 0f, 0f);
    }

    public override void EnemyHit(GameObject Enemy)
    {
        Destroy(Enemy);
        Destroy(gameObject);
        return;
    }
}
