using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    public GameObject cloudPrefab;

    public float minSpawnInterval = 10f;
    public float radius = 5f;
    public Vector2 spawnAreaSize = new Vector2(28f, 15f);
    public int maxClouds = 3;

    private int cloudCount = 0;

    public float requestInterval = 30f;

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
        if (cloudCount < maxClouds)
        {
            float randomY = Random.Range(-spawnAreaSize.y / 2f, spawnAreaSize.y / 2f);

            Vector3 randomPosition = transform.position + new Vector3(-14f, randomY, 0f);

            Instantiate(cloudPrefab, randomPosition, Quaternion.identity);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, new Vector3(spawnAreaSize.x, spawnAreaSize.y, 0f));
    }
}
