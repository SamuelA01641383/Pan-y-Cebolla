using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class TextScript : MonoBehaviour
{
    // Me he levantado con un fuego que arde dentro de mí, un habre insaciable con un deseo que consumir sin piedad, hoy, mi misión es clara: Crear el sandwich definitivo! la mayor experiencia culinaria jamas creada! 
    //Debo salir a conseguir los ingredientes !

    private TMP_Text text;
    private string[] lineas = new string[3];
    private int lineNum = 0;
    private int index = 0;
    private float delay = 1f;
    private bool changeline = false;
    private int current = 0;
    private bool firstLine = true;
    private bool clear = false;
    private bool go = false;

    [SerializeField] AnimatedPlayer animatedPlayer;
    [SerializeField] GameObject spaceBar;

    // Start is called before the first frame update
    void Start()
    {
       
        text = GetComponent<TMP_Text>();
        lineas[0] = "Me he levantado con un hambre insaciable...";
        lineas[1] = "Mi mision es clara: Crear el sandwich definitivo!";
        lineas[2] = "Debo salir a conseguir los ingredientes !";

        text.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if(animatedPlayer.current == 4)
        {
            spaceBar.gameObject.SetActive(true);

            if (firstLine)
            {
                updateText();
            
            }else if(Input.GetKeyDown(KeyCode.Space) && lineNum == 1 || go){
                
                go = true;

                if (clear)
                {
                    text.text = "";
                    clear = false;
                }

                updateText();

            }else if(Input.GetKeyDown(KeyCode.Space) && lineNum == 2 || go){

                go = true;

                if (clear)
                {
                    text.text = "";
                    clear = false;
                }

                updateText();
            }
        }
    }

    private void updateText()
    {
        if (lineNum <= 2 && index < lineas[lineNum].Length)
        {
            text.text = text.text + lineas[lineNum][index];
            index++;
        }
        else
        {
            if(lineNum == 2)
            {
                animatedPlayer.updateCurrent();
            }

            lineNum++;
            index = 0;
            clear = true;
            go = false;
            
            if (firstLine)
            {
                firstLine = false;
            }
        }
    }
}
