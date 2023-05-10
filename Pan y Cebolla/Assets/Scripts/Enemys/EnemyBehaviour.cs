using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] int HP = 2;
    Rigidbody2D rb;
    SpriteRenderer sr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (FacingRight())
        {
            rb.velocity = new Vector2(moveSpeed, 0f);
        }
        else
        {
            rb.velocity = new Vector2(-moveSpeed, 0f);
        }

        if(HP <= 0)
        {
            Destroy(this.gameObject);
        }

    }
    private bool FacingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Piso"))
        {
            transform.localScale = new Vector2(-(Mathf.Sign(rb.velocity.x)), transform.localScale.y);
        }
        if (collision.gameObject.CompareTag("Bala"))
        {

            Debug.Log("hit");

            HP -= 1;
            StartCoroutine(flasheo(0.2f));
        }

    }
    IEnumerator flasheo(float time)
    {
        sr.enabled = false;
        yield return new WaitForSeconds(time);
        sr.enabled = true;
    }
}
