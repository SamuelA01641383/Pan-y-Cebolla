using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Variables de control para movimiento del personaje.
    private float velocidad, fuerzaSalto, gravedad;
    private float dashSpeed, dashMultiplier, dashTime, starDashTime, dashDelay, startDashDelay;
    public bool mirandoDerecha;
    public bool saltando;
    private Rigidbody2D RB;
    private Animator animator;
    private int airDashCounter = 2;

    public enum PlayerActions
    {
        DASH,
        MOVE,
        SHOT,
        HURT, 
        DEAD
    }

    public PlayerActions currentAction;

    // Start is called before the first frame update
    void Start()
    {
        RB = this.gameObject.GetComponent<Rigidbody2D>();
        animator = this.gameObject.GetComponent<Animator>();

        startDashDelay = 0.1f;
        dashDelay = 0f;
        starDashTime = 0.15f;
        dashTime = starDashTime;
        currentAction = PlayerActions.MOVE;
        velocidad = 7f;
        fuerzaSalto = 3f;
        gravedad = 29.43f;
        dashMultiplier = 4f;
        dashSpeed = velocidad * dashMultiplier;
        mirandoDerecha = true;
        saltando = false;
    }

    private void FixedUpdate()
    {
        ManejarMovimiento();
        ManejarSalto();
        ManejarDash();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(currentAction);
        checkDash();
        
    }
    public void ManejarMovimiento()
    {
        if( currentAction == PlayerActions.MOVE)
        {
            //Control y movimiento
            float ejeHorizontal = Input.GetAxisRaw("Horizontal");

            RB.velocity = new Vector2(ejeHorizontal * velocidad, RB.velocity.y);

            //Animación
            animator.SetBool("Running", RB.velocity.x != 0f);

            //Dirección a la que mira 
            if (RB.velocity.x > 0f && !mirandoDerecha)
            {
                this.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                this.mirandoDerecha = true;

            }
            else if (RB.velocity.x < 0f && mirandoDerecha)
            {
                this.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                this.mirandoDerecha = false;
            }
        }
        
    }

    public void ManejarSalto()
    {
        //Obtener input del usuario.
        float ejeVertical = Input.GetAxisRaw("Vertical");
        
        //SALTO COMÚN
        // Verificar que el jugador no este ya en el aire, dasheando o stuneado.
        if (ejeVertical > 0f && !saltando && currentAction != PlayerActions.DASH && currentAction != PlayerActions.HURT){
            RB.velocity = new Vector2(RB.velocity.x, Mathf.Sqrt(2 * fuerzaSalto * gravedad));

            this.saltando = true;

            //Animación
            animator.SetBool("Jumping", saltando);
        }
        animator.SetFloat("FallingMoment", RB.velocity.y);
    }

    public void ManejarDash()
    {
        if(dashDelay > 0f)
        {
            dashDelay -= Time.deltaTime;
        }

        if (currentAction == PlayerActions.DASH)
        {
            if (mirandoDerecha)
            {
                RB.velocity = new Vector2(dashSpeed, 0);
            }
            else
            {
                RB.velocity = new Vector2 (dashSpeed * -1, 0);
            }

            dashTime -= Time.deltaTime;

            if(dashTime <= 0)
            {
                currentAction = PlayerActions.MOVE;
                RB.velocity = new Vector2(dashSpeed/2,0);
                dashTime = starDashTime;
                dashDelay = startDashDelay;
            }
        }
        animator.SetBool("Dashing", currentAction == PlayerActions.DASH);
    }

    private void checkDash()
    {
        if (Input.GetKeyDown("space") && currentAction != PlayerActions.DASH && dashDelay <= 0 && currentAction != PlayerActions.HURT && currentAction != PlayerActions.DEAD)
        {
            if (saltando && airDashCounter > 0)
            {
                airDashCounter--;
                currentAction = PlayerActions.DASH;
            }
            else if(!saltando)
            {
                currentAction = PlayerActions.DASH;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Verifica que el jugador se encuentre en contacto con el piso.
        if (collision.gameObject.layer == 8 || collision.gameObject.layer == 6)
        {
            saltando = false;
            airDashCounter = 2;
            //Animación
            animator.SetBool("Jumping", saltando);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //Verifica cuando el jugador deja de tocar el piso y entra en estado de salto.
        if (collision.gameObject.layer == 8 || collision.gameObject.layer == 6)
        {
            saltando = true;

            //Animación
            animator.SetBool("Jumping", saltando);
        }
    }
}
