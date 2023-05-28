using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeEffect : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    //De ver a Oscuro
    public void fadeIn()
    {
        animator.SetBool("FadeIn", true);
    }

    //De Oscuro a ver
    public void fadeOut()
    {
        animator.SetBool("FadeIn", false);
    }
}
