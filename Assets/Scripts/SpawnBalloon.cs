using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnBalloon : MonoBehaviour
{
    public GameObject balloon;
    public Transform[] SpawnPoints;
    private float randomWait;
    [SerializeField]  private float minWaitTime = 0.25f;
    [SerializeField]  private float maxWaitTime = 5f;
    [SerializeField]  private float totalPlayTime = 120f; // 2 minutes in seconds

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartSpawning());
    }

    IEnumerator StartSpawning()
    {
        while (true)
        {
            for (int i = 0; i < SpawnPoints.Length; i++)
            {
                float elapsedTime = Time.timeSinceLevelLoad;

                // Gradually reduce random wait time as player keeps playing
                float currentWaitTime = Mathf.Lerp(maxWaitTime, minWaitTime, elapsedTime / totalPlayTime);
                randomWait = UnityEngine.Random.Range(minWaitTime, currentWaitTime);

                yield return new WaitForSeconds(randomWait);
                Instantiate(balloon, SpawnPoints[i].position, Quaternion.identity);
            }
        }
    }
}
