using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transitionDoor : MonoBehaviour
{
    public GameObject Fade;
    public GameObject prompt;

    private ChangeScene CS;
    private bool bandera = false;

    private void Update()
    {
        if (bandera)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                CS = Fade.GetComponent<ChangeScene>();
                CS.changeScene();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            prompt.SetActive(true);
            bandera = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        prompt.SetActive(false);
        bandera = false;
    }
}
