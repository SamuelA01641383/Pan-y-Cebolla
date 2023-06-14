using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    [SerializeField] FadeEffect fadeScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            Invoke("main", 1f);
        }
    }

    public void main()
    {
        fadeScreen.fadeIn();
        Invoke("changeScene", 1f);
    }

    private void changeScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
