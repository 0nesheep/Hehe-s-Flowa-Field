using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleController : MonoBehaviour
{
    public bool showSpeechBubble = false;
    public float minSpawnInterval = 2f;
    public GameObject bubble;
    private PlayerScript playerScript;

    private bool playerIn = false;

    private float timer = 0f;
    private void Start()
    {
        bubble = transform.Find("Bubble").gameObject;
        bubble.gameObject.SetActive(false);
        GameObject player = GameObject.FindWithTag("Player");
        playerScript = player.GetComponent<PlayerScript>();

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
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
            if (playerScript.checkIsWet())
            {
                Debug.Log("tried to interact");
                showSpeechBubble = false;
                timer = 0f;
                playerScript.water();
            }
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
