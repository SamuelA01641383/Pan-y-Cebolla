using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerHurt : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D RB;
    private Vector2 knockBack;

    // Start is called before the first frame update
    void Start()
    {
      animator = this.gameObject.GetComponent<Animator>();
      RB = this.gameObject.GetComponent<Rigidbody2D>();
      knockBack.x = 10;
      knockBack.y = 10;   
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Recibir daño.
        if (collision.gameObject.layer == 9)
        {
            //Animación
            animator.SetBool("Hurt", true);
            this.gameObject.GetComponent<PlayerMovement>().currentAction = PlayerMovement.PlayerActions.HURT;
            Physics2D.IgnoreLayerCollision(10,9,true);
        }
    }

    //Se llama en el ultimo frame de la animación de HURT.
    public void FinishHurt()
    {
        Debug.Log("Finish hurt");
        animator.SetBool("Hurt", false);
        this.gameObject.GetComponent<PlayerMovement>().currentAction = PlayerMovement.PlayerActions.MOVE;
        Physics2D.IgnoreLayerCollision(10, 9, false);
    }

    public void KnockBack(Vector2 puntoGolpe)
    {
        RB.velocity = new Vector2(-knockBack.x * puntoGolpe.x, knockBack.y);
    }
}
