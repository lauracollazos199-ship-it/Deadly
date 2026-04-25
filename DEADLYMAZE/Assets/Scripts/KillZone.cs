using UnityEngine;
using UnityEngine.SceneManagement;

public class KillZone : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("MUERTE");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}