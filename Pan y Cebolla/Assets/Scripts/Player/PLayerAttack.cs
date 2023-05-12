using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerAttack : MonoBehaviour
{
    [SerializeField] GameObject disparo;
    [SerializeField] GameObject attackSpawn;
    private Animator animator;
    private float delayDisparo;
    private float cadenciaDisparo;

    // Start is called before the first frame update
    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();

        delayDisparo = 0f;
        cadenciaDisparo = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        ManejarDisparo();
    }

    void FixedUpdate()
    {
        
    }
    
    private void ManejarDisparo()
    {
        if ((Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.LeftShift)) && PuedeDisparar())
        {
            
            Instantiate(disparo, new Vector2(attackSpawn.transform.position.x, attackSpawn.transform.position.y), this.gameObject.transform.rotation);
            delayDisparo = Time.time + cadenciaDisparo;
            //this.gameObject.GetComponent<PlayerMovement>().currentAction = PlayerMovement.PlayerActions.SHOT;
            //Invoke("TerminarDisparo", 0.3f);
        }
        animator.SetBool("Disparando", Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.LeftShift));
    }

    private bool PuedeDisparar()
    {
        return Time.time > delayDisparo && this.gameObject.GetComponent<PlayerMovement>().currentAction 
            != PlayerMovement.PlayerActions.DASH; 
    }

    //Se llamara desde la animación de disapro, por ahora se llama tras 0.3 segundos.
    private void TerminarDisparo()
    {
        this.gameObject.GetComponent<PlayerMovement>().currentAction = PlayerMovement.PlayerActions.MOVE;
    }
}
