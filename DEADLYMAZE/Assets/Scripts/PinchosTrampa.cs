using System.Collections;
using UnityEngine;

public class PinchosTrampa : MonoBehaviour
{
    public Transform spikes;
    public Transform downPos;
    public Transform upPos;

    public GameObject killZoneTop;
    public GameObject killZoneSide;

    public float speed = 8f;

    private bool activated = false;

    void Start()
    {
        spikes.position = downPos.position;

        killZoneTop.SetActive(false);
        killZoneSide.SetActive(false);
    }

    public void ActivateTrap()
    {
        if (!activated)
        {
            activated = true;
            StartCoroutine(RaiseSpikes());
        }
    }

    IEnumerator RaiseSpikes()
    {
        while (Vector3.Distance(spikes.position, upPos.position) > 0.01f)
        {
            spikes.position = Vector3.MoveTowards(
                spikes.position,
                upPos.position,
                speed * Time.deltaTime
            );

            yield return null;
        }

        killZoneTop.SetActive(true);
        killZoneSide.SetActive(true);
    }
}