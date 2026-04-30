using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PausaMenu : MonoBehaviour
{
    public GameObject panelPausa;       // arrastra aquí tu PausePanel
    public PlayerInput playerInput;     // arrastra aquí el PlayerInput del personaje

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
        // Con Escape alterna entre pausar y reanudar
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (pausado)
                Reanudar();
            else
                Pausar();   // aquí se activa el panel
        }
    }

    public void Pausar()
{
    panelPausa.SetActive(true);
    Time.timeScale = 0f;
    pausado = true;

    Cursor.lockState = CursorLockMode.None;
    Cursor.visible = true;

    if (playerInput != null)
        playerInput.SwitchCurrentActionMap("UI");
}

    public void Reanudar()
    {
        // Ocultar panel y reanudar juego
        panelPausa.SetActive(false);
        Time.timeScale = 1f;
        pausado = false;

        // Bloquear cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Volver al mapa Player
        if (playerInput != null)
            playerInput.SwitchCurrentActionMap("Player");
    }

    public void IrAlMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
