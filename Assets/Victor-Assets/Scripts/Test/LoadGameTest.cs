using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGameTest : MonoBehaviour
{
    [SerializeField] private SoundData menuMusic;

    private void Start()
    {
        AudioManager.Instance.Play(menuMusic);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("GameTest");
    }
}
