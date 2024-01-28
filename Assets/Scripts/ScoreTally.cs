using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreTally : MonoBehaviour
{
    private int deaths;
    private int spawns;
    public TextMeshProUGUI deathCountText;
    public TextMeshProUGUI aliveCountText;
    void Start()
    {
        deaths = FlowerController.getDeaths();
        spawns = FlowerSpawner.getSpawnCount();
        int alive = spawns - deaths;
        aliveCountText.text = alive.ToString();
        deathCountText.text = deaths.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
