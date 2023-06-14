using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ingrediente : MonoBehaviour
{
    [SerializeField] FadeEffect fadeScreen;
    private bool playerTouch = false;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTouch)
        {
            Vector2 newPos = new Vector2(player.transform.position.x, player.transform.position.y + 0.7f);
            this.gameObject.transform.position = newPos;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerMovement>() != null)
        {
            playerTouch = true;
            collision.gameObject.GetComponent<Animator>().SetBool("Dashing", false);
            collision.gameObject.GetComponent<Animator>().SetBool("Victory", true);
            collision.gameObject.GetComponent<PlayerMovement>().enabled = false;
            collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX;
            //this.gameObject.GetComponent<Animator>().SetBool("hold", true);
        }

        Invoke("fade", 3f);
    }

    private void fade()
    {
        fadeScreen.fadeIn();
        if(SceneManager.GetActiveScene().name == "Level1")
        {
            Invoke("goLevel2", 2f);
        }

        if (SceneManager.GetActiveScene().name == "Level2")
        {
            Invoke("goEnd", 2f);
        }
        else
        {
            Invoke("goEnd", 2f);
        }
    }

    private void goLevel2()
    {
        SceneManager.LoadScene("Level2");
    }

    private void goEnd()
    {
        SceneManager.LoadScene("End");
    }
}
