using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] int HP = 2;
    [SerializeField] float flash = 0.2f;
    [SerializeField] float distance = 10f;
    [SerializeField] SpawnEnemy right;
    private GameObject player;
    Rigidbody2D rb;
    SpriteRenderer sr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        if (!right.isRight)
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

        if(HP <= 0)
        {
            Destroy(this.gameObject);
        }

        if (Vector2.Distance(this.gameObject.transform.position, player.transform.position) > distance)
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
        if (collision.gameObject.CompareTag("Piso") || collision.gameObject.CompareTag("Pared"))
        {
            transform.localScale = new Vector2(-(Mathf.Sign(rb.velocity.x)), transform.localScale.y);
        }
        if (collision.gameObject.CompareTag("Bala"))
        {

            Debug.Log("hit");

            HP -= 1;
            StartCoroutine(flasheo(flash));
        }

    }
    IEnumerator flasheo(float time)
    {
        sr.color = new Color(1,1,1,.5f);
        yield return new WaitForSeconds(time);
        sr.color = new Color(1, 1, 1, 1);
    }
}
