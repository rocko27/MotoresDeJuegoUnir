using UnityEngine;

public class DisparoJugador : MonoBehaviour
{
    public float alcance = 10f; // Distancia del rayo

    void Update()
    {
        // Detecta el clic izquierdo del ratón
        if (Input.GetMouseButtonDown(0))
        {
            LanzarRayo();
        }
    }

    void LanzarRayo()
    {
        RaycastHit hit;
        // Lanza el rayo desde el centro de la cámara hacia adelante
        if (Physics.Raycast(transform.position, transform.forward, out hit, alcance))
        {
            // Debug para ver en la consola qué te mató
            Debug.Log("Has tocado: " + hit.transform.name);

            // se intenta activar script del Interruptor del objeto tocado
            Interruptor inter = hit.transform.GetComponent<Interruptor>();
            if (inter != null)
            {
                inter.Activar();
            }
        }
    }
}