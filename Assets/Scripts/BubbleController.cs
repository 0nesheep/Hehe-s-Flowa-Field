using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleController : MonoBehaviour
{
    public bool showSpeechBubble = false;
    public float minSpawnInterval = 2f;
    public GameObject bubble;
    private SpriteRenderer bubbleRenderer;

    private float timer = 0f;
    private void Start()
    {
        bubble = transform.Find("Bubble").gameObject;
        bubble.gameObject.SetActive(false);

    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > minSpawnInterval)
        {
            showSpeechBubble = true;
        }
        if (!showSpeechBubble)
        {
            if (bubble != null)
            {
                bubble.gameObject.SetActive(false);
            }
        } else
        {
            if (bubble != null)
            {
                bubble.gameObject.SetActive(true);
            }
        }

    }
}
