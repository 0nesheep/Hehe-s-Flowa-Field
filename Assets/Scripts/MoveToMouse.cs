using UnityEngine;
using System.Collections;
public class moveToMouse : MonoBehaviour
{
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
            
        }
        //transform.position = Vector2.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smoothTime, speed);
        Vector3 direction = targetPosition - transform.position;
        rb.MovePosition(rb.position + ((Vector2)direction * speed * Time.deltaTime));
    }
}