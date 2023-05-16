using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] float distance;
    private GameObject player;
    public GameObject Enemy;
    private Transform T;
    private bool Flag;
    
    void Start()
    {
        T = this.transform;
        Flag = false;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(T.position, player.transform.position) <= distance && !Flag)
        {
            Debug.Log("h");
            Instantiate(Enemy, new Vector2(T.position.x, T.position.y),this.gameObject.transform.rotation);
            Flag = true;
        }
        if(Vector2.Distance(T.position, player.transform.position) > distance)
        {
            Flag = false;
        }
    }
}
