using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonMenuPrincipal : MonoBehaviour
{
    public void VolverAlInicio()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        SceneManager.LoadScene("MenuPrincipal"); // tu escena inicial
    }
}