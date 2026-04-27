using System.Collections;
using UnityEngine;

public class SpikeWallTrap : MonoBehaviour
{
    public Transform wall;
    public Transform startPos;
    public Transform endPos;

    public float speed = 60f;

    // tamaño del área de golpe (ajústalo si quieres)
    public Vector3 hitBoxSize = new Vector3(1.5f, 2f, 1.5f);

    private bool activated = false;

    void Start()
    {
        wall.position = startPos.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (activated) return;

        if (other.GetComponentInParent<CharacterController>() != null)
        {
            activated = true;
            StartCoroutine(MoveWall());
        }
    }

    IEnumerator MoveWall()
    {
        Vector3 lastPos = wall.position;

        while (Vector3.Distance(wall.position, endPos.position) > 0.01f)
        {
            // mover la pared
            wall.position = Vector3.MoveTowards(
                wall.position,
                endPos.position,
                speed * Time.deltaTime
            );

            // 🔥 detección tipo barrido (evita que se escape por esquinas)
            Vector3 center = (wall.position + lastPos) / 2f;

            Collider[] hits = Physics.OverlapBox(center, hitBoxSize);

            foreach (var hit in hits)
            {
                CharacterController cc = hit.GetComponentInParent<CharacterController>();

                if (cc != null)
                {
                    Destroy(cc.gameObject);
                }
            }

            lastPos = wall.position;

            yield return null;
        }

        // desaparece al final
        wall.gameObject.SetActive(false);
    }
}