using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSliderScript : MonoBehaviour
{
    public RectTransform bar;
    public RectTransform slider;
    private float barLength;
    public float totalTime = 480f;  

    private float currentTime = 0f;
    public float totalLength = 193f;
    private float speed;     
    

    void Start()
    {
        speed = totalLength / totalTime;
    }

    void Update()
    {
        if (currentTime < totalTime)
        {
            slider.Translate(Vector2.right * speed * Time.deltaTime);

            currentTime += Time.deltaTime;
        } else if (currentTime >= totalTime) 
        {
            
        }
    }

    void endGame()
    {
        Debug.Log("time reached");
    }
}
