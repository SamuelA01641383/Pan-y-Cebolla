using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    private AssetBundle ab;
    [SerializeField] GameObject fadeIn_;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void fadeIn()
    {
        fadeIn_.gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene("Level1");
        }
    }
}
