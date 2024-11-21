using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using TMPro.Examples;

public class ControlHUD : MonoBehaviour
{
    public TextMeshProUGUI txtvidas;
    public TextMeshProUGUI puntuaciontxt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setvidastxt(int vidas)
    {
        txtvidas.text = "Vidas : "+vidas;
    }

    public void Setpuntuacion(int puntuacion)
    {
        puntuaciontxt.text="puntuacion :"+puntuacion;
    }
}
