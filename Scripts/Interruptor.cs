using UnityEngine;

public class Interruptor : MonoBehaviour
{
    public Puerta puertaAsociada;
    public string colorLlave = "Roja";

    public void Activar()
    {
        if (puertaAsociada != null)
        {
            puertaAsociada.Abrir();
            // Feedback en pantalla usando el GameManager 
            GameManager.instance.MostrarMensaje("¡Puerta " + colorLlave + " abierta!");

            // Cambio de color a verde para indicar que ya se usó
            GetComponent<Renderer>().material.color = Color.green;
        }
    }
}