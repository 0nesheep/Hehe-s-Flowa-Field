using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerSpawner : MonoBehaviour
{
    public GameObject flowerPrefeb;
    
    public float minSpawnInterval = 30f;
    public float radius = 5f;
    public Vector2 spawnAreaSize = new Vector2(28f, 30f);

    public float requestInterval = 30f;

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        float randomInterval = Random.Range(0, 31);

        if (timer >= 5f)
        {
            SpawnFlower();
            timer = 0f;
        }
    }

    void SpawnFlower()
    {
        float randomX = Random.Range(-spawnAreaSize.x / 2f, spawnAreaSize.x / 2f);
        float randomY = Random.Range(-spawnAreaSize.y / 2f, spawnAreaSize.y / 2f);

        Vector3 randomPosition = transform.position + new Vector3(randomX, randomY, 0f);

        Instantiate(flowerPrefeb, randomPosition, Quaternion.identity);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, new Vector3(spawnAreaSize.x, spawnAreaSize.y, 0f));
    }
}
