using UnityEngine;

public class TrapTrigger : MonoBehaviour
{
    public PinchosTrampa trap;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            trap.ActivateTrap();
        }
    }
}