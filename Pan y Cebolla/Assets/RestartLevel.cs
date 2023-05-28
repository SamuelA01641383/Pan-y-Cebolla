using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RestartLevel : MonoBehaviour
{
    [SerializeField] FadeEffect fadeInScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("h");
            name = SceneManager.GetActiveScene().name;
            
            //Hay un script llamado FadeEffect en el objeto fade con las funciones de fadeIn y fadeOut para activar las animaciones.
            //El if es para que se pueda desactivar el objeto fade en la escena para trabajar y que no cuase problemas.
            if (fadeInScreen.isActiveAndEnabled)
            {
                fadeInScreen.fadeIn();
            }
            
            //Esperas 1 segundo antes de recargar la escena, sino no das tiempo a que se vea el efecto.
            Invoke("reload", 1f);
        }
    }

    private void reload()
    {
        SceneManager.LoadScene(name);
    }
}
