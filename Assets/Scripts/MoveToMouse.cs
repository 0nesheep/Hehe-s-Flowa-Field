using UnityEngine;
using System.Collections;
public class moveToMouse : MonoBehaviour
{
    [SerializeField] private Animator animator = null;
    private bool isMoving = false;
   
    private Vector3 targetPosition;

    private float speed = 3f;
    private Rigidbody2D rb;

    private SpriteRenderer spriteRenderer;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            isMoving = true;
            animator.SetBool("isWalking", true);
            
        }

        if (isMoving)
        {
            //transform.position = Vector2.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smoothTime, speed);
            Vector3 direction = targetPosition - transform.position;
            rb.MovePosition(rb.position + ((Vector2)direction * speed * Time.deltaTime));

            if (targetPosition.x > transform.position.x)
            {
                spriteRenderer.flipX = true;
            }
            else if (targetPosition.x < transform.position.x)
            {
                spriteRenderer.flipX = false;
            }

            if (Vector3.Distance(transform.position, targetPosition) < 10.05f)
            {
                isMoving = false;
            }
        }
    }

    public void finishAnimation()
    {
        if (!isMoving)
        {
            animator.SetBool("isWalking", false);
            Debug.Log("Stopped walking");
        }
    }
}