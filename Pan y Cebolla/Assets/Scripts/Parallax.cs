using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private Vector2 velocidadMov;
    private Vector2 offset;
    private Material material;
    private Rigidbody2D jugador;

    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        offset = (jugador.velocity.x * 0.1f) * velocidadMov * Time.deltaTime;
        material.mainTextureOffset += offset;
    }
}
