using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPulpo : MonoBehaviour
{
    public float velocidad;
    private Vector3 posicioninicio;
    public Vector3 posicionfin;
    private bool movimientoAfin;

    private SpriteRenderer pulpo;
    private Animator animacion;
    // Start is called before the first frame update
    void Start()
    {
        posicioninicio = transform.position;
        movimientoAfin = true;
        pulpo = GetComponentInChildren<SpriteRenderer>();
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
        Vector3 posicionDestino = (movimientoAfin) ? posicionfin : posicioninicio;
        transform.position = Vector3.MoveTowards(transform.position, posicionDestino, velocidad * Time.deltaTime);

        if (transform.position == posicioninicio)
        {
            movimientoAfin = true;
            pulpo.flipX = false;
        }
        else if (transform.position == posicionfin)
        {
            movimientoAfin = false;
            pulpo.flipX = true;
        }
    }

    private void OntriggerEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<ControlJugador>().QuitarVidas();
        }
    }
}
