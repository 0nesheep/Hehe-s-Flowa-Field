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

    private Animator animator;

    private bool playerIn = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameObject player = GameObject.FindWithTag("Player");
        playerScript = player.GetComponent<PlayerScript>();
        animator = GetComponent<Animator>();
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
            playerScript.startDrink();
            animator.SetBool("isAbsorbing", true);

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

    public void finishDeath()
    {
        Destroy(this.gameObject);
    }
}
