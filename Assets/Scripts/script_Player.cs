using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_Player : MonoBehaviour
{

    public GameObject Bullet;
    script_ParameterLoader PL;
    Rigidbody RB;
    Vector3 NormalPos = new Vector3(2400f,130f,1430f);

    float horizontalSpeed;
    float reloadTime;
    float gravity = 300f;

    bool canShoot = false;
    bool isReloading = false;

    // Start is called before the first frame update
    void Start()
    {
        PL = GameObject.FindGameObjectWithTag("ParameterLoader").GetComponent<script_ParameterLoader>();
        RB = GetComponent<Rigidbody>();
        if(PL != null)
        {
            horizontalSpeed = PL.get_horizontalSpeed();
            reloadTime = PL.get_reloadTime();
        }
        else
        {
            horizontalSpeed = 300f;
            reloadTime =1.5f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Code That Moves the Player
        if (Input.GetKey("a") && !Input.GetKey("d"))
        {
            RB.velocity = new Vector3(0f, RB.velocity.y, -horizontalSpeed);
        }
        if (Input.GetKey("d") && !Input.GetKey("a"))
        {
            RB.velocity = new Vector3(0f, RB.velocity.y, horizontalSpeed);
        }
        if ((!Input.GetKey("d") && !Input.GetKey("a")) || (Input.GetKey("d") && Input.GetKey("a")))
        {
            RB.velocity = new Vector3(0f, RB.velocity.y, 0f);
        }

        RB.AddForce(0f, -gravity, 0f);

        //Code to shoot projectiles
        if (!canShoot && !isReloading)
        {
            StartCoroutine(Reload());
        }
        
        if(canShoot)
        {
            canShoot = false;
            Instantiate(Bullet, transform.position, Quaternion.identity);
        }
    }

    void GameStart()
    {
        transform.position = NormalPos;
        return;
    }

    IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);
        canShoot = true;
        isReloading = false;
        StopCoroutine(Reload());
    }

}