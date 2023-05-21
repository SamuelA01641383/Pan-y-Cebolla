using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CartMan : MonoBehaviour
{
 
    [SerializeField] int HP = 2;
    [SerializeField] float velocidadMov;
    [SerializeField] float flasheo = 0.5f;
    [SerializeField] float distance = 10f;

    private GameObject player;
    public bool mirandoDerecha = true;
    Rigidbody2D RB;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        velocidadMov = 13f;
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();

        if (Vector2.Distance(this.gameObject.transform.position, player.transform.position) > distance)
        {
            Destroy(this.gameObject);
        }
    }

    void Movimiento()
    {
        RB.velocity = new Vector2(velocidadMov * (mirandoDerecha ? 1 : -1), RB.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bala")
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
            Invoke("recover", flasheo);
            
            HP -= 1;
            if (HP <= 0)
            {
                Destroy(this.gameObject);
            }
        }

        if (collision.gameObject.layer == 10)
        {
            collision.gameObject.GetComponent<PLayerHurt>().KnockBack(collision.GetContact(0).normal);
        }
    }

    private void recover()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
    }
}
