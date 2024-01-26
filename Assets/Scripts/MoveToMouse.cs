using UnityEngine;
using System.Collections;
public class moveToMouse : MonoBehaviour
{
    private Vector2 targetPosition;

    private float speed = 5f;
    private Rigidbody2D rb;
    private float smoothTime = 0.3f;
    Vector2 currentVelocity;
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
        transform.position = Vector2.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smoothTime, speed);
    }
}