using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_WallSpawn : MonoBehaviour
{

    public GameObject Wall;

    float baseFrequency;
    float waitingTime;
    float wallPattern;
    float timeRandom;

    bool canSpawn = false;
    bool isWaiting = false;

    void Start()
    {
        baseFrequency = script_ParameterLoader.get_wallsFrequency();
    }

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
                wallPattern = Random.Range(0.0f, 1.0f);
                if (wallPattern < 0.33f)
                {
                    Instantiate(Wall, new Vector3(-4990f, 88f, 1120f), Quaternion.identity);
                    Instantiate(Wall, new Vector3(-4990f, 88f, 1445f), Quaternion.identity);
                }
                else if (wallPattern > 0.67f)
                {
                    Instantiate(Wall, new Vector3(-4990f, 88f, 1445f), Quaternion.identity);
                    Instantiate(Wall, new Vector3(-4990f, 88f, 1770f), Quaternion.identity);
                }
                else if (wallPattern <= 0.67f && wallPattern >= 0.33f)
                {
                    Instantiate(Wall, new Vector3(-4990f, 88f, 1120f), Quaternion.identity);
                    Instantiate(Wall, new Vector3(-4990f, 88f, 1770f), Quaternion.identity);
                }

            }
        }
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
        return;
    }
}
