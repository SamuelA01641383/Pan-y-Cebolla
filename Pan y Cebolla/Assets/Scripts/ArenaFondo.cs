using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaFondo : MonoBehaviour
{
    [SerializeField] private Vector2 velocidadMov;
    private Vector2 offset;
    private Material material;

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        offset = velocidadMov * Time.deltaTime;
        material.mainTextureOffset += offset;
    }
}
