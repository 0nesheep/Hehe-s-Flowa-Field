using UnityEngine;
using System.Collections;
public class moveToMouse : MonoBehaviour
{
    [SerializeField] private Animator animator = null;
    private bool isMoving = false;
   
    private Vector3 targetPosition;

    private float speed = 3f;
    private Rigidbody2D rb;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
            if (Vector3.Distance(transform.position, targetPosition) < 0.05f)
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