using UnityEngine;

public class ParedSiguienteNivel : MonoBehaviour
{
    public GameObject panelFinal;

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<CharacterController>() != null)
        {
            panelFinal.SetActive(true);

            Time.timeScale = 0f;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}