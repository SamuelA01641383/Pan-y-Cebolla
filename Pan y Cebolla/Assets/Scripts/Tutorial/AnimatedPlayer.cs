using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedPlayer : MonoBehaviour
{
    private Animator animator;
    public int current = 0;
    private bool running = false;
    [SerializeField] private Animator house;

    // Start is called before the first frame update
    void Start()
    {
        running = false;
        if (running)
        {
            Debug.Log("ala");
        }
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.x == 8.1f)
        {
            house.SetBool("Open", true);
        }
    }

    public void updateCurrent()
    {
        current = current + 1;
        animator.SetInteger("current", current);
    }

    public void turnAround()
    {
        this.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
    }

    public void run()
    {
        running = true;
    }
}
