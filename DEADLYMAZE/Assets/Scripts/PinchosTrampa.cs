using System.Collections;
using UnityEngine;

public class PinchosTrampa : MonoBehaviour
{
    public Transform spikes;
    public Transform downPos;
    public Transform upPos;

    public GameObject killZone;

    public float delay = 0.15f;

    private bool activated = false;

    void Start()
    {
        spikes.position = downPos.position;
        killZone.SetActive(false);
    }

    public void ActivateTrap()
    {
        if (!activated)
        {
            activated = true;
            StartCoroutine(SpawnTrap());
        }
    }

    IEnumerator SpawnTrap()
    {
        yield return new WaitForSeconds(delay);

        spikes.position = upPos.position;
        killZone.SetActive(true);
    }
}