using UnityEngine;

public class FallDeath : MonoBehaviour
{
    public float limiteMuerte = -10f;

    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (transform.position.y < limiteMuerte)
        {
            Morir();
        }
    }

    void Morir()
    {
        if (CheckpointManager.instance != null && CheckpointManager.instance.HasCheckpoint())
        {
            controller.enabled = false;

            Vector3 respawn = CheckpointManager.instance.GetCheckpoint() + Vector3.up * 2f;
            transform.position = respawn;

            controller.enabled = true;
        }
        else
        {
            Debug.LogWarning("No hay checkpoint!");
        }
    }
}
