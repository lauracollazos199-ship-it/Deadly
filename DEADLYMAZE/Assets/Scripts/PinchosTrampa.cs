using System.Collections;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    public Transform spikes;
    public Transform downPos;
    public Transform upPos;

    public float speed = 25f;

    public float killHeightOffset = 0.2f; 
    // 🔥 margen para pies (ajústalo si quieres más o menos dificultad)

    private bool activated = false;
    private bool spikesUp = false;

    private CharacterController player;

    void Start()
    {
        spikes.position = downPos.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (activated) return;

        CharacterController cc = other.GetComponentInParent<CharacterController>();

        if (cc != null)
        {
            player = cc;
            activated = true;

            StartCoroutine(RaiseSpikes());
        }
    }

    IEnumerator RaiseSpikes()
    {
        // 🔼 suben una sola vez
        while (Vector3.Distance(spikes.position, upPos.position) > 0.01f)
        {
            spikes.position = Vector3.MoveTowards(
                spikes.position,
                upPos.position,
                speed * Time.deltaTime
            );

            yield return null;
        }

        spikesUp = true;
    }

    void Update()
    {
        if (!spikesUp || player == null) return;

        float spikeTopY = spikes.position.y;
        float playerBottomY = player.transform.position.y - (player.height * 0.5f);

        if (playerBottomY <= spikeTopY + 0.2f)
        {
            Debug.Log("💀 MUERTE");
            Destroy(player.gameObject);
        }
    }
}