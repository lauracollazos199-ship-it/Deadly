using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonSiguienteNivel : MonoBehaviour
{
    public void IrAlSiguienteNivel()
    {

        Time.timeScale = 1f;

        int siguiente = SceneManager.GetActiveScene().buildIndex + 1;

        if (siguiente < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(siguiente);
        }
        else
        {
            Debug.Log("No hay más niveles");
        }
    }
}