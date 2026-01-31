using UnityEngine;
using System.Collections;
public class TeleportEnemy : MonoBehaviour
{
    [Header("Enemy Teleport Points")]
    [SerializeField] private Transform[] points;
    [SerializeField] private float timeTeleportSpawn = 1.5f;

    private int currentIndex = 0;

    private void Start()
    {
        if (points.Length == 0) return;

        transform.position = points[0].position;

        StartCoroutine(Teleport());
    }

    private IEnumerator Teleport()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeTeleportSpawn);
            currentIndex++;

            if (currentIndex >= points.Length)
            {
                currentIndex = 0;
            }

            transform.position = points[currentIndex].position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player Died By Enemy");
        }
    }
}
