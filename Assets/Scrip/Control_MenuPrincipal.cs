using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Control_MenuPrincipal : MonoBehaviour
{
    //creamos el panel que va dentro de un game object
    public GameObject panel;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //hay que tener un metodo por cada uno de los  botonones a configurar
    public void Salir()
    {
        Application.Quit();
    }

    //ahora hay qye hacer el de jugar
    public void jugar()
    {
        SceneManager.LoadScene("nivel1");
    }

    public void Creditos()
    {

    }
}
