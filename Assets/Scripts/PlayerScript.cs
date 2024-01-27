using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private Animator animator = null;

    public void startDrink()
    {
        animator.SetBool("isDrinkingCloud", true);
    }

    public void finishDrink()
    {
        animator.SetBool("isDrinkingCloud", false);
        animator.SetBool("isWet", true);
    }

    public void water()
    {
        animator.SetBool("isWet", false);
        animator.SetBool("isWatering", true);

    }

    public void finishWater()
    {
        animator.SetBool("isWatering", false);
    }

    public bool checkIsWet()
    {
        return animator.GetBool("isWet");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
