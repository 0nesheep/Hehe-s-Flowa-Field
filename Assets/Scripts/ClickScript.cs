using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickScript : MonoBehaviour
{
    public GameObject clickPrefab;
    private bool isMouseButtonDown = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isMouseButtonDown = true;
        }
        if (isMouseButtonDown && Input.GetMouseButtonUp(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;
            Instantiate(clickPrefab, mousePosition, Quaternion.identity);
            isMouseButtonDown = false;
        }
        
    }

}
