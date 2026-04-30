using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Material CheckpointInactivo;
    public Material CheckpointActivo;

    private bool activated = false;
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();

        if (CheckpointInactivo != null)
            rend.material = CheckpointInactivo;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !activated)
        {
            activated = true;

            Debug.Log("Checkpoint activado");

            CheckpointManager.instance.SetCheckpoint(transform.position);

            if (CheckpointActivo != null)
                rend.material = CheckpointActivo;
        }
    }
}