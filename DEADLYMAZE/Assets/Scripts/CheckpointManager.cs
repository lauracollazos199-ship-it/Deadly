using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager instance;

    private Vector3 checkpointPosition;
    private bool hasCheckpoint = false;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            checkpointPosition = player.transform.position;
            hasCheckpoint = true;
        }
    }

    public void SetCheckpoint(Vector3 pos)
    {
        checkpointPosition = pos;
        hasCheckpoint = true;
    }

    public Vector3 GetCheckpoint()
    {
        return checkpointPosition;
    }

    public bool HasCheckpoint()
    {
        return hasCheckpoint;
    }
}
