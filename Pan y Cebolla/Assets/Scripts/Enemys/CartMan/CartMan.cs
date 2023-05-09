using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartMan : MonoBehaviour
{
 
    int HP = 5;
    Rigidbody2D RB;
    float velocidadMov;
    public bool mirandoDerecha = true;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        velocidadMov = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
    }

    void Movimiento()
    {
        RB.velocity = new Vector2(velocidadMov * (mirandoDerecha ? 1 : -1), RB.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bala")
        {
            //Debug.Log(this.gameObject.name);
            HP -= 1;
        }

        if (HP <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
