using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonMenuPrincipal : MonoBehaviour
{
    public void VolverAlInicio()
    {
        SceneManager.LoadScene("MenuPrincipal"); // nombre EXACTO de tu escena inicial
    }
}