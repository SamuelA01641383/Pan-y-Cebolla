using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlataforma : MonoBehaviour
{
    public Plataforma_Destruible Plat;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
        }
    }
   
}
