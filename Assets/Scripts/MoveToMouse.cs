using UnityEngine;
using System.Collections;
public class moveToMouse : MonoBehaviour
{
    [SerializeField] private Animator animator = null;
    [SerializeField] private Transform eyes;
    private bool isMoving = false;
   
    private Vector3 targetPosition;

    private float speed = 3f;
    private Rigidbody2D rb;

    private SpriteRenderer spriteRenderer;

    private Vector3 eyePos;
    private float maxDistance = 0.2f;

    private Vector3 originalScale;

    private bool isFlipped = false;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalScale = transform.localScale;
        eyePos = eyes.localPosition;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
    void Update()
    {

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition = transform.InverseTransformPoint(mousePosition);
        Vector3 eyesDirection = mousePosition - eyePos;
        /*if (isFlipped)
        {
            eyesDirection.x = -eyesDirection.x;
        }*/
        Vector3 temp = Vector2.ClampMagnitude(eyesDirection, maxDistance);
        Vector3 eyeTarget = eyePos + temp;
        eyes.localPosition = eyeTarget;
       
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

            if ((targetPosition.x > transform.position.x && transform.localScale.x > 0) ||
                (targetPosition.x < transform.position.x && transform.localScale.x < 0))
            {
                isFlipped = !isFlipped;
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
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
        }
    }
}