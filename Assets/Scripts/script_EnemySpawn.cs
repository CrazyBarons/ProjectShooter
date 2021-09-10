using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_EnemySpawn : MonoBehaviour
{
    public GameObject Runner;

    float baseFrequency;
    float waitingTime;
    float timeRandom;
    float placeRandom;
    float burstRandom;

    bool canSpawn = false;
    bool isWaiting = false;

    int startingEnemy;
    int enemyPerSpawn;

    // Start is called before the first frame update
    void Start()
    {
        baseFrequency = script_ParameterLoader.get_enemyFrequency();
        startingEnemy = script_ParameterLoader.get_startingEnemy();
        enemyPerSpawn = script_ParameterLoader.get_enemyVolley();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isWaiting)
        {

            if (!canSpawn)
            {
                isWaiting = true;
                timeRandom = Random.Range(-0.1f, 0.1f);
                waitingTime = baseFrequency * timeRandom;
                StartCoroutine(CoolDown());
            }
            if (canSpawn)
            {
                canSpawn = false;
                SpawnBurst(enemyPerSpawn);
            }
        }

    }

    //This function spawns a given quantity of enemies scattered in a small area outside of the camera scope and behind the player
    void SpawnBurst(int quantity)
    {
        while (quantity > 0)
        {
            burstRandom = Random.Range(0.0f, 1.0f);
            placeRandom = Random.Range(0.0f, 1.0f);
            Instantiate(Runner, new Vector3(5200f + (burstRandom * 800f), 213f, 1050f + (placeRandom * 800f)), Quaternion.Euler(0f, -90f, 0f));
            quantity = quantity - 1;
        }
        return;
    }

    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(baseFrequency);
        yield return new WaitForSeconds(waitingTime);
        canSpawn = true;
        isWaiting = false;
        StopCoroutine(CoolDown());
    }

    void GameStart()
    {
        StopAllCoroutines();
        canSpawn = false;
        isWaiting = false;
        SpawnBurst(startingEnemy);
        return;
    }
}