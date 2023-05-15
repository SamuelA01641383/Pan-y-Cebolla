using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileDestruible : MonoBehaviour
{
    public Tilemap Destructibles;

    void Start()
    {
        Destructibles = GetComponent<Tilemap>();
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("h");
        if (collision.gameObject.CompareTag("Bala"))
        {
            
            Vector3 hitPos = Vector3.zero;
            foreach(ContactPoint2D hit in collision.contacts)
            {
                hitPos.x = hit.point.x - 0.001f * hit.normal.x;
                hitPos.y = hit.point.y - 0.001f * hit.normal.y;
                Destructibles.SetTile(Destructibles.WorldToCell(hitPos),null);
            }
        }


    }
}
