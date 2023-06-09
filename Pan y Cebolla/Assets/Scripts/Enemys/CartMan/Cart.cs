using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cart : MonoBehaviour
{
    [SerializeField] CartMan cartMan;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 12 || collision.gameObject.layer == 6)
        {
            if (cartMan.mirandoDerecha)
            {
                cartMan.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                cartMan.mirandoDerecha = false;
            }
            else
            {
                cartMan.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                cartMan.mirandoDerecha= true;
            }
        }

        if (collision.gameObject.layer == 10)
        {
            collision.gameObject.GetComponent<PLayerHurt>().KnockBack(collision.GetContact(0).normal);
        }
    }
}
