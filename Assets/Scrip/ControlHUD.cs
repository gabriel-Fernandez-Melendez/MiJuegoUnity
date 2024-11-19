using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using TMPro.Examples;

public class ControlHUD : MonoBehaviour
{
    public TextMeshProUGUI vidas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setvidastxt()
    {
        vidas.text = "Vidas : "+vidas;
    }
}
