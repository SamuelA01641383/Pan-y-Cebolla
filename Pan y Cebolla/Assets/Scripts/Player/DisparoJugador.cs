using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoJugador : MonoBehaviour
{
    private float velocidad, lifeSpan;
    //private float dano;

    // Start is called before the first frame update
    void Start()
    {
        lifeSpan = 1f;
        velocidad = 20f;
       // dano = 10; //Este valor aun no hace nada
        Invoke("DestruirProyectil", lifeSpan);   
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
    }

    private void Movimiento()
    {
        this.transform.Translate(Vector2.right * velocidad * Time.deltaTime, Space.Self);
    }

    private void DestruirProyectil()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        DestruirProyectil();
    }
}
