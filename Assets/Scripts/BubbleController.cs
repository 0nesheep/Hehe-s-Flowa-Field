using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleController : MonoBehaviour
{
    public bool showSpeechBubble = false;
    public float minSpawnInterval = 10f;
    public GameObject bubble;
    public GameObject flowerPart;
    private PlayerScript playerScript;
    private FlowerController flowerControl;
    private bool isPermaDeath = false;

    private bool playerIn = false;

    private float timer = 0f;

    private float timeIgnored = 0f;
    private void Start()
    {
        bubble = transform.Find("Bubble").gameObject;
        bubble.gameObject.SetActive(false);

        flowerPart = transform.Find("FlowerPart").gameObject;

        GameObject player = GameObject.FindWithTag("Player");
        playerScript = player.GetComponent<PlayerScript>();

        flowerControl = this.GetComponent<FlowerController>();

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
            minSpawnInterval = minSpawnInterval * 2;
        }

        if (playerIn && Input.GetKeyDown(KeyCode.Space) && !isPermaDeath)
        {
            if (playerScript.checkIsWet())
            {
                showSpeechBubble = false;
                timer = 0f;
                playerScript.water();
                timeIgnored = 0f;
            }
        }
        if (!isPermaDeath) 
        {

            if (!showSpeechBubble)
            {
                if (bubble != null)
                {
                    bubble.gameObject.SetActive(false);
                }
            }
            else
            {
                if (bubble != null)
                {
                    bubble.gameObject.SetActive(true);
                }
                timeIgnored += Time.deltaTime;
                if (timeIgnored >= 30f)
                {
                    killPlant();
                    bubble.gameObject.SetActive(false);
                    isPermaDeath = true;
                }
            }
        
        } 
            

    }

    private void killPlant()
    {
        flowerControl.startDying();
    }
}
