using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Aquí defino la velocidad de giro.
    public float rotationSpeed = 120f;
    // Aquí defino la velocidad base.
    public float movementSpeed = 5f;

    // Declaro una variable para guardar una referencia al componente CharacterController,
    // que es el que me permite mover al jugador sin físicas complicadas.
    CharacterController controller;

    void Start()
    {
        // En cuanto empieza el juego, busco y guardo el componente CharacterController
        // que está adjunto a este mismo objeto.
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Obtengo el valor de entrada del teclado/mando para el eje "Horizontal" (flechas izquierda/derecha o A/D).
        // El valor estará entre -1 y 1.
        float horizontal = Input.GetAxis("Horizontal");
        // Obtengo el valor de entrada del teclado/mando para el eje "Vertical" (flechas arriba/abajo o W/S).
        // El valor también estará entre -1 y 1.
        float vertical = Input.GetAxis("Vertical");

        // Aquí roto mi objeto. La rotación se aplica en el eje Y (vertical)
        // multiplicando la entrada horizontal por la velocidad y por el tiempo (para que sea fluida).
        transform.Rotate(0, horizontal * rotationSpeed * Time.deltaTime, 0);

        // Creo un Vector3 (X, Y, Z) para definir la dirección de movimiento.
        // Solo uso el eje Z (adelante/atrás), basado en la entrada vertical y mi velocidad de movimiento.
        Vector3 move = new Vector3(0, 0, vertical * movementSpeed);
        // Transformo ese vector de movimiento de coordenadas locales (hacia adelante del jugador)
        // a coordenadas globales del mundo. Esto es clave para que avance hacia donde está mirando.
        move = transform.TransformDirection(move);

        // Finalmente, utilizo el CharacterController para mover al personaje
        // multiplicando el vector de movimiento por Time.deltaTime (para que el movimiento sea independiente de los FPS).
        controller.Move(move * Time.deltaTime);
    }
}

