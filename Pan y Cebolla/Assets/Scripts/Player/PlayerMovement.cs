using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Variables de control para movimiento del personaje.
    private float velocidad, fuerzaSalto, gravedad;
    private float dashSpeed, dashMultiplier, dashTime, starDashTime;
    protected bool mirandoDerecha;
    public bool saltando;
    private Rigidbody2D RB;

    public enum PlayerActions
    {
        DASH,
        MOVE
    }

    public PlayerActions currentAction;

    // Start is called before the first frame update
    void Start()
    {
        RB = this.gameObject.GetComponent<Rigidbody2D>();

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
        
    }

    public void ManejarMovimiento()
    {
        if( currentAction == PlayerActions.MOVE)
        {
            //Control y movimiento
            float ejeHorizontal = Input.GetAxisRaw("Horizontal");

            RB.velocity = new Vector2(ejeHorizontal * velocidad, RB.velocity.y);

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
        // Verificar que el jugador no este ya en el aire o dasheando.
        if (ejeVertical > 0f && !saltando && currentAction != PlayerActions.DASH){
            RB.velocity = new Vector2(RB.velocity.x, Mathf.Sqrt(2 * fuerzaSalto * gravedad));
            this.saltando = true;
        }    
    }

    public void ManejarDash()
    {
        if (Input.GetKeyDown(KeyCode.Space) && currentAction != PlayerActions.DASH)
        {
            currentAction = PlayerActions.DASH;
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
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Verifica que el jugador se encuentre en contacto con el piso.
        if (collision.gameObject.layer == 8 && this.transform.position.y > collision.transform.position.y)
        {
            saltando = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //Verifica cuando el jugador deja de tocar el piso y entra en estado de salto.
        if (collision.gameObject.layer == 8 && this.transform.position.y > collision.transform.position.y)
        {
            saltando = true;
        }
    }
}
