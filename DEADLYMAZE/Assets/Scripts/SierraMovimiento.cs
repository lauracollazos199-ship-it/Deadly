using UnityEngine;
using UnityEngine.SceneManagement;

public class SierraMovimiento : MonoBehaviour
{
    public Transform puntoA;
    public Transform puntoB;
    public float velocidad = 5f;
    public float velocidadRotacion = 500f;

    private Transform objetivo;

    void Start()
    {
        objetivo = puntoB;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            objetivo.position,
            velocidad * Time.deltaTime
        );

        if (Vector3.Distance(transform.position, objetivo.position) < 0.1f)
        {
            objetivo = (objetivo == puntoA) ? puntoB : puntoA;
        }

        transform.Rotate(0, 0, velocidadRotacion * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerRespawn.instance.KillPlayer(other.gameObject);
        }
    }
}