using UnityEngine;

public class TrampaMuerte : MonoBehaviour
{
    // Se ejecuta automáticamente al entrar en el Trigger
    private void OnTriggerEnter(Collider other)
    {
        // Comprobamos si lo que ha entrado es el Jugador
        if (other.CompareTag("Player"))
        {
            // Se llama al GameManager configurado para que nos teletransporte
            GameManager.instance.Morir();
        }
    }
}