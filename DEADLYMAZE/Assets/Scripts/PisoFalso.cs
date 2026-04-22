using UnityEngine;

public class PisoFalso : MonoBehaviour
{
    public Transform jugador;
    public float distanciaActivacion = 1.5f;

    void Update()
    {
        if (jugador == null) return;

        float distancia = Vector3.Distance(transform.position, jugador.position);

        if (distancia < distanciaActivacion)
        {
            Debug.Log("💥 Piso falso activado");
            gameObject.SetActive(false);
        }
    }
}