using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] int HP = 2;
    [SerializeField] float flash = 0.2f;
    [SerializeField] float distance = 10f;
    private GameObject player;
    Rigidbody2D rb;
    SpriteRenderer sr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
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
        if (collision.gameObject.CompareTag("Piso"))
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
        sr.color = new Color(1, 1, 1);
    }
}
