using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlEnemigo : MonoBehaviour
{
    public float velocidad;
    private Vector3 posicioninicio;
    public Vector3 posicionfin;
    private bool movimientoAfin;
    //declaramos una variable de tipo sprite
    private SpriteRenderer cangrejo;
    private Animator animacion;
    // Start is called before the first frame update
    void Start()
    {
        posicioninicio = transform.position;
        movimientoAfin = true;
        cangrejo = GetComponentInChildren<SpriteRenderer>();
        animacion = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        MoverEnemigo();
    }

    private void MoverEnemigo()
    {
        Vector3 posicionDestino =(movimientoAfin) ? posicionfin : posicioninicio;
        transform.position = Vector3.MoveTowards(transform.position, posicionDestino,velocidad*Time.deltaTime);

        if(transform.position==posicioninicio)
        {
            movimientoAfin = true;
            cangrejo.flipX = false;
        }
        else if(transform.position==posicionfin)
        {
            movimientoAfin = false;
            cangrejo.flipX = true;
        }
     
}
    public void OntriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<ControlJugador>().QuitarVidas();
        }
    }
}
