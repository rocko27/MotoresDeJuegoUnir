using UnityEngine;

public class MovimientoHorizontal : MonoBehaviour
{
    [Header("Ajustes de Movimiento")]
    public float distancia = 5f;    // Cuántos metros se desplaza
    public float velocidad = 2f;    // Rapidez del vaivén

    //con esto elijo el eje según cómo esté orientado tu pasillo
    public enum Eje { X, Z }
    public Eje ejeMovimiento = Eje.X;

    private Vector3 posicionInicial;

    void Start()
    {
        // Guardamos la posición que tiene en la escena
        posicionInicial = transform.position;
    }

    void Update()
    {
        // PingPong hace que el valor vaya de 0 a 'distancia' y vuelva solo
        float desplazamiento = Mathf.PingPong(Time.time * velocidad, distancia);

        if (ejeMovimiento == Eje.X)
        {
            transform.position = new Vector3(posicionInicial.x + desplazamiento, posicionInicial.y, posicionInicial.z);
        }
        else
        {
            transform.position = new Vector3(posicionInicial.x, posicionInicial.y, posicionInicial.z + desplazamiento);
        }
    }
}