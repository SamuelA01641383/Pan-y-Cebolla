using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] GameObject firstScreen;
    [SerializeField] GameObject secondScreen;
    [SerializeField] Animator Logo;
    [SerializeField] Animator ContinueText;
    [SerializeField] FadeEffect fadeScreen;

    private bool trackEnter = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && trackEnter)
        {
            trackEnter = false;
            Logo.SetBool("Fade", true);
            ContinueText.SetBool("Fade", true);
            Invoke("ChangeScreens", 1f);
        }
    }

    public void ChangeScreens()
    {
        firstScreen.SetActive(false);
        secondScreen.SetActive(true);
    }

    public void startGame()
    {
        fadeScreen.fadeIn();
        Invoke("changeScene", 1f);
    }

    private void changeScene()
    {
        SceneManager.LoadScene("TutorialCinematic");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
