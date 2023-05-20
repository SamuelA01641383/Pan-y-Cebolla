using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedPlayer : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D RB;
    private int current = 0;
    private bool running = false;
    private int cont = 0;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        RB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (current == 4)
        //{
        //    Invoke("updateCurrent", 2f);
        //}

        //if (current == 1)
        //{
        //    Invoke("updateCurrent", 4f);
        //}
    }

    private void updateCurrent()
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
