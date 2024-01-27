using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    public Transform body;
    public Transform head;
    public float maxDistance = 0.5f;
    private float speed = 10;
    private Vector3 initialPos;
    void Start()
    {
        initialPos = body.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePosition - body.position;
        Vector3 temp = Vector2.ClampMagnitude(direction, maxDistance);
        Debug.Log(temp);
        Debug.Log("headpos " + body.position);

        Vector3 targetPosition = body.position + temp;
        Debug.Log("targetpos: " + targetPosition);
        head.position = targetPosition;
    }
}
