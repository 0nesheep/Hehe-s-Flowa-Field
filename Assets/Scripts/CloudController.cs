using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    private Vector2 direction;
    private PlayerScript playerScript;
    private float speed = 0.5f;
    private Rigidbody2D rb;

    private bool playerIn = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
        if (playerIn && Input.GetKeyDown(KeyCode.Space) && !playerScript.checkIsWet())
        {
            Debug.Log("tried to interact with cloud");
            playerScript.startDrink();
            Destroy(this.gameObject, 3f);

        }
        MoveClouds();

    }

    private void MoveClouds()
    {
        rb.MovePosition(rb.position + Vector2.right * speed * Time.deltaTime);

        if (rb.position.x > 30f || rb.position.y > 32f)
        {
            Destroy(this.gameObject);
        }
    }
}
