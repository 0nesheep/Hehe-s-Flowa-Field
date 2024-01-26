using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleController : MonoBehaviour
{
    public bool showSpeechBubble = false;
    public float minSpawnInterval = 2f;
    public GameObject bubble;

    private bool playerIn = false;

    private float timer = 0f;
    private void Start()
    {
        bubble = transform.Find("Bubble").gameObject;
        bubble.gameObject.SetActive(false);

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.tag);
        if (other.CompareTag("Player"))
        {
            playerIn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIn = false;
        }
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > minSpawnInterval)
        {
            showSpeechBubble = true;
        }

        if (playerIn && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("tried to interact");
            showSpeechBubble = false;
            timer = 0f;
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
