using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndZone : MonoBehaviour
{
    [SerializeField] private string newScene;

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if( collision.gameObject.CompareTag("Player"))
            SceneManager.LoadScene(newScene);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            SceneManager.LoadScene(newScene);
    }


}
