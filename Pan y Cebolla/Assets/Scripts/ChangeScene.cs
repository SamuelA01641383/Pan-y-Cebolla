using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    private AssetBundle ab;
    [SerializeField] FadeEffect fadeInScreen;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeScene()
    {
        if (SceneManager.GetActiveScene().name == "TutorialCinematic")
        {
            SceneManager.LoadScene("TutorialLevel");

        }else if (SceneManager.GetActiveScene().name == "TutorialLevel")
        {
            SceneManager.LoadScene("Level1");
        }
    }

    public void fadeIn()
    {
        if (fadeInScreen.isActiveAndEnabled)
        {
            fadeInScreen.fadeIn();
        }
        Invoke("changeScene", 1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            fadeIn();
        }
    }
}
