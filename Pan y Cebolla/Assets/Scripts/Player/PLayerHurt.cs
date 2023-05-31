using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PLayerHurt : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D RB;
    private Vector2 knockBack;
    private SpriteRenderer SR;
    private int HP;
    [SerializeField] int HPsetting;
    private BarraVida barraVida;
    
    // Start is called before the first frame update
    void Start()
    {
      barraVida = FindObjectOfType<BarraVida>();

      animator = this.gameObject.GetComponent<Animator>();
      RB = this.gameObject.GetComponent<Rigidbody2D>();
      SR = this.gameObject.GetComponent<SpriteRenderer>();
      knockBack.x = 10;
      knockBack.y = 10;
      HP = HPsetting;
      name = SceneManager.GetActiveScene().name;
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
            
            HP -= 1;
            if (HP <= 0)
            {
                animator.SetBool("Dead", true);
                this.gameObject.GetComponent<PlayerMovement>().currentAction = PlayerMovement.PlayerActions.DEAD;
                Physics2D.IgnoreLayerCollision(10, 9, true);
                SR.color = new Color(1f, 1f, 1f, .5f);
            }
            else
            {
                //Animación
                animator.SetBool("Hurt", true);
                this.gameObject.GetComponent<PlayerMovement>().currentAction = PlayerMovement.PlayerActions.HURT;
                Physics2D.IgnoreLayerCollision(10, 9, true);
                SR.color = new Color(1f, 1f, 1f, .5f);
                Invoke("FinishHurt", 0.5f);
            }

            barraVida.setHP();
        }
    }

    public void FinishDead()
    {
        SR.color = new Color(1f, 1f, 1f, 1f);
        reload();
    }

    private void reload()
    {


        //change.fadeIn();
        SceneManager.LoadScene(name);
        Physics2D.IgnoreLayerCollision(10, 9, false);
        HP = HPsetting;
    }
    //Se llama en el ultimo frame de la animación de HURT.
    public void FinishHurt()
    {
        //Debug.Log("Finish hurt");
        animator.SetBool("Hurt", false);
        this.gameObject.GetComponent<PlayerMovement>().currentAction = PlayerMovement.PlayerActions.MOVE;
        Physics2D.IgnoreLayerCollision(10, 9, false);
        SR.color = new Color(1f, 1f, 1f, 1f);
    }

    public void KnockBack(Vector2 puntoGolpe)
    {
        RB.velocity = new Vector2(-knockBack.x * puntoGolpe.x, knockBack.y);
    }

    public int getHP()
    {
        return HP;
    }

    public int getMaxHP()
    {
        return HPsetting;
    }
}
