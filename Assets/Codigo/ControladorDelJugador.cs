using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class ControladorDelJugador : MonoBehaviour
{
    
         public float velocidad;
         public float contador;
         public Text marcador;
         public Text findejuego;
         Rigidbody rb;
       

        void Awake()
        {
            rb = GetComponent<Rigidbody>();
            contador = 0;
            ActualizarMarcador();
            findejuego.gameObject.SetActive(false);
        }
        void FixedUpdate()
        {
            float movimientoHorizontal = Input.GetAxis("Horizontal");
            float movimientoVertical = Input.GetAxis("Vertical");

            Vector3 movimiento = new Vector3(movimientoHorizontal, 0f, movimientoVertical);
        rb.AddForce(movimiento*velocidad);


        }
        void ActualizarMarcador()
        {
            marcador.text = "Puntos: " + contador;
        }
    void OnTriggerEnter(Collider other) //collider es el objeto con el que ha colisionado
    {
        {
            Destroy(other.gameObject);
            contador = contador + 1;
            ActualizarMarcador();
            if (contador >= 10)
            {
                findejuego.gameObject.SetActive(true);
            }
        }
        

        ActualizarMarcador();
        if(contador >=10)  //El juego finaliza a los 13 puntos
        {
            findejuego.gameObject.SetActive(true);
        }

        Destroy(other.gameObject); //Destruye el objeto que se indique entre paréntesis, que el gamobject que tiene el Collider con Is Trigger activado
        
        contador = contador + 1; //Incrementa el contador

        ActualizarMarcador();//método que actualiza el marcador

    }



}
