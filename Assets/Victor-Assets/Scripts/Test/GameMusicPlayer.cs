using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMusicPlayer : MonoBehaviour
{
    [SerializeField] private SoundData gameMusic;

    private void Start()
    {
        AudioManager.Instance.Play(gameMusic);
    }
    public void BackToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
