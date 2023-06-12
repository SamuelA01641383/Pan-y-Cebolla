using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma_Destruible : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("Destruir", true);
        }
    }
    public void destruirObjeto()
    {
        Destroy(this.gameObject);
    }
}
