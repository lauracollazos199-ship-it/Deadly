using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrampaPared : MonoBehaviour
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
        wall.GetComponent<Renderer>().enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (activated) return;

        if (other.GetComponentInParent<CharacterController>() != null)
        {
            activated = true;
            wall.GetComponent<Renderer>().enabled = true;
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

            // detección tipo barrido 
            Vector3 center = (wall.position + lastPos) / 2f;

            Collider[] hits = Physics.OverlapBox(center, hitBoxSize);

            foreach (var hit in hits)
            {
                CharacterController cc = hit.GetComponentInParent<CharacterController>();

                if (cc != null)
                {
                    Invoke("ReiniciarEscena", 0f);
                }
            }

            lastPos = wall.position;

            yield return null;
        }

        // desaparece al final
        wall.gameObject.SetActive(false);
    }

    void ReiniciarEscena()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}