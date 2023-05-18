using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerHurt : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D RB;
    private Vector2 knockBack;
    private SpriteRenderer SR;
    
    // Start is called before the first frame update
    void Start()
    {
      animator = this.gameObject.GetComponent<Animator>();
      RB = this.gameObject.GetComponent<Rigidbody2D>();
      SR = this.gameObject.GetComponent<SpriteRenderer>();
      knockBack.x = 10;
      knockBack.y = 10;   
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Recibir da�o.
        if (collision.gameObject.layer == 9)
        {
            //Animaci�n
            animator.SetBool("Hurt", true);
            this.gameObject.GetComponent<PlayerMovement>().currentAction = PlayerMovement.PlayerActions.HURT;
            Physics2D.IgnoreLayerCollision(10,9,true);
            SR.color = new Color(1f, 1f, 1f, .5f);
            Invoke("FinishHurt", 0.5f);
        }
    }

    //Se llama en el ultimo frame de la animaci�n de HURT.
    public void FinishHurt()
    {
        Debug.Log("Finish hurt");
        animator.SetBool("Hurt", false);
        this.gameObject.GetComponent<PlayerMovement>().currentAction = PlayerMovement.PlayerActions.MOVE;
        Physics2D.IgnoreLayerCollision(10, 9, false);
        SR.color = new Color(1f, 1f, 1f, 1f);
    }

    public void KnockBack(Vector2 puntoGolpe)
    {
        RB.velocity = new Vector2(-knockBack.x * puntoGolpe.x, knockBack.y);
    }
}
