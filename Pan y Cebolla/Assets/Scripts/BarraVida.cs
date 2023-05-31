using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraVida : MonoBehaviour
{
    private PLayerHurt HP;
    private Slider life;

    // Start is called before the first frame update
    void Start()
    {
        HP = FindObjectOfType<PLayerHurt>();
        life = this.GetComponent<Slider>();
        life.maxValue = HP.getMaxHP();
        life.minValue = 0;
        life.value = HP.getMaxHP();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setHP()
    {
        life.value = HP.getHP();
    }
}
