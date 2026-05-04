using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
    public static PlayerRespawn instance;

    private void Awake()
    {
        instance = this;
    }

    public void KillPlayer(GameObject player)
    {
        if (CheckpointManager.instance != null && CheckpointManager.instance.HasCheckpoint())
        {
            CharacterController cc = player.GetComponent<CharacterController>();

            if (cc != null)
                cc.enabled = false;

            player.transform.position = CheckpointManager.instance.GetCheckpoint();

            if (cc != null)
                cc.enabled = true;

            // 🔥 Resetear trampas

            // 🔥 Resetear trampas

            PisoFalso[] pisos = FindObjectsByType<PisoFalso>(
                FindObjectsInactive.Include,
                FindObjectsSortMode.None
            );

            foreach (var p in pisos)
            {
                p.ResetTrap();
            }

            TrampaPared[] paredes = FindObjectsByType<TrampaPared>(FindObjectsSortMode.None);

            foreach (var t in paredes)
            {
                t.ResetTrap();
            }
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
