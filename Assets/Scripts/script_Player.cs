using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_Player : MonoBehaviour
{

    public GameObject Bullet;
    Rigidbody RB;
    Vector3 NormalPos = new Vector3(2400f,119f,1430f);

    float horizontalSpeed;
    float verticalSpeed;
    float reloadTime;
    float gravity = 300f;

    bool canShoot = false;
    bool isReloading = false;
    bool isSlowed = false;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
        horizontalSpeed = script_ParameterLoader.get_horizontalSpeed();
        verticalSpeed = script_ParameterLoader.get_runningSpeed();
        reloadTime = script_ParameterLoader.get_reloadTime();

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