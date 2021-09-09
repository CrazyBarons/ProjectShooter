using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_Bullet : script_HitBox
{

    float speed;

    void Start()
    {
        speed = script_ParameterLoader.get_projectileSpeed();
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

    void GameStart()
    {
        Destroy(gameObject);
    }
}
