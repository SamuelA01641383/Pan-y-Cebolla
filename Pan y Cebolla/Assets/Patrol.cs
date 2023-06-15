using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] int HP = 2;
    [SerializeField] float flash = 0.2f;
    [SerializeField] bool right;
    private GameObject player;
    Rigidbody2D rb;
    SpriteRenderer sr;
    BoxCollider2D bx;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        bx = GetComponent<BoxCollider2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        if (right)
        {
            transform.localScale = new Vector2(-(Mathf.Sign(rb.velocity.x)), transform.localScale.y);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (FacingRight())
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }

        if (HP <= 0)
        {
            Destroy(this.gameObject);
        }


    }
    private bool FacingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }
    
   
    IEnumerator flasheo(float time)
    {
        sr.color = new Color(1, 1, 1, .5f);
        yield return new WaitForSeconds(time);
        sr.color = new Color(1, 1, 1, 1);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Piso"))
        {
            transform.localScale = new Vector2(-(Mathf.Sign(rb.velocity.x)), transform.localScale.y);
        }
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bala"))
        {

            Debug.Log("hit");

            HP -= 1;
            StartCoroutine(flasheo(flash));
        }
    }
}
