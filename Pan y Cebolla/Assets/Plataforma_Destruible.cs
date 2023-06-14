using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma_Destruible : MonoBehaviour
{
    [SerializeField] GameObject particulas;
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("Destruir", true);
        }
    }
    public void destruirObjeto()
    {
        Instantiate(particulas, new Vector2(this.transform.position.x, this.transform.position.y), particulas.transform.rotation);
        Destroy(this.gameObject);
    }
}
