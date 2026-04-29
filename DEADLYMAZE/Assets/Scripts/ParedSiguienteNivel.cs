using UnityEngine;
using UnityEngine.SceneManagement;

public class ParedSiguienteNivel : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<CharacterController>() != null)
        {
            int siguiente = SceneManager.GetActiveScene().buildIndex + 1;

            if (siguiente < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(siguiente);
            }
        }
    }
}