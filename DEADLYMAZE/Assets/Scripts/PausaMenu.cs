using UnityEngine;
using UnityEngine.SceneManagement;

public class PausaMenu : MonoBehaviour
{
    public GameObject panelPausa;

    private bool pausado = false;

    void Start()
    {
        panelPausa.SetActive(false);
        Time.timeScale = 1f;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // 🔥 SIMPLE Y FUNCIONAL
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausado)
                Reanudar();
            else
                Pausar();
        }
    }

    public void Pausar()
    {
        panelPausa.SetActive(true);
        Time.timeScale = 0f;
        pausado = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Reanudar()
    {
        panelPausa.SetActive(false);
        Time.timeScale = 1f;
        pausado = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void IrAlMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
