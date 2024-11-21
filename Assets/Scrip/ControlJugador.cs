using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlJugador : MonoBehaviour
{
    public int velocidad;
    public Rigidbody2D fisica;
    //para las fisicas de movimiento(esta private`por que no hace falta acceder desde unity a la propiedad)
    private SpriteRenderer sprite;
    private Animator animator;
    public int fuerzasalto;
    public int numVidas;
    //cuando  utilizamos el mismo audio source usamos el metodo playoneshot
    public AudioSource audiosourse;
    public AudioClip clip;
    //canvas para mostrar las  vidas
    public Canvas hud;
    private ControlHUD hudControl;

    //para ver si el jugador es vulnerable o no 
    private bool vulnerable;
    public int puntuacion;
    // Start is called before the first frame update
    void Start()
    {
        //conseguimos las propiedades del rigidbody del jugador
        fisica = GetComponent<Rigidbody2D>();
        //cargamos la info
        sprite = GetComponent<SpriteRenderer>();
        //inicializamos el animator
        animator = GetComponent<Animator>();
        //es vulnerable al comenzar 
        vulnerable = true;
        hudControl = hud.GetComponent<ControlHUD>();
    }

    //es mejor  usar este metodo en el movimiento por que su actualizacion se la puedes dar de forma especifitca
    private void FixedUpdate()
    {
        //aqui indicamos como capturamos la captura   
        float entradaX = Input.GetAxis("Horizontal");
        fisica.velocity = new Vector2(entradaX * velocidad, fisica.velocity.y);
        //
        if (fisica.velocity.x < 0) sprite.flipX = true;
        else if (fisica.velocity.x > 0) sprite.flipX = false;
        //animator.SetBool("correr",entradaX!=0.0f);
        //forma alternativa de como  hacerlo
        //atento cabron a los ejes y a cuando es mayor o menor que
       if ((fisica.velocity.x > 1 || fisica.velocity.x < -1) && fisica.velocity.y == 0)
        {
            animator.Play("correr");
        }
        else if (!TocarSuelo())
        {
            animator.Play("Saltar");
        }
        else //if ((fisica.velocity.x > 1 || fisica.velocity.x < -1) && fisica.velocity.y == 0)
        {
            animator.Play("jugadorparado");
        }

    }
    //creamos un metodo que sea la animacion del jugador(para saltar usar raycast)
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&& TocarSuelo())
        {
            //esta es la forma de calcular la fuerza del salto con un vector
            fisica.AddForce(Vector2.up*fuerzasalto,ForceMode2D.Impulse);
            

        }

    }
    private bool TocarSuelo()
    {
        RaycastHit2D toca = Physics2D.Raycast(transform.position + new Vector3(0,-2f,0),Vector2.down,0.2f);
        return toca.collider!=null;
    }

    //importante usar fixeduptade para el movimiento horizontal

    //utilizar el operador el "?" cuando pueda hacer un  if en una linea (se usa para asignaciones)
    //el vector3 parase ser usado para moviminetos generales de personajes en 2D 
    //

    //OJO se puede llamar directmamente a metodos que estan en el scrip
    public void FinalizarJuego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitarVidas()
    {
        if (vulnerable)
        {
            audiosourse.PlayOneShot(clip);
            numVidas--;
        if(numVidas==0)
            FinalizarJuego();
            Invoke("HacerVulnerable", 1f);
        sprite.color = Color.red;
        }
      
    }

    private void HacerVulnerable()
    {
        vulnerable = true;
        sprite.color = Color.white;
    }

    public void incrementarPuntos(int puntos)
    {
        puntuacion += puntos;
        hudControl.Setpuntuacion(puntuacion);
    }

}
