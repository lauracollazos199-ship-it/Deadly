using UnityEngine;
using UnityEngine.SceneManagement;

public class KillZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        TryKill(other);
    }

    private void OnTriggerStay(Collider other)
    {
        TryKill(other);
    }

    void TryKill(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        Collider myCol = GetComponent<Collider>();

        // 🔥 detección real aunque Unity falle
        if (myCol.bounds.Intersects(other.bounds))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}