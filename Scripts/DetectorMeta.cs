using UnityEngine;

public class DetectorMeta : MonoBehaviour
{
    // Esta función se llama cuando el jugador entra en el Trigger de la Meta
    private void OnTriggerEnter(Collider other)
    {
        // Compruebo si el objeto que toca el jugador tiene el Tag "Meta"
        if (other.CompareTag("Meta"))
        {
            Debug.Log("¡Meta alcanzada!");

            // Se usa el GameManager para mostrar el mensaje
            if (GameManager.instance != null)
            {
                GameManager.instance.MostrarMensaje("¡Enhorabuena, has ganado!");
            }

            //desactiva el movimiento del jugador al ganar
            this.enabled = false; 
        }
    }
} 