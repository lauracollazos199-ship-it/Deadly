using UnityEngine;
using UnityEngine.SceneManagement;

public class ParedTrampa : MonoBehaviour
{
    public Transform jugador;
    public float distanciaActivacion = 10f;
    public float velocidadCaida = 400f;

    private bool activada = false;
    private float rotacion = 0f;

    private Collider col;

    void Start()
    {
        col = GetComponentInChildren<Collider>(); // collider de la pared
    }

    void Update()
    {
        if (jugador == null) return;

        float distancia = Vector3.Distance(transform.position, jugador.position);

        // Activar
        if (distancia < distanciaActivacion && !activada)
        {
            activada = true;

            // 🔴 desactivar colisión mientras cae
            col.enabled = false;
        }

        // Rotación
        if (activada && rotacion < 90f)
        {
            float paso = velocidadCaida * Time.deltaTime;

            transform.Rotate(Vector3.forward * paso, Space.Self);
            rotacion += paso;
        }

        // Cuando termina de caer
        if (rotacion >= 90f && !col.enabled)
        {
            col.enabled = true; // 🔥 vuelve a activar colisión
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}