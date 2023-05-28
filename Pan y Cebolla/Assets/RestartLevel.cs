using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RestartLevel : MonoBehaviour
{

    [SerializeField] ChangeScene CS;
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
            CS.fadeIn();
            SceneManager.LoadScene(name);
        }
    }
}
