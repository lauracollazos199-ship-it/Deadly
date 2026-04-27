using System.Collections;
using UnityEngine;

public class SpikeWallTrap : MonoBehaviour
{
    public Transform wall;
    public Transform startPos;
    public Transform endPos;

    public float speed = 50f;

    // tamaño del área que mata (ajústalo si hace falta)
    public Vector3 killBoxSize = new Vector3(1f, 2f, 1f);

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
        while (Vector3.Distance(wall.position, endPos.position) > 0.01f)
        {
            // mover pared
            wall.position = Vector3.MoveTowards(
                wall.position,
                endPos.position,
                speed * Time.deltaTime
            );

            // 🔥 detección de muerte (esto reemplaza colisiones)
            Collider[] hits = Physics.OverlapBox(
                wall.position,
                killBoxSize
            );

            foreach (var hit in hits)
            {
                CharacterController cc = hit.GetComponentInParent<CharacterController>();

                if (cc != null)
                {
                    Debug.Log("💀 APLASTADO");
                    Destroy(cc.gameObject);
                }
            }

            yield return null;
        }

        // desaparece al final
        wall.gameObject.SetActive(false);
    }
}