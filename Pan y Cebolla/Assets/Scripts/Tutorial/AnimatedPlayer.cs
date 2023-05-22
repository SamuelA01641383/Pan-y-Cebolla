using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedPlayer : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D RB;
    public int current = 0;
    private bool running = false;
    private int cont = 0;
    [SerializeField] private Animator house;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        RB = GetComponent<Rigidbody2D>();
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
