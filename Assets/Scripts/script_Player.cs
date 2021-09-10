using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_Player : MonoBehaviour
{
    public script_MainMenu MM;
    public GameObject Bullet;
    Rigidbody RB;
    Vector3 NormalPos = new Vector3(2400f,213f,1430f);

    float horizontalSpeed;
    float reloadTime;
    float gravity = 300f;

    bool canShoot = false;
    bool isReloading = false;
    bool isSlowed = false;

    void Start()
    {
        MM = GameObject.Find("MainMenu").GetComponent<script_MainMenu>();
        RB = GetComponent<Rigidbody>();
        horizontalSpeed = script_ParameterLoader.get_horizontalSpeed();
        reloadTime = script_ParameterLoader.get_reloadTime();

    }

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

        if (MM.get_gameRunning()) {
            RB.AddForce(0f, -gravity, 0f);
        }

        //Code to shoot projectiles
        if (!isReloading)
        {
            if (!canShoot)
            {
                isReloading = true;
                StartCoroutine(Reload());
            }
            else
            {
                canShoot = false;
                Instantiate(Bullet, transform.position, Quaternion.identity);
            }
        }

        //This part of code checks if the player fell down the edges of the bridge
        if (Mathf.Abs(RB.velocity.y) >= 600f && MM.get_gameRunning())
        {
            MM.Lose();
            RB.velocity = new Vector3(0f, 0f, 0f);
        }

    }

    public void Slow()
    {
        isSlowed = true;
        StopCoroutine(SlowCooldown());
        StartCoroutine(SlowCooldown());
        return;
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadTime);
        canShoot = true;
        isReloading = false;
        StopCoroutine(Reload());
    }

    IEnumerator SlowCooldown()
    {
        yield return new WaitForSeconds(3.0f);
        isSlowed = false;
        StopCoroutine(Reload());
    }

    public bool get_isSlowed()
    {
        return isSlowed;
    }

    void GameStart()
    {
        StopAllCoroutines();
        isReloading = false;
        canShoot = false;
        isSlowed = false;
        transform.position = NormalPos;
        return;
    }
}