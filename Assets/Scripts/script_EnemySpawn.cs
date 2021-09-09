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
    bool firstBurst = true;

    int startingEnemy;

    // Start is called before the first frame update
    void Start()
    {
        baseFrequency = script_ParameterLoader.get_enemyFrequency();
        startingEnemy = script_ParameterLoader.get_startingEnemy();
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
                SpawnRunner();
            }
        }

        // The game starts with a number of enemies already on the board (to differentiate the starting point, some of them are already on the board
        if (firstBurst)
        {
            firstBurst = false;
            SpawnBurst(startingEnemy);
        }

    }

    void SpawnBurst(int quantity)
    {
        while (quantity > 0)
        {
            burstRandom = Random.Range(0.0f, 1.0f);
            placeRandom = Random.Range(0.0f, 1.0f);
            Instantiate(Runner, new Vector3(5200f + (burstRandom * 800f), 119f, 1050f + (placeRandom * 800f)), Quaternion.identity);
            quantity = quantity - 1;
        }
        return;
    }

    void SpawnRunner()
    {
        placeRandom = Random.Range(0.0f, 1.0f);
        Instantiate(Runner, new Vector3(5800f, 119f, 1050f + (placeRandom * 800f)), Quaternion.identity);
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
        firstBurst = true;
        return;
    }
}
