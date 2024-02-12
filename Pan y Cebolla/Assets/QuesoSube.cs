using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuesoSube : MonoBehaviour
{
    [SerializeField] PLayerHurt PL;
    [SerializeField] public float Speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(0, Speed *Time.deltaTime, 0);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("queso");
            PL.freeze();
        }
    }
}
