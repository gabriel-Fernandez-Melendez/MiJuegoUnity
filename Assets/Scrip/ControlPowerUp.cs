using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPowerUp : MonoBehaviour
{
    public int cantidad;

    public AudioSource audiosourse;
    public AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //free sound pagina para sacar sonidos y onlineconvert para pasarlo a ogg
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            audiosourse.PlayOneShot(clip);
            collision.gameObject.GetComponent<ControlJugador>().incrementarPuntos(cantidad);
            Destroy(gameObject);
        }
    }
}
