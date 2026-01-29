using UnityEngine;
using TMPro;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Referencias")]
    public Transform jugador;
    public Transform puntoInicio;
    public TextMeshProUGUI textoUI;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    public void MostrarMensaje(string mensaje)
    {
        StartCoroutine(RutinaMensaje(mensaje));
    }

    IEnumerator RutinaMensaje(string mensaje)
    {
        textoUI.text = mensaje;
        yield return new WaitForSeconds(3f);
        textoUI.text = "";
    }

    public void Morir()
    {
        /* Se desactiva el CharacterController momentáneamente para evitar que el motor de física
         bloquee el movimiento al teletransportar.*/
        CharacterController cc = jugador.GetComponent<CharacterController>();

        if (cc != null) cc.enabled = false;

        // Teletransportamos jugador al spawnpoint
        jugador.position = puntoInicio.position;

        if (cc != null) cc.enabled = true;

        MostrarMensaje("¡Has muerto! Vuelve a intentarlo.");
    }
}