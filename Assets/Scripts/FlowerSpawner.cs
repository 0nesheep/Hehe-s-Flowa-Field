using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerSpawner : MonoBehaviour
{
    public GameObject flowerPrefeb;
    private Collider2D flowerCollider;
    
    public float minSpawnInterval = 30f;
    public float radius = 5f;
    public Vector2 spawnAreaSize = new Vector2(28f, 30f);

    public static int totalSpawns = 0;

    public float requestInterval = 30f;

    private float timer = 0f;

    private void Start()
    {
        flowerCollider = flowerPrefeb.GetComponent<Collider2D>();
    }

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

        Vector3 randomPosition = new Vector3(randomX, randomY, 0f);
        while (Physics2D.OverlapBox(randomPosition, flowerCollider.bounds.size, 0f))
        {
            randomX = Random.Range(-spawnAreaSize.x / 2f, spawnAreaSize.x / 2f);
            randomY = Random.Range(-spawnAreaSize.y / 2f, spawnAreaSize.y / 2f);
            randomPosition = new Vector3(randomX, randomY, 0f);

        }

        totalSpawns++;
        Instantiate(flowerPrefeb, randomPosition, Quaternion.identity);
    }

    public static int getSpawnCount()
    {
        return totalSpawns;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, new Vector3(spawnAreaSize.x, spawnAreaSize.y, 0f));
    }
}
