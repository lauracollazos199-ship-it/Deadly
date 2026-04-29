using UnityEngine;
using UnityEngine.SceneManagement;

public class PisoFalso : MonoBehaviour
{
    public LayerMask capaJugador;

    private Vector3 tamaño;
    private BoxCollider col;

    bool activado = false;

    void Start()
    {
        col = GetComponent<BoxCollider>();

        // Ajusta automáticamente al tamaño del piso
        tamaño = new Vector3(
            col.size.x * transform.localScale.x,
            5f, // altura de detección (ajústalo si saltas más alto)
            col.size.z * transform.localScale.z
        );
    }

    void Update()
    {
        if (activado) return;

        Vector3 centro = transform.position + Vector3.up * (tamaño.y / 2);

        if (Physics.CheckBox(centro, tamaño / 2, Quaternion.identity, capaJugador))
        {
            activado = true;
            Romper();
        }
    }

    void Romper()
    {
        gameObject.SetActive(false);

        // Detectar jugador encima
        Collider[] hits = Physics.OverlapBox(
            transform.position + Vector3.up * 1f,
            new Vector3(tamaño.x / 2, 2f, tamaño.z / 2),
            Quaternion.identity,
            capaJugador
        );

        foreach (Collider col in hits)
        {
            CharacterController cc = col.GetComponent<CharacterController>();

            if (cc != null)
            {
                // Empujón suave para evitar que se quede pegado
                cc.Move(Vector3.down * 0.2f);
            }
        }

        Invoke("ReiniciarEscena", 1.5f);
    }

    void ReiniciarEscena()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}