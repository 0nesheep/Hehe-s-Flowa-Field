using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    public GameObject cloudPrefab;

    public float minSpawnInterval;
    public float radius;
    public Vector2 spawnAreaSize;
    public int maxClouds;

    private int cloudCount = 0;

    public float requestInterval;

    private float timer = 0f;

    void Update()
    {
        cloudCount = GameObject.FindGameObjectsWithTag("Cloud").Length;
        timer += Time.deltaTime;

        float randomInterval = Random.Range(0, 31);

        if (timer >= 5f)
        {
            SpawnCloud();
            timer = 0f;
        }
    }

    void SpawnCloud()
    {
        Debug.Log(cloudCount);
        if (cloudCount < maxClouds)
        {
            float randomY = Random.Range(-spawnAreaSize.y / 2f, spawnAreaSize.y / 2f);

            Vector3 randomPosition = transform.position + new Vector3(-10f, randomY, 0f);

            Instantiate(cloudPrefab, randomPosition, Quaternion.identity);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, new Vector3(spawnAreaSize.x, spawnAreaSize.y, 0f));
    }
}
