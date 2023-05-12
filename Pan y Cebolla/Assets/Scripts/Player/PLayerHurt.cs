using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerHurt : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D RB;
    // Start is called before the first frame update
    void Start()
    {
      animator = this.gameObject.GetComponent<Animator>();
        RB = this.gameObject.GetComponent<Rigidbody2D>();   
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
            //var magnitude = 1000f;

            //if (this.transform.position.x >= collision.gameObject.transform.position.x)
            //{
            //    RB.AddForce(Vector2.right * magnitude);
            //}
            //else
            //{
            //    RB.AddForce(Vector2.left * magnitude);
            //}

            //Animación
            animator.SetTrigger("Hurt");
            this.gameObject.GetComponent<PlayerMovement>().currentAction = PlayerMovement.PlayerActions.HURT;
        }
    }

    public void FinishHurt()
    {
        Debug.Log("Finish hurt");
        this.gameObject.GetComponent<PlayerMovement>().currentAction = PlayerMovement.PlayerActions.MOVE;
    }
}
