using UnityEngine;

public class PisoFalso : MonoBehaviour
{
    public Transform jugador;
    public float rangoHorizontal = 1.0f;
    public float alturaMaxima = 3.0f;

    bool activado = false;

    void Update()
    {
        if (jugador == null || activado) return;

        // Distancia en XZ (horizontal)
        Vector2 posJugador = new Vector2(jugador.position.x, jugador.position.z);
        Vector2 posPiso = new Vector2(transform.position.x, transform.position.z);

        float distancia = Vector2.Distance(posJugador, posPiso);

        // Verificar que esté encima (más alto que el piso)
        bool estaEncima = jugador.position.y > transform.position.y;

        if (distancia < rangoHorizontal && estaEncima && jugador.position.y - transform.position.y < alturaMaxima)
        {
            activado = true;
            Invoke("Romper", 0.2f);
        }
    }

    void Romper()
    {
        gameObject.SetActive(false);
    }
}